using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChocoholicsPortal
{
    class BillingFunctions
    {
        chocanonEntities dbs = new chocanonEntities();

        public bool InsertBilling(bill_info newBillInfo)
        {
            dbs.bill_info.Add(newBillInfo);
            return (dbs.SaveChanges() > 0);
        }
        public List<bill_info> GetBillingInfo(int ID)
        {
            return dbs.bill_info.Where(m => m.ProviderID == ID).ToList();
        }
    }
}
