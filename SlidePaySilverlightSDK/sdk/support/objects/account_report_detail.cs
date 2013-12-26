using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class account_report_detail
    {
        public int? company_id { get; set; }
        public string company_name { get; set; }
        public int? location_id { get; set; }
        public string location_name { get; set; }
        public int? account_id { get; set; }
        public string account_name { get; set; }

        public account account_record { get; set; }
        public account_ledger account_balance { get; set; }

        public decimal commit_balance { get; set; }
        public decimal reserve_amount { get; set; }
        public decimal available_balance { get; set; }
        public decimal pending_credits { get; set; }
        public decimal pending_debits { get; set; }
        public decimal pending_net { get; set; }
        public decimal pending_balance { get; set; }

        public int num_txn_commit { get; set; }
        public int num_txn_pending { get; set; }
        public List<account_ledger> entries { get; set; }
    }
}
