using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChocoholicsPortal
{
    class APFunctions
    {
        chocanonEntities dbs = new chocanonEntities();
        DateTime today = DateTime.Today;
        DateTime lastWeek = DateTime.Today.AddDays(-7);

        
        public void RunAPProcess()
        {
            //Get Providers

            var WeekProviders = GetWeekProviders();

            //loop through billing info
            foreach (var item in WeekProviders)
            {
                var weeklyBilling = GetWeeklyBilling(item);

                var getAPPeriod = dbs.ap_period.Where(m => m.EndDate == today).FirstOrDefault()?.APPeriodID;

                InsertEFTRecord(
                    new eft()
                    {
                        ProviderID = item.ProviderID,
                        ProviderName = (item.FirstName + item.LastName),
                        APPeriodID = getAPPeriod ?? 0,
                        Amount = weeklyBilling ?? 0
                    }
                );
            }

            GenerateReports();
        }
        private void GenerateReports()
        {
            //Generate AP Manager Report
            //Generate Provider Report
            //Generate Member Report
        }
        private List<provider> GetWeekProviders()
        {
            return dbs.bill_info.Where(m => m.ServiceDate <= today && m.ServiceDate >= lastWeek)
                .Select(m=>m.provider).Distinct()
                .ToList();
        }
        private double? GetWeeklyBilling(provider singleProvider)
        {
            return dbs.bill_info.Where(m => m.ServiceDate <= today && m.ServiceDate >= lastWeek
                    && m.ProviderID == singleProvider.ProviderID).Sum(m=>m.service.ServiceCost);
        }
        private void InsertEFTRecord(eft newEft)
        {
            dbs.eft.Add(newEft);
        }
    }
}
