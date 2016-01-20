using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.HooGoin
{
    public class NewEvent
    {
        public UserInfo UserInfo { get; set; }
        public LocationList LocationList { get; set; }
        public string EventDate { get; set; }
        public string WordfromLeader { get; set; }
    }
}
