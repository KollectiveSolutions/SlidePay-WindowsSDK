using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class report_request
    {
        public string email_address { get; set; }
        public bool html { get; set; }
        public bool raw_data { get; set; }
        public bool csv { get; set; }
        public search_filter[] sfa { get; set; }
    }
}
