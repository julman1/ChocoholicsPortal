using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoholicsPortal
{
    class MemberFunctions
    {
        chocanonEntities dbs = new chocanonEntities();

        public string CheckTheMember(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return "Not Found";
            }

            var intID = System.Convert.ToInt32(ID);

            //Check if there is a member with this ID
            var memberFound = dbs.member.Where(m => m.MemberID == intID);
            if (memberFound.Any())
            {
                return memberFound.FirstOrDefault().Status;
            }

            return "Not Found";
        }
        public bool InsertMember(member newMember)
        {
            dbs.member.Add(newMember);
            return (dbs.SaveChanges() > 0);
        }
        public member FindMember(string ID)
        {
            var intID = Convert.ToInt32(ID);
            return dbs.member.FirstOrDefault(m=>m.MemberID == intID);
        }
        public bool UpdateMember(member UpdatedMember)
        {
            var before = dbs.member.FirstOrDefault(m => m.MemberID == UpdatedMember.MemberID);
            var rowsAffected = dbs.Database.ExecuteSqlCommand("update [dbo].[member] " +
                "set FirstName = '" + UpdatedMember.FirstName + 
                "', LastName = '" + UpdatedMember.LastName +
                "', Phone = '" + UpdatedMember.Phone +
                "', email = '" + UpdatedMember.Email +
                "', Address = '" + UpdatedMember.Address +
                "', City = '" + UpdatedMember.City +
                "', State = '" + UpdatedMember.State +
                "', Zip = '" + UpdatedMember.Zip +
                "' WHERE [MemberID]={0}", UpdatedMember.MemberID);
            return (rowsAffected > 0);
        }
        public bool DeleteMember(member member)
        {
            var rowsAffected = dbs.Database.ExecuteSqlCommand("DELETE FROM [dbo].[member] WHERE [MemberID]={0}", member.MemberID);
            return (rowsAffected > 0);
        }
    }
}
