using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    class AirplanesCounter
    {
        private int N_started = 0;

        public void AddStart()
        {
            N_started++;
        }
        
        public void SubtractStart()
        {
            N_started--;
        }        

        /// <summary>
        /// Take off event handler (subscriber)
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CountTakeoffEvent(object sender, StartFlightInfo e)
        {
            AddStart();
        }

        /// <summary>
        /// Land Event handler
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CountLandEvent(object sender, CountryInfo e)
        {
            SubtractStart();
        }

        public int ReturnFlightcount()
        {
            return N_started;
        }
    }
}
