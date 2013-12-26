using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class account_report
    {
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public List<account_report_detail> report_detail { get; set; }
    }
}
