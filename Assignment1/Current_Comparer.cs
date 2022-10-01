using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Animal_Park
{
    class Current_Comparer : IComparer<Animal>
    {
        private int isort;
        public Current_Comparer()
        {   
            isort = 0;
        }
        public Current_Comparer(int i_Sort)
        {
            isort = i_Sort;
        }
        /// <summary>
        /// Compares 2 animals
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Animal x, Animal y)
        {
            int result_compare = 0;

            if ((x!=null) & (y!=null))
            {
                switch (isort) 
                {
                    case 0:              
                        result_compare = x.CompareTo_new(y,0);

                        break;
                    case 1:
                        
                        result_compare = x.CompareTo_new(y, 1);
                        break;
                    case 2:
                        result_compare = x.CompareTo_new(y, 2);
                        break;
                    case 3:
                        result_compare = x.CompareTo_new(y, 3);
                        break;

                    default:
                        result_compare = 0;
                        break;
                }

            }

            return result_compare;
        }
    }
}
