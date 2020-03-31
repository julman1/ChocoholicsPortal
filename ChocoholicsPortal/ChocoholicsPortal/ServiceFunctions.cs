using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoholicsPortal
{
    class ServiceFunctions
    {
        chocanonEntities dbs = new chocanonEntities();

        public bool CheckTheServiceCode(string serviceCode)
        {
            if (string.IsNullOrEmpty(serviceCode))
            {
                return false;
            }
            //Hit the database to verify

            return true;
        }
        public service ReturnSingleServices(string serviceCode)
        {
            if (string.IsNullOrEmpty(serviceCode))
            {
                return new service();
            }

            //Hit the database to verify

            return new service();
        }
        public List<service> ReturnAllServices()
        {
            //Hit the database to get all
            return dbs.service.ToList();
        }
    }
}
