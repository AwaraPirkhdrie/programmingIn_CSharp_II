using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Ant: Insect
    {
        private UInt32 Maxlifespan;
        public Ant(String Habitat, UInt32 N_legs, UInt32 N_wings) : base(Habitat, N_legs, N_wings)
        {
            this.Maxlifespan = 0;
        }
        public UInt32 maxlifespan
        {
            get { return Maxlifespan; }
            set { Maxlifespan = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Max life span: " + " * " + Maxlifespan.ToString();
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                        "Max life span: " + " * " + Maxlifespan.ToString();
            return str_out;
        }       
    }
}
