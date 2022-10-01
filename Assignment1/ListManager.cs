using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    [Serializable]
    public class ListManager<T>:IListManager<T>
    {
        private List<T> aList = new List<T>();
        /// <summary>
        /// Returns cont of all elements in the list
        /// </summary>
        public int Count
        {
            get { return aList.Count; }
        }    
        /// <summary>
        /// Adds element to a list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(T item)
        {
            bool ok = true;
            if (item != null)
            {
                aList.Add(item);
            }
            else
            {
                ok = false;
            }
            return ok;
        }
        /// <summary>
        /// Changes element at given index to a provided new element
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ChangeAt(T item, int index)
        {
            bool ok = true;
            if ((item != null)&(index >= 0) & (index <= aList.Count - 1))
            {
                aList[index] = item;
            }
            else
            {
                ok = false;
            }
            return ok;
        }
        /// <summary>
        /// Checks if index is within the list bouds
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool CheckIndex( int index)
        {
            bool ok;
            if ((index >= 0) & (index <= aList.Count - 1))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }
        /// <summary>
        /// Deletes element
        /// </summary>
        public void DeleteAll()
        {
            aList.Clear();
        }
        /// <summary>
        /// Returns element at given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetAt(int index)
        {
            if (CheckIndex(index))
            {
                return aList[index];
            }
            return default(T);
        }
        /// <summary>
        /// Deletes element at given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteAt(int index)
        {
            if (CheckIndex(index))
            {
                aList.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Method to sort animal list or any other list
        /// </summary>
        /// <param name="Sorting_metod"></param>
        public void Sort_any_List(IComparer<T> Sorting_metod)
        {
            this.aList.Sort(Sorting_metod);

            return;
        }
        /// <summary>
        /// Calls Serialize for binary format
        /// </summary>
        /// <param name="FileName"></param>
        public void BinarySerialize(string FileName)
        {
            Utility_file_handlers.Serialize_bin(this.aList, FileName);
        }
        /// <summary>
        /// Calls De-Serialize for binary format
        /// </summary>
        /// <param name="FileName"></param>
        public void BinaryDeSerialize(string FileName)
        {
            this.aList = Utility_file_handlers.Deserialize_bin<List<T>>(FileName);
        }
        /// <summary>
        /// Calls Serialize for XML format
        /// </summary>
        /// <param name="FileName"></param>
        public void XMLSerialize(string FileName)
        {
            Utility_file_handlers.Serialize_xml(this.aList, FileName);
        }
        /// <summary>
        /// Calls De-Serialize for XML format
        /// </summary>
        /// <param name="FileName"></param>
        public void XMLDeSerialize(string FileName)
        {
            this.aList = Utility_file_handlers.Deserialize_xml<List<T>>(FileName);
        }

    }
   
}
