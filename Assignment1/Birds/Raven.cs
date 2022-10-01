using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Raven : Bird
    {
        private UInt32 N_claws;
        public Raven(UInt32 Maxspeed, String Habitat) : base(Maxspeed, Habitat)
        {
            this.N_claws = 0;
        }
        public UInt32 n_claws
        {
            get { return N_claws; }
            set { N_claws = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Number of claws : " + " * " + N_claws.ToString();
            return str_out;
        }

        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Number of claws : " + " " + N_claws.ToString();
            return str_out;
        }
       
    }
}
