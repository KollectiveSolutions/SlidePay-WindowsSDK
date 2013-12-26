using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class manual_settlement
    {
        public int? company_id { get; set; }
        public int? location_id { get; set; }
        public List<manual_settlement_entry> settlement_list { get; set; }
        public string notes { get; set; }
    }
}
