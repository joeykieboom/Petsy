using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class Diaries
    {
        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int DairyID { get; set; }
        public string d_OneLiner { get; set; }
        public string d_Location { get; set; }
        public string d_Time { get; set; }
        public string d_MiscInfo { get; set; }

        public Diaries()
        {
            //empty constructor
        }

        public Diaries(string oneLiner, string location, string time, string d_MiscInfo)
        {
            d_OneLiner = oneLiner;
            d_Location = location;
            d_Time = time;
            this.d_MiscInfo = d_MiscInfo;
        }
    }
}
