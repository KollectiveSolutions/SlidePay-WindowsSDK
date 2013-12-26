using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class bank_account
    {
        public int? bank_account_id { get; set; }
        public int? company_id { get; set; }
        public int? location_id { get; set; }
        public int? is_verified { get; set; }
        public int? is_settlement_account { get; set; }
        public string name { get; set; } // NULLABLE
        public string description { get; set; } // NULLABLE
        public string type { get; set; }
        public string routing_number { get; set; }
        public string account_number { get; set; }
        public string account_company_name { get; set; } // NULLABLE
        public string account_first_name { get; set; } // NULLABLE
        public string account_last_name { get; set; } // NULLABLE
        public string account_address_1 { get; set; }
        public string account_address_2 { get; set; } // NULLABLE
        public string account_city { get; set; }
        public string account_state { get; set; }
        public string account_postal_code { get; set; }
        public string account_country { get; set; }
        public string account_phone_country_code { get; set; }
        public string account_phone { get; set; }
        public DateTime? created { get; set; } // NULLABLE
        public DateTime? last_update { get; set; } // NULLABLE    
    }
}
