using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoholicsPortal
{
    class VerifyID
    {
        public bool CheckTheID(string ID)
        {
            if(string.IsNullOrEmpty(ID))
            {
                return false;
            }

            return true;
        }
    }
}
