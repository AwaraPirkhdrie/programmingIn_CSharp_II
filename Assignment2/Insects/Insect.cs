using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    abstract class Insect:Animal, IAnimal
    {
        private String habitat;
        private UInt32 n_legs;
        private UInt32 n_wings;

        public Insect(String Habitat, UInt32 N_legs, UInt32 N_wings)
        {
            this.habitat = Habitat;
            this.n_legs = N_legs;
            this.n_wings = N_wings;
        }
        public abstract override FoodSchedule GetFoodSchedule();
        public override string ToString()  
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Habitat: " + " * " + habitat + ";" +
                       "Number of legs: " + " * " + n_legs.ToString() + ";" +
                       "Number of wings : " + " * " + n_wings.ToString();
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Habitat: " + " * " + habitat + ";" +
                       "Number of legs: " + " * " + n_legs.ToString() + ";" +
                       "Number of wings : " + " * " + n_wings.ToString();
            return str_out;
        }
    }
}
