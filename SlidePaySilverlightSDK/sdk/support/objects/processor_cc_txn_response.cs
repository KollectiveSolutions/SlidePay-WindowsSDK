using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class processor_cc_txn_response
    {
        public int company_id { get; set; }
        public int location_id { get; set; }
        public int order_master_id { get; set; }
        public int payment_id { get; set; }
        public string stored_payment_guid { get; set; }
        public string method { get; set; }
        public string method_other { get; set; }
        public string cc_type { get; set; }
        public string cc_redacted_number { get; set; }
        public string cc_expiry_month { get; set; }
        public string cc_expiry_year { get; set; }
        public int cc_present { get; set; }
        public decimal amount { get; set; }
        public decimal fee_amount { get; set; }
        public string processor { get; set; }
        public bool is_approved { get; set; }
        public string status_code { get; set; }
        public string status_message { get; set; }
        public string transaction_state { get; set; }
        public string transaction_token { get; set; }
        public string payment_token { get; set; }
        public string approval_code { get; set; }
        public string capture_state { get; set; }
        public string batch_id { get; set; }
        public string notes { get; set; }
        public decimal? processor_time_ms { get; set; }
    }
}
