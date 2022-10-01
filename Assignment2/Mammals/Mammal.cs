using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    abstract class Mammal : Animal, IAnimal
    {
        private UInt32 taillength;
        private String color;

        public Mammal( UInt32 Tail_Length, String Color) 
        {
            this.taillength = Tail_Length;
            this.color = Color;
        }
        public abstract override FoodSchedule GetFoodSchedule();   
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Tail Length: " + " * " + taillength.ToString() + ";" +
                       "Color : " + " * " + color;
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Tail Length: " + " * " + taillength.ToString() + ";" +
                       "Color : " + " * " + color;
            return str_out;
        }


    }
}
