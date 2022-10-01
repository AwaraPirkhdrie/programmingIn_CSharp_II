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
        private FoodSchedule foodSchedule;

        public Cat (UInt32 Tail_Length, String Color) : base(Tail_Length, Color)
        {
            this.Fluffy = false;
            this.SetFoodSchedule();
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
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Carnivore;
            foodSchedule.Add("Morning: Fish; ");
            foodSchedule.Add("Lunch 1: Mouse; ");
            foodSchedule.Add("Lunch 2: Dry cat food; ");
            foodSchedule.Add("Evening: Chicken; ");
            foodSchedule.Add("Night: Milk; ");

        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                        "Is Fluffy: " + " * " + Fluffy.ToString();
            return str_out;
        }
        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
