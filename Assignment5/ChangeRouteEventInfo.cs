using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public class ChangeRouteEventInfo : EventArgs
    {
        public int heading { get; set; }

        public string FlightId { get; set; }
        public DateTime TimeOfCommand { get; set; }
        public string Command_Info { get; set; }

    }
}
