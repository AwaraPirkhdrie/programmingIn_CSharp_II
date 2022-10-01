using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Turtle : Reptile
    {
        private Boolean Can_swim;
        public Turtle(UInt32 N_legs, Boolean Poison_bite) : base(N_legs, Poison_bite)
        {
            this.Can_swim = false;
        }
        public Boolean can_swim
        {
            get { return Can_swim; }
            set { Can_swim = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Can swim: " + " * " + Can_swim.ToString();
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Can swim: " + " * " + Can_swim.ToString();
            return str_out;
        }       

    }
}
   