using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoholicsPortal
{
    class OperatorFunctions
    {
        chocanonEntities dbs = new chocanonEntities();

        public bool CheckTheID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return false;
            }
            //Hit the database to verify
            var intID = Convert.ToInt32(ID);
            if (dbs.@operator.Where(m => m.OperatorID == intID).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public @operator FindOperator(string ID)
        {
            var intID = Convert.ToInt32(ID);
            return dbs.@operator.FirstOrDefault(m => m.OperatorID == intID);
        }

        public bool VerifyManager(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return false;
            }
            //Hit the database to verify
            var intID = Convert.ToInt32(ID);
            if (dbs.@operator.Where(m => m.OperatorID == intID).FirstOrDefault().IsManager ?? false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InsertOperator(@operator newOperator)
        {
            dbs.@operator.Add(newOperator);
            return (dbs.SaveChanges() > 0);
        }
    }
}
