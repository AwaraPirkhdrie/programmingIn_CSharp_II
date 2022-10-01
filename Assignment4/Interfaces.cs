using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    // interface IAnimal
    interface IAnimal
    {
        string AnimName { get; set; }
        string AnimId { get; set; }
        GenderType AnimGender { get; set; }

        FoodSchedule GetFoodSchedule();
        string GetExtraInfo();
    }
    // interface IListManager
    interface IListManager<T>   
    {
        int Count { get; }
        bool Add(T type);
        bool ChangeAt(T type, int index);
        bool CheckIndex(int index);
        void DeleteAll();
        bool DeleteAt(int index);
        T GetAt(int index);
        //string[] ToStringArray();
        //List<string> ToStringList();

        void BinarySerialize(string FileName);
        void BinaryDeSerialize(string FileName);
        void XMLSerialize(string FileName);
        void XMLDeSerialize(string FileName);

    }
}