using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Crocodile : Reptile
    {
        private UInt32 Total_length;
        public Crocodile(UInt32 N_legs, Boolean Poison_bite) : base(N_legs, Poison_bite)
        {
            this.Total_length = 0;
        }
        public UInt32 total_length
        {
            get { return Total_length; }
            set { Total_length = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Total length: " + " * " + Total_length.ToString();
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Total length: " + " * " + Total_length.ToString();
            return str_out;
        }     

    }
}
    