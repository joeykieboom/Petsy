using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class Regels1
    {
        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey]
        public int PetID { get; set; }

        public int FoodID { get; set; }

        public Regels1()
        {
            //empty constructor
        }

        public Regels1(int petID, int foodID)
        {
            PetID = petID;
            FoodID = foodID;
        }

    }
}
