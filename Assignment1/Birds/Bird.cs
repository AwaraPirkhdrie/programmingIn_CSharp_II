using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    abstract class Bird : Animal, IAnimal
    {
        private UInt32 maxspeed;
        private String habitat;
        public Bird(UInt32 Maxspeed, String Habitat)
        {
            this.maxspeed = Maxspeed;
            this.habitat = Habitat;
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Max Flying Speed: " + " * " + maxspeed.ToString() + ";" +
                       "Habitat : " + " * " + habitat;
            return str_out;
        }

        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Max Flying Speed: " + " " + maxspeed.ToString() + ";" +
                       "Habitat : " + "  " + habitat;
            return str_out;
        }

    }
}
