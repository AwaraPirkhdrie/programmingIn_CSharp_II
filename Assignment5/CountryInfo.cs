using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public class CountryInfo : EventArgs
    {
        public string FlightId { get; set; }
        public DateTime TimeOfCommand { get; set; }
        public string CommandInfo { get; set; }
    }
}
