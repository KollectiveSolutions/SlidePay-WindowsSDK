using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class account_ledger
    {
        public int? account_ledger_id { get; set; }
        public int? account_id { get; set; }
        public int? company_id { get; set; }
        public int? location_id { get; set; }
        public string reference_guid { get; set; }
        public string entry_type { get; set; }
        public string transaction_status { get; set; }
        public decimal? credit_amount { get; set; }
        public decimal? debit_amount { get; set; }
        public decimal? balance { get; set; }
        public string description { get; set; }
        public int? ledgered { get; set; }
        public DateTime? created { get; set; }
        public DateTime? last_update { get; set; }
    }
}
