using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class Regels4
    {
        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey]
        public int PetID { get; set; }
        public int DairyID { get; set; }

        public Regels4()
        {
            //empty constructor
        }
        public Regels4(int petID, int dairyID)
        {
            PetID = petID;
            DairyID = dairyID;
        }
    }
}
