using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoholicsPortal
{
    class ProviderFunctions
    {
        chocanonEntities dbs = new chocanonEntities();

        public bool CheckTheID(string ID)
        {
            if(string.IsNullOrEmpty(ID))
            {
                return false;
            }
            //Hit the database to verify
            var intID = Convert.ToInt32(ID);
            if(dbs.provider.Where(m=>m.ProviderID == intID).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InsertProvider(provider newProvider)
        {
            dbs.provider.Add(newProvider);
            return (dbs.SaveChanges() > 0);
        }
        public provider FindProvider(string ID)
        {
            var intID = Convert.ToInt32(ID);
            return dbs.provider.FirstOrDefault(m => m.ProviderID == intID);
        }
        public bool DeleteProvider(provider provider)
        {
            var rowsAffected = dbs.Database.ExecuteSqlCommand("DELETE FROM [dbo].[provider] WHERE [ProviderID]={0}", provider.ProviderID);
            return (rowsAffected > 0);
        }
        public bool UpdateProvider(provider UpdatedProvider)
        {
            var before = dbs.provider.FirstOrDefault(m => m.ProviderID == UpdatedProvider.ProviderID);
            var rowsAffected = dbs.Database.ExecuteSqlCommand("update [dbo].[provider] " +
                "set FirstName = '" + UpdatedProvider.FirstName +
                "', LastName = '" + UpdatedProvider.LastName +
                "', Phone = '" + UpdatedProvider.Phone +
                "', email = '" + UpdatedProvider.Email +
                "', Address = '" + UpdatedProvider.Address +
                "', City = '" + UpdatedProvider.City +
                "', State = '" + UpdatedProvider.State +
                "', Zip = '" + UpdatedProvider.Zip +
                "' WHERE [ProviderID]={0}", UpdatedProvider.ProviderID);
            return (rowsAffected > 0);
        }
    }
}
