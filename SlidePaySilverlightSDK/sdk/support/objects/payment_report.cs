using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class payment_report
    {
        public string company_name { get; set; }
        public string location_name { get; set; }
        public string user_first_name { get; set; }
        public string user_last_name { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }

        public string sales { get; set; }
        public string tips { get; set; }
        public string refunds { get; set; }
        public string fees { get; set; }
        public string net { get; set; }

        public string fees_credit { get; set; }
        public string fees_visa { get; set; }
        public string fees_mc { get; set; }
        public string fees_discover { get; set; }
        public string fees_amex { get; set; }
        public string fees_other { get; set; }

        public int num_txn { get; set; }
        public int num_txn_sales { get; set; }
        public int num_txn_refunds { get; set; }
        public decimal avg_txn_size { get; set; }

        public int num_txn_cash { get; set; }
        public int num_txn_cash_sales { get; set; }
        public int num_txn_cash_tips { get; set; }
        public int num_txn_cash_refunds { get; set; }
        public int num_txn_credit { get; set; }
        public int num_txn_credit_sales { get; set; }
        public int num_txn_credit_tips { get; set; }
        public int num_txn_credit_refunds { get; set; }
        public int num_txn_coupon { get; set; }
        public int num_txn_coupon_sales { get; set; }
        public int num_txn_coupon_tips { get; set; }
        public int num_txn_coupon_refunds { get; set; }
        public int num_txn_gift_certificate { get; set; }
        public int num_txn_gift_certificate_sales { get; set; }
        public int num_txn_gift_certificate_tips { get; set; }
        public int num_txn_gift_certificate_refunds { get; set; }
        public int num_txn_check { get; set; }
        public int num_txn_check_sales { get; set; }
        public int num_txn_check_tips { get; set; }
        public int num_txn_check_refunds { get; set; }
        public int num_txn_deal_redemption { get; set; }
        public int num_txn_deal_redemption_sales { get; set; }
        public int num_txn_deal_redemption_tips { get; set; }
        public int num_txn_deal_redemption_refunds { get; set; }
        public int num_txn_other { get; set; }
        public int num_txn_other_sales { get; set; }
        public int num_txn_other_tips { get; set; }
        public int num_txn_other_refunds { get; set; }

        public int num_txn_cc_visa { get; set; }
        public int num_txn_cc_visa_sales { get; set; }
        public int num_txn_cc_visa_tips { get; set; }
        public int num_txn_cc_visa_refunds { get; set; }
        public int num_txn_cc_mc { get; set; }
        public int num_txn_cc_mc_sales { get; set; }
        public int num_txn_cc_mc_tips { get; set; }
        public int num_txn_cc_mc_refunds { get; set; }
        public int num_txn_cc_amex { get; set; }
        public int num_txn_cc_amex_sales { get; set; }
        public int num_txn_cc_amex_tips { get; set; }
        public int num_txn_cc_amex_refunds { get; set; }
        public int num_txn_cc_discover { get; set; }
        public int num_txn_cc_discover_sales { get; set; }
        public int num_txn_cc_discover_tips { get; set; }
        public int num_txn_cc_discover_refunds { get; set; }
        public int num_txn_cc_other { get; set; }
        public int num_txn_cc_other_sales { get; set; }
        public int num_txn_cc_other_tips { get; set; }
        public int num_txn_cc_other_refunds { get; set; }

        public string cash_sales { get; set; }
        public string cash_tips { get; set; }
        public string cash_refunds { get; set; }
        public string cash_net { get; set; }
        public string credit_sales { get; set; }
        public string credit_tips { get; set; }
        public string credit_refunds { get; set; }
        public string credit_net { get; set; }
        public string coupon_sales { get; set; }
        public string coupon_tips { get; set; }
        public string coupon_refunds { get; set; }
        public string coupon_net { get; set; }
        public string gift_certificate_sales { get; set; }
        public string gift_certificate_tips { get; set; }
        public string gift_certificate_refunds { get; set; }
        public string gift_certificate_net { get; set; }
        public string check_sales { get; set; }
        public string check_tips { get; set; }
        public string check_refunds { get; set; }
        public string check_net { get; set; }
        public string deal_redemption_sales { get; set; }
        public string deal_redemption_tips { get; set; }
        public string deal_redemption_refunds { get; set; }
        public string deal_redemption_net { get; set; }
        public string other_sales { get; set; }
        public string other_tips { get; set; }
        public string other_refunds { get; set; }
        public string other_net { get; set; }

        public string cc_visa_sales { get; set; }
        public string cc_visa_tips { get; set; }
        public string cc_visa_refunds { get; set; }
        public string cc_visa_net { get; set; }
        public string cc_mc_sales { get; set; }
        public string cc_mc_tips { get; set; }
        public string cc_mc_refunds { get; set; }
        public string cc_mc_net { get; set; }
        public string cc_amex_sales { get; set; }
        public string cc_amex_tips { get; set; }
        public string cc_amex_refunds { get; set; }
        public string cc_amex_net { get; set; }
        public string cc_discover_sales { get; set; }
        public string cc_discover_tips { get; set; }
        public string cc_discover_refunds { get; set; }
        public string cc_discover_net { get; set; }
        public string cc_other_sales { get; set; }
        public string cc_other_tips { get; set; }
        public string cc_other_refunds { get; set; }
        public string cc_other_net { get; set; }

        public List<payment_report_detail> payment_list { get; set; }
    }
}
