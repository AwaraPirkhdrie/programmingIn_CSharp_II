using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    abstract class Fish : Animal, IAnimal
    {
        private UInt32 maxspeed;
        private UInt32 maxdepth;

        public Fish(UInt32 Maxspeed, UInt32 Maxdepth)
        {
            this.maxspeed = Maxspeed;
            this.maxdepth = Maxdepth;   
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Max speed: " + " * " + maxspeed.ToString() + ";" +
                       "Max depth: " + " * " + maxdepth.ToString();
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Max speed: " + " * " + maxspeed.ToString() + ";" +
                       "Max depth: " + " * " + maxdepth.ToString();
            return str_out;
        }

    }
}
