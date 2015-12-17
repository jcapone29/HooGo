using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.HooGoin
{
    public class EventList
    {
        public int UserID { get; set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public decimal Long { get; set; }
        public decimal Lat { get; set; }
        public string Address { get; set; }
        public bool Attending { get; set; }
        public int LeaderID { get; set; }
        public DateTime DateOfEvent { get; set; }
        public bool Active { get; set; }


    }
}
