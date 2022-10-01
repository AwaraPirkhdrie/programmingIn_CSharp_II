using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Shark : Fish
    {
        private String Color;
        public Shark(UInt32 Maxspeed, UInt32 Maxdepth) : base(Maxspeed, Maxdepth)
        {
            this.Color = "Unknown";
        }
        public String color
        {
            get { return Color; }
            set { Color = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Color: " + " * " + Color;
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                        "Color: " + " * " + Color;
            return str_out;
        }      

    }
}
