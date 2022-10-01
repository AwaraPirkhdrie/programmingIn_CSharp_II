using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class Butterfly : Insect
    {
        private UInt32 Wingbeat_frequency;
        private FoodSchedule foodSchedule;
        public Butterfly(String Habitat, UInt32 N_legs, UInt32 N_wings) : base(Habitat, N_legs, N_wings)
        {
            this.Wingbeat_frequency = 0;
            this.SetFoodSchedule();
        }
        public UInt32 wingbeat_frequency
        {
            get { return Wingbeat_frequency; }
            set { Wingbeat_frequency = value; }  
        }
        public override string ToString()
        {
            String str_out = base.ToString();
            str_out += ";" +
                       "Wing beat frequency: " + " * " + Wingbeat_frequency.ToString();
            return str_out;
        }
        public override string GetExtraInfo()
        {
            String str_out = base.GetExtraInfo();
            str_out += ";" +
                       "Wing beat frequency: " + " * " + Wingbeat_frequency.ToString();
            return str_out;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivore;
            foodSchedule.Add("Morning: Rise; ");
            foodSchedule.Add("Lunch: Mouse and gras; ");
            foodSchedule.Add("Evening: Seeds; ");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
