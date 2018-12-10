using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UserSession
    {
        public UserSession()
        {
            UserName = "";
            GrantID = 0;
        }
        public UserSession(string username, int grantid)
        {
            UserName = username;
            GrantID = grantid;
        }

        public string UserName { get; set; }
        public int GrantID { get; set; }
    }
}
