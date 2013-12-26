using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class account
    {
        public int? account_id { get; set; }
        public int? company_id { get; set; }
        public int? location_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string account_type { get; set; }
        public decimal? reserve_amount { get; set; }
        public DateTime? created { get; set; }
        public DateTime? last_update { get; set; }  
    }
}
