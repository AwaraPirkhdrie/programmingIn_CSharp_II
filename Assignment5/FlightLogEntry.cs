using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public class FlightLogEntry
    {
        public string Flight_Code { get; set; }
        public string Status { get; set; }

        public DateTime Time { get; set; }
    }
}
