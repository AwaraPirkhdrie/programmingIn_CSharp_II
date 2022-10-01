using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Shark : Fish
    {
        private String Color;
        private FoodSchedule foodSchedule;
        public Shark(UInt32 Maxspeed, UInt32 Maxdepth) : base(Maxspeed, Maxdepth)
        {
            this.Color = "Unknown";
            this.SetFoodSchedule();
        }
        public String color
        {
            get { return Color; }
            set { Color = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Color: " + " * " + Color;
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                        "Color: " + " * " + Color;
            return str_out;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Carnivore;
            foodSchedule.Add("Morning: Meat; ");
            foodSchedule.Add("Lunch: Fish; ");
            foodSchedule.Add("Evening: Bones, small fish; ");

        }   

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }

    }
}
