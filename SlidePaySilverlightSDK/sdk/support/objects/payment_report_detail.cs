using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class payment_report_detail
    {
        public int payment_id { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public int location_id { get; set; }
        public string location_name { get; set; }
        public int user_master_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int order_master_id { get; set; }
        public string method { get; set; }
        public string cc_type { get; set; }
        public int cc_present { get; set; }
        public string cc_redacted_number { get; set; }
        public decimal amount { get; set; }
        public decimal tip_amount { get; set; }
        public int is_refund { get; set; }
        public int refund_payment_id { get; set; }
        public decimal fee_total { get; set; }
        public string settlement_transaction_token { get; set; }
        public string provider_capture_state { get; set; }
        public DateTime created { get; set; }
    }
}
