using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Cat : Mammal
    {
        private bool Fluffy;
        public Cat (UInt32 Tail_Length, String Color) : base(Tail_Length, Color)
        {
            this.Fluffy = false;
        }    
        public bool fluffy
        {
            get { return Fluffy; }
            set { Fluffy = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Is Fluffy: " + " * " + Fluffy.ToString();
            return str_out;
        }       
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                        "Is Fluffy: " + " * " + Fluffy.ToString();
            return str_out;
        }        
    }
}
