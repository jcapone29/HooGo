using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.HooGoin
{
    public class YelpSearch
    {
        public string searchterm { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }

    }
}
