using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class Tasks
    {
        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int TaskID { get; set; }
        public string t_Name { get; set; }
        public DateTime t_DateTime { get; set; }
        public string t_Description { get; set; }
        public string t_RepeatTime { get; set; }
        public string t_Completed { get; set; }

        public Tasks()
        {
            //empty constructor
        }

        public Tasks(string name, DateTime dateTime, string description, string repeatTime, string completed)
        {
            t_Name = name;
            t_DateTime = dateTime;
            t_Description = description;
            t_RepeatTime = repeatTime;
            t_Completed = completed;
        }
    }
}
