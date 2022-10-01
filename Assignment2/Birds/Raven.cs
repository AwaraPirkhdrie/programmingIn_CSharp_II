using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Raven : Bird
    {
        private UInt32 N_claws;
        private FoodSchedule foodSchedule;
        public Raven(UInt32 Maxspeed, String Habitat) : base(Maxspeed, Habitat)
        {
            this.N_claws = 0;
            this.SetFoodSchedule();
        }
        public UInt32 n_claws
        {
            get { return N_claws; }
            set { N_claws = value; }
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Number of claws : " + " * " + N_claws.ToString();
            return str_out;
        }

        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Number of claws : " + " " + N_claws.ToString();
            return str_out;
        }
        private void SetFoodSchedule()
        {   
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivore;
            foodSchedule.Add("Morning: Oats; ");
            foodSchedule.Add("Lunch: Mouse; ");
            foodSchedule.Add("Evening: Any grains; ");

        }
        public override FoodSchedule GetFoodSchedule()
        {
            return this.foodSchedule;
        }
    }
}
