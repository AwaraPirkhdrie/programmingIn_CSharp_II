         using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park    
{
    [Serializable]
    class Owl : Bird
    {
        private String Pray;
        private FoodSchedule foodSchedule;
        public Owl(UInt32 Maxspeed, String Habitat) : base(Maxspeed, Habitat)
        {
            this.Pray = "Unknown";
            this.SetFoodSchedule();
        }
        public String pray
        {
            get { return Pray; }
            set { Pray = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Pray : " + " * " + Pray;
            return str_out;
        }

        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                        "Pray : " + " * " + Pray.ToString();
            return str_out;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            
            foodSchedule.EaterType = EaterType.Omnivore;
            foodSchedule.Add("Morning: Rise; ");
            foodSchedule.Add("Lunch: Mouse and gras; ");
            foodSchedule.Add("Evening: Seeds; ");
            foodSchedule.Add("Night: Bats; ");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }


    }
}
