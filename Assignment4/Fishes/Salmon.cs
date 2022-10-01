using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Salmon : Fish
    {
        private String Origin;
        private FoodSchedule foodSchedule;
        public Salmon(UInt32 Maxspeed, UInt32 Maxdepth) : base(Maxspeed, Maxdepth)
        {
            this.Origin = "Unknown";
            this.SetFoodSchedule();
        }
        public String origin
        {
            get { return Origin; }
            set { Origin = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Origin: " + " * " + Origin;
            return str_out;
        }

        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                        "Origin: " + " * " + Origin;
            return str_out;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivore;
            foodSchedule.Add("Morning: Scramples; ");
            foodSchedule.Add("Lunch: Sea gras; ");
            foodSchedule.Add("Evening: Seeds, worms; ");

        }
        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
   