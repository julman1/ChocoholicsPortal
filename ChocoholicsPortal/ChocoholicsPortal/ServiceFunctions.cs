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

            var intServiceCode = Convert.ToInt32(serviceCode);

            return dbs.service.Where(m => m.ServiceID == intServiceCode).Any();
        }
        public service ReturnSingleServices(string serviceCode)
        {
            if (string.IsNullOrEmpty(serviceCode))
            {
                return new service();
            }

            var intServiceCode = Convert.ToInt32(serviceCode);

            return dbs.service.Where(m => m.ServiceID == intServiceCode).FirstOrDefault();
        }
        public List<service> ReturnAllServices()
        {
            return dbs.service.ToList();
        }
    }
}
