using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoholicsPortal
{
    class ServiceLookup
    {
        public bool CheckTheServiceCode(string serviceCode)
        {
            if (string.IsNullOrEmpty(serviceCode))
            {
                return false;
            }
            //Hit the database to verify

            return true;
        }
        public ServiceEntity ReturnSingleServices(string serviceCode)
        {
            if (string.IsNullOrEmpty(serviceCode))
            {
                return new ServiceEntity();
            }

            //Hit the database to verify

            return new ServiceEntity();
        }
        public List<ServiceEntity> ReturnAllServices()
        {
            //Hit the database to verify

            return new List<ServiceEntity>();
        }
    }
    public class ServiceEntity
    {
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public double? ServiceFee { get; set; }
    }
}
