using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class stored_payment
    {
        public int? stored_payment_id { get; set; }
        public int? company_id { get; set; }
        public int? location_id { get; set; }
        public int? customer_id { get; set; } // NULLABLE
        public string guid { get; set; } // NULLABLE
        public string method { get; set; }
        public string method_other { get; set; } // NULLABLE
        public string cc_type { get; set; } // NULLABLE
        public string cc_number { get; set; } // NULLABLE
        public string cc_redacted_number { get; set; } // NULLABLE
        public string cc_expiry_month { get; set; } // NULLABLE
        public string cc_expiry_year { get; set; } // NULLABLE
        public string cc_name_on_card { get; set; } // NULLABLE
        public string cc_address_1 { get; set; } // NULLABLE
        public string cc_address_2 { get; set; } // NULLABLE
        public string cc_address_3 { get; set; } // NULLABLE
        public string cc_city { get; set; } // NULLABLE
        public string cc_state { get; set; } // NULLABLE
        public string cc_billing_zip { get; set; } // NULLABLE
        public string cc_country { get; set; } // NULLABLE
        public DateTime? created { get; set; } // NULLABLE
        public DateTime? last_update { get; set; } // NULLABLE
    }
}
