using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    abstract class Reptile : Animal, IAnimal
    {
        private UInt32 n_legs;
        private Boolean poison_bite;

        public Reptile(UInt32 N_legs, Boolean Poison_bite)
        {
            this.n_legs = N_legs;
            this.poison_bite = Poison_bite;
        }
        public override string ToString()   
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Number of legs: " + " * " + n_legs.ToString() + ";" +
                       "Poison bite : " + " * " + poison_bite.ToString();
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Number of legs: " + " * " + n_legs.ToString() + ";" +
                       "Poison bite : " + " * " + poison_bite.ToString();
            return str_out;
        }

    }
}
