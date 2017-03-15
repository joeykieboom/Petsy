using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class Regels3
    {
        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey]
        public int PetID { get; set; }
        public int TaskID { get; set; }

        public Regels3 ()
        {
            //empty constructor
        }

        public Regels3 (int petID, int taskID)
        {
            PetID = petID;
            TaskID = taskID;
        }
    }
}
