using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class Pets
    {
        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int PetID { get; set; }
        public string p_Name { get; set; }
        public int p_Age { get; set; }
        public string p_Gender { get; set; }
        public int p_Weight { get; set; }
        public string p_MiscInfo { get; set; }
        public string p_Picture { get; set; }

        //        public int p_FoodId { get; set; }S
        //        public int p_MedicineId { get; set; }

        public Pets()
        {
            //empty constructor  
        }
        public Pets(string name, int age, string gender, int weight, string miscInfo)
        {
            p_Name = name;
            p_Age = age;
            p_Gender = gender;
            p_Weight = weight;
            p_MiscInfo = miscInfo;
        }
    }
}
