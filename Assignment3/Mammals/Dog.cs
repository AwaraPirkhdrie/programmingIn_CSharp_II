using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Dog : Mammal
    {
        private String Breed;
        private FoodSchedule foodSchedule;

        public Dog(UInt32 Tail_Length, String Color) : base(Tail_Length, Color)
        {
            this.Breed = "NoBreed";
            this.SetFoodSchedule();
        }
        public String breed
        {
            get { return Breed; }
            set { Breed = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Breed: " + " * " + Breed;
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Breed: " + " * " + Breed;
            return str_out;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Carnivore;
            foodSchedule.Add("Morning: Meat; ");
            foodSchedule.Add("Lunch: Bones; ");
            foodSchedule.Add("Evening: Dry dog food; ");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
   