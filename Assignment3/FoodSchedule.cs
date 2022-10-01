using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    class FoodSchedule
    {
        //private EaterType eaterType;

        List<string> foodList;
        public int Count 
        {
            get {
                int count1 = 0;

                if (foodList != null)
                {
                    count1 = foodList.Count;
                }                 
                return count1; } 
        }
        public EaterType EaterType { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public FoodSchedule()
        {
            //eaterType = EaterType.Omnivore;
            foodList = new List<string>();
        }
        
        public void Add(string item)
        {
            foodList.Add(item);
         }
        /// <summary>
        /// Changes food string at given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        //public bool ChangeAt(int index, string item)
        //{
        //    bool changed_ok = false;
        //    return changed_ok;
        //}
        /// <summary>
        /// Check if index is within the food info string array bounds
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool CheckIndex(int index)
        {
            bool checked_index = false;
            if (index >= 0)
            {
                if (foodList != null)
                {
                    int n_rader = foodList.Count;
                    if (index <= n_rader - 1)
                    {
                        checked_index = true;
                    }
                }
            }

            return checked_index;
        }

        /// <summary>
        /// Returns string array with food info
        /// </summary>   
        /// <returns></returns>
        public string[] GetFoodListInfoStrings()
        {
            string[] str1 = new string[this.foodList.Count];
            int i = 0;
            foreach (string s in this.foodList)
            {
                str1[i] = s;
                i++;
            }
            return str1;
        }
        /// <summary>
        /// Return food title
        /// </summary>
        /// <returns></returns>
        public string Title()
        {
            return "Title";
        }
        /// <summary>
        /// Returns Food info as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Food Schedule String ";
        }

    }
}
