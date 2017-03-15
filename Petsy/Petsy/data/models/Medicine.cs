using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class Medicine
    {
        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int MedicineID { get; set; }
        public string m_Name { get; set; }
        public string m_Dose { get; set; }
        public string m_MiscInfo { get; set; }

        public Medicine()
        {
            //empty constructor
        }

        public Medicine(string name, string dose, string miscInfo)
        {
            m_Name = name;
            m_Dose = dose;
            m_MiscInfo = miscInfo;
        }
    }
}
