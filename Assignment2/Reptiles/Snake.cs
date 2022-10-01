using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Snake : Reptile
    {
        private String Snake_family;
        private FoodSchedule foodSchedule;

        public Snake(UInt32 N_legs, Boolean Poison_bite) : base(N_legs, Poison_bite)
        {
            this.Snake_family = "Unknown";
            this.SetFoodSchedule();
        }
        public String snake_family
        {
            get { return Snake_family; }
            set { Snake_family = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Snake family: " + " * " + Snake_family;
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Snake family: " + " * " + Snake_family;
            return str_out;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivore;
            foodSchedule.Add("Morning: Gras; ");
            foodSchedule.Add("Lunch: Mouse and gras; ");
            foodSchedule.Add("Evening: Milk; ");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
   