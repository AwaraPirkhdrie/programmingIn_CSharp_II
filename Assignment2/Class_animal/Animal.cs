using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    abstract class Animal: IAnimal, IComparable
    {
        private UInt32 ID;  
        private string StrID;
        private String Name;
        private UInt32 Age;
        private GenderType Gender;
        private CategoryType Category;
        private double Weight;
        private String Behaviour;

        public Animal()
        {
            this.ID = 0;
            this.Name = "Noname";
            this.Age = 0;
            //this.Category = CategoryType.Mammal;
            this.Gender = GenderType.Unknown;
            this.Weight = 0;
            this.Behaviour = "Unknown";
        }
        public string AnimName
        {
            get { return this.Name; }
            set
            {
                Name = value;
            }
        }
        public GenderType AnimGender
        {
            get { return this.Gender; }
            set
            {
                Gender = GenderType.Unknown;
            }
        }
        public abstract FoodSchedule GetFoodSchedule();

        public string AnimId
        {
            get { return this.StrID; }
            set
            {
                StrID = "M_000";
            }
        }

        public virtual string GetExtraInfo() 
        {
            string strOut; 
            strOut = string.Format("{0,-15} {1, 10}\n", "Category:", category.ToString()); 
            return strOut; 
        }

        public UInt32 id
        {
            get { return ID; }
            set { ID = value; }
        }
        public String name
        {
            get { return Name; }
            set { Name = value; }
        }
        public GenderType gender
        {
            get { return Gender; }
            set { Gender = value;}
        }
        public UInt32 age
        {
            get { return Age; }
            set { Age = value; }
        }
        public CategoryType category
        {
            get { return Category; }
            set { Category = value; }
        }
        public double weight
        {
            get { return Weight; }
            set { Weight = value; }
        }
        public String behavior
        {
            get { return Behaviour; }
            set { Behaviour = value; }
        }

        public override string ToString()
        {
            String str_out = "ID : " + " * " + ID.ToString() + ";" +
                "Name: " + " * " + Name + ";" +
                "Age: " + " * " + Age.ToString() + "; " +
                "Gender: " + " * " + Gender.ToString() + ";" +
                "Category: " + " * " + Category.ToString() + ";" +
                "Weight: " + " * " + Weight.ToString() + ";" +
                "Behaviour: " + " * " + Behaviour;

            return str_out;
        }

        /// <summary>
        ///  Compares Animal objects according to default rule
        /// </summary>
        /// <param name="compareAnim"></param>
        /// <param name="i"></param>
        public int CompareTo(object compareAnim)
        {
            return compareAnim == null ? 1 : this.name.ToString().CompareTo(((Animal)compareAnim).name.ToString());
        }

        /// <summary>
        ///  Compares Animal objects according to a new rule
        /// </summary>
        /// <param name="compareAnim"></param>
        /// <param name="i"></param>
        public int CompareTo_new(object compareAnim,int i)
        {
            int compared = 0;
            switch (i)
            {
                case 0:
                    compared = compareAnim == null ? 1 : this.id.ToString().CompareTo(((Animal)compareAnim).id.ToString());

                    break;
                case 1:
                    compared = compareAnim == null ? 1 : this.name.ToString().CompareTo(((Animal)compareAnim).name.ToString());
                    break;
                case 2:
                    compared = compareAnim == null ? 1 : this.age.ToString().CompareTo(((Animal)compareAnim).age.ToString());
                    break;
                case 3:
                    compared = compareAnim == null ? 1 : this.gender.ToString().CompareTo(((Animal)compareAnim).gender.ToString());
                    break;

                default:
                    break;
            }
            return compared;
        } 
    }
}