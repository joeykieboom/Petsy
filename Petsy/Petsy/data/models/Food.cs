using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class Food
    {

        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int FoodID { get; set; }
        public string f_Name { get; set; }
        public string f_Amount { get; set; }
        public string f_MiscInfo { get; set; }

        public Food()
        {
            //empty constructor
        }

        public Food(string name, string amount, string miscInfo)
        {
            f_Name = name;
            f_Amount = amount;
            f_MiscInfo = miscInfo;
        }
    }
}
