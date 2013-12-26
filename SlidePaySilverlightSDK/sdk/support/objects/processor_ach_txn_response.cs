using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class processor_ach_txn_response
    {
        public int company_id { get; set; }
        public int location_id { get; set; }
        public int settlement_id { get; set; }
        public decimal amount { get; set; }
        public string provider { get; set; }
        public string routing_number { get; set; }
        public string account_number { get; set; }
        public bool is_approved { get; set; }
        public string provider_status { get; set; }
        public string provider_status_code { get; set; }
        public string provider_status_message { get; set; }
        public string provider_capture_state { get; set; }
        public string provider_transaction_state { get; set; }
        public string settlement_transaction_token { get; set; }
    }
}
