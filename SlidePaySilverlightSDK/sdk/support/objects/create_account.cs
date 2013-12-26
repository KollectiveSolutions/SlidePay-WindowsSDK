using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class create_account
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string company_name { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; } // NULLABLE
        public string address_3 { get; set; } // NULLABLE
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string phone_country_code { get; set; } // NULLABLE
        public string phone { get; set; }
        public string phone_ext { get; set; } // NULLABLE
        public string homepage { get; set; }
        public string business_type { get; set; }
        public string business_type_other { get; set; } // NULLABLE
        public string mcc { get; set; }
        public string tax_id { get; set; }
        public string lead_source { get; set; } // NULLABLE
        public string referral_id { get; set; } // NULLABLE
        public string referrer_id { get; set; } // NULLABLE
        public string device_type { get; set; } // NULLABLE
        public string timezone { get; set; } // NULLABLE
        public decimal tax_rate { get; set; }
        public string vendor_id { get; set; } // NULLABLE
        public decimal? vendor_markup_percent { get; set; } // NULLABLE
        public decimal? vendor_markup_pertrans { get; set; } // NULLABLE
        public bool enable_quiet_mode { get; set; }
        public bool enable_all_email_prefs { get; set; }
        public string source_ip { get; set; } // NULLABLE
        public string latitude { get; set; } // NULLABLE
        public string longitude { get; set; } // NULLABLE
    }
}
