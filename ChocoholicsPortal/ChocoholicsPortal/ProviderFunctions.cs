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
    }
}
