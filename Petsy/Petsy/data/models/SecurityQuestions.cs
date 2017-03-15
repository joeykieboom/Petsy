using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.data.models
{
    class SecurityQuestions
    {
        //The Id property is marked as the Primary Key  
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int QuestionID { get; set; }
        public string q_Question { get; set; }
        public string q_Answer { get; set; }

        public SecurityQuestions()
        {
            //empty constructor
        }

        public SecurityQuestions(string question, string anwser)
        {
            q_Question = question;
            q_Answer = anwser;
        }
    }
}
