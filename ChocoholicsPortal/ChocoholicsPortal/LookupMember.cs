using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoholicsPortal
{
    class LookupMember
    {
        public bool CheckTheMember(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return false;
            }

            //Hit the database to verify

            return true;
        }
    }
}
