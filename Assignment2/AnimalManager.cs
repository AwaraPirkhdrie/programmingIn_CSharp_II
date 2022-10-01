using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace Animal_Park
{
    [Serializable]
    class AnimalManager: ListManager<Animal>
    {
        
        private Dictionary<int, int[]> Dict_AnimalFood = new Dictionary<int, int[]>();
        /// <summary>
        /// Checks if any food item connected to this animal id
        /// returns food id    
        /// </summary>
        /// <param name="anim_id"></param>
        /// <returns></returns>
        public int FoodItemConnected(int anim_id)
        {
            if (this.Dict_AnimalFood.Count > 0)
            {
                List<int> keysWithValue = this.Dict_AnimalFood.Where(keyv => keyv.Value.Contains(anim_id)).Select(kv => kv.Key).ToList();

                if (keysWithValue.Count > 0)
                {
                    return keysWithValue[0];
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Connects animal id to food item id
        /// </summary>
        /// <param name="food_id"></param>
        /// <param name="anim_id"></param>
        /// <returns></returns>
        public bool Connect_food_animal(int food_id, int anim_id)
        {
            if (this.Dict_AnimalFood.Count > 0)
            {
                List<int> keysWithValue = this.Dict_AnimalFood.Where(keyv => keyv.Value.Contains(anim_id)).Select(kv => kv.Key).ToList();

                if(keysWithValue.Count > 0)
                {
                    MessageBox.Show("This aminal already connected to a food item.");
                    return false;
                }

                if (this.Dict_AnimalFood.TryGetValue(food_id, out int[] test_array))
                {
                    int[] one_array = { anim_id };
                    var new_array = new int[test_array.Length + 1];
                    test_array.CopyTo(new_array, 0);
                    one_array.CopyTo(new_array, test_array.Length);
                    this.Dict_AnimalFood[food_id] = new_array;
                }
                else
                {
                    int[] new_array = { anim_id };
                    this.Dict_AnimalFood.Add(food_id, new_array);
                }
            }
            else
            {
                int[] new_array = { anim_id };
                this.Dict_AnimalFood.Add(food_id, new_array);
            }
            return true;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public AnimalManager()
        {
            
        }
        
        /// <summary>
        /// Returns string array with animal information
        /// </summary>
        /// <returns></returns>
        public string[] GetAnimalInfoStrings( )
        {
            string[] str_1 = new string[0];

            return str_1;
        }
        /// <summary>
        /// Saves Animal List to a Text file
        /// </summary>
        /// <param name="FileName"></param>
        public void Save_List_as_TextFile(string FileName)
        {
            if (this.Count > 0)
            {
                using (TextWriter writer = new StreamWriter(FileName))
                {
                    string str1;

                    for (int i = 0; i < this.Count; i++)
                    {
                        str1 = GetAt(i).ToString();
                        writer.WriteLine("Animal nr :" + i.ToString());
                        writer.WriteLine(str1);
                        writer.WriteLine("  ");
                    }

                }
                
            }

        }

    }
}
