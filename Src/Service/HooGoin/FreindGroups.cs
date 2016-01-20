using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.HooGoin
{
   public class FreindGroups
    {
       public int  UserID { get; set; }
        public int  GroupID { get; set; }
        public string GroupName { get; set; }
        public int FriendUserID { get; set; }
        public string UserName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public bool  WiGoUser { get; set; }
        public bool  GroupActive { get; set; }
    }
}
