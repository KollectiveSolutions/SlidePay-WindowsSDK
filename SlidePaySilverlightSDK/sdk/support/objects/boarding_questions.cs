using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class boarding_questions
    {
        public bool success { get; set; }
        public string failure_reason { get; set; }
        public string application_guid { get; set; }
        public string external_application_id { get; set; }
        public string questions_id { get; set; }
        public List<boarding_question> boarding_question_list { get; set; }  
    }
}
