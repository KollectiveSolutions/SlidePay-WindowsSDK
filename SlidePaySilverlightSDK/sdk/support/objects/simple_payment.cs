using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class simple_payment
    {
        public int? company_id { get; set; } // NULLABLE
        public int? location_id { get; set; } // NULLABLE
        public string method { get; set; }
        public string device_type { get; set; } // NULLABLE
        public string notes { get; set; }
        public decimal amount { get; set; }
        public string stored_payment_guid { get; set; }
        public string cc_type { get; set; }
        public string cc_number { get; set; }
        public string cc_expiry_month { get; set; }
        public string cc_expiry_year { get; set; }
        public string cc_billing_zip { get; set; }
        public string cc_cvv2 { get; set; }
        public string encryption_vendor { get; set; }
        public string encryption_ksn { get; set; }
        public string encryption_device_serial { get; set; }
        public string cc_track1data { get; set; }
        public string cc_track2data { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public bool quiet_mode { get; set; }
    }
}
