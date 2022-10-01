using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    public class Food_Item
    {
        //private ListManager<string> ingredients;
        private List<string> ingredients;
        private string name;

        public List<string> Ingredients
        {
            get { return this.ingredients; }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                name = value;
            }
        }
        //public Food_Item()
        //{
        //    this.ingredients = new ListManager<string>();
        //    this.name = "test name";
        //}
        public Food_Item()
        {
            this.ingredients = new List<string>();
            this.name = "test name";
        }

        public override string ToString()
        {
            String str_out = "test food item";

            str_out = this.name + " ; ";

            for(int i= 0; i < Ingredients.Count; i++)
            {
                //str_out = str_out + Ingredients.GetAt(i) + " ; ";
                str_out = str_out + Ingredients[i]  + " ; ";
            }   

            return str_out;
        }
        public string[] ToStringArray()
        {
            string[] str_array = new string[Ingredients.Count + 1];
            str_array[0] = this.Name;
            for (int i = 1; i < Ingredients.Count+1; i++)
            {
                //str_array[i] = Ingredients.GetAt(i-1) + " ; ";
                str_array[i] = Ingredients[i - 1] + " ; ";
            }
            return str_array;
        }
    }
}
