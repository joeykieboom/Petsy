using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class Regels2
    {
        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey]
        public int PetID { get; set; }
        public int MedicineID { get; set; }

        public Regels2()
        {
            //empty constructor
        }

        public Regels2(int petID, int medicineID)
        {
            PetID = petID;
            MedicineID = medicineID;
        }
    }
}
