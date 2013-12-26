using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public payment_report sp_payment_report(int location_id, DateTime start_time, DateTime end_time)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_payment_report null value detected for token, please authenticate", true);
                return null;
            }

            if (location_id <= 0)
            {
                log("sp_payment_report location_id must be greater than zero", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response get_payment_report_rest_resp = new rest_response();
            response get_payment_report_resp = new response();
            payment_report ret = new payment_report();
            search_filter sf = new search_filter();
            List<search_filter> sf_list = new List<search_filter>();
            report_request report_req = new report_request();

            #endregion

            #region Build-Report-Request

            sf = new search_filter();
            sf.field = "location_id";
            sf.condition = "equals";
            sf.value = location_id.ToString();
            sf_list.Add(sf);

            sf = new search_filter();
            sf.field = "created";
            sf.condition = "greater_than";
            sf.value = start_time.ToString("MM/dd/yyyy hh:mm:ss tt");
            sf_list.Add(sf);

            sf = new search_filter();
            sf.field = "created";
            sf.condition = "less_than";
            sf.value = end_time.ToString("MM/dd/yyyy hh:mm:ss tt");
            sf_list.Add(sf);

            report_req.csv = false;
            report_req.email_address = null;
            report_req.html = false;
            report_req.raw_data = true;
            report_req.sfa = sf_list.ToArray();

            #endregion

            #region Process-Request

            get_payment_report_rest_resp = rest_client<report_request>(
                _endpoint_url + "report/payment",
                "POST",
                null,
                report_req);

            if (get_payment_report_rest_resp == null)
            {
                log("sp_payment_report null response from rest_client for payment report retrieval call", true);
                return null;
            }

            if (get_payment_report_rest_resp.status_code != 200)
            {
                log("sp_payment_report rest_client returned status other than 200 for payment report retrieval call", true);
                return null;
            }

            try
            {
                get_payment_report_resp = deserialize_json<response>(get_payment_report_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_payment_report unable to deserialize response from server for payment report retrieval call", true);
                return null;
            }

            if (!get_payment_report_resp.success)
            {
                log("sp_payment_report success false returned from server for bank_account retrieval call", true);
                return null;
            }

            try
            {
                ret = deserialize_json<payment_report>(get_payment_report_resp.data.ToString());
                log("sp_payment_report response retrieved");
            }
            catch (Exception)
            {
                log("sp_payment_report unable to deserialize bank_account list object", true);
                return null;
            }

            if (ret == null)
            {
                log("sp_payment_report null payment report retrieved", true);
                return null;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("payment_report retrieved: ");
            log("  " + ret.company_name + " / " + ret.location_name);
            log("  " + ret.start_time + " to " + ret.end_time);
            log("-------------------------------------------------------------------------------");
            log("  sales: " + ret.sales + "  tips: " + ret.tips);
            log("  refunds: " + ret.refunds + "  fees: " + ret.fees);
            log("  net: " + ret.net);
            log("-------------------------------------------------------------------------------");
            log("  fees_credit: " + ret.fees_credit + "  fees_visa: " + ret.fees_visa);
            log("  fees_mc: " + ret.fees_mc + "  fees_discover: " + ret.fees_discover);
            log("  fees_amex: " + ret.fees_amex + "  fees_other: " + ret.fees_other);
            log("-------------------------------------------------------------------------------");
            log("  num_txn: " + ret.num_txn + "  num_txn_sales: " + ret.num_txn_sales);
            log("  num_txn_refunds: " + ret.num_txn_refunds + "  avg_txn_size: " + ret.avg_txn_size);
            log("  cash:");
            log("    num_txn_cash: " + ret.num_txn_cash + "  num_txn_cash_sales: " + ret.num_txn_cash_sales);
            log("    num_txn_cash_tips: " + ret.num_txn_cash_tips + "  num_txn_cash_refunds: " + ret.num_txn_cash_refunds);
            log("    cash_sales: " + ret.cash_sales + "  cash_tips: " + ret.cash_tips);
            log("    cash_refunds: " + ret.cash_refunds + "  cash_net: " + ret.cash_net);
            log("  credit:");
            log("    num_txn_credit: " + ret.num_txn_credit + "  num_txn_credit_sales: " + ret.num_txn_credit_sales);
            log("    num_txn_credit_tips: " + ret.num_txn_credit_tips + "  num_txn_credit_refunds: " + ret.num_txn_credit_refunds);
            log("    credit_sales: " + ret.credit_sales + "  credit_tips: " + ret.credit_tips);
            log("    credit_refunds: " + ret.credit_refunds + "  credit_net: " + ret.credit_net);
            log("    credit/visa:");
            log("      num_txn_cc_visa: " + ret.num_txn_cc_visa + "  num_txn_cc_visa_sales: " + ret.num_txn_cc_visa_sales);
            log("      num_txn_cc_visa_tips: " + ret.num_txn_cc_visa_tips + "  num_txn_cc_visa_refunds: " + ret.num_txn_cc_visa_refunds);
            log("      cc_visa_sales: " + ret.cc_visa_sales + "  cc_visa_tips: " + ret.cc_visa_tips);
            log("      cc_visa_refunds: " + ret.cc_visa_refunds + "  cc_visa_net: " + ret.cc_visa_net);
            log("    credit/mc:");
            log("      num_txn_cc_mc: " + ret.num_txn_cc_mc + "  num_txn_cc_mc_sales: " + ret.num_txn_cc_mc_sales);
            log("      num_txn_cc_mc_tips: " + ret.num_txn_cc_mc_tips + "  num_txn_cc_mc_refunds: " + ret.num_txn_cc_mc_refunds);
            log("      cc_mc_sales: " + ret.cc_mc_sales + "  cc_mc_tips: " + ret.cc_mc_tips);
            log("      cc_mc_refunds: " + ret.cc_mc_refunds + "  cc_mc_net: " + ret.cc_mc_net);
            log("    credit/amex:");
            log("      num_txn_cc_amex: " + ret.num_txn_cc_amex + "  num_txn_cc_amex_sales: " + ret.num_txn_cc_amex_sales);
            log("      num_txn_cc_amex_tips: " + ret.num_txn_cc_amex_tips + "  num_txn_cc_amex_refunds: " + ret.num_txn_cc_amex_refunds);
            log("      cc_amex_sales: " + ret.cc_amex_sales + "  cc_amex_tips: " + ret.cc_amex_tips);
            log("      cc_amex_refunds: " + ret.cc_amex_refunds + "  cc_amex_net: " + ret.cc_amex_net);
            log("    credit/discover:");
            log("      num_txn_cc_discover: " + ret.num_txn_cc_discover + "  num_txn_cc_discover_sales: " + ret.num_txn_cc_discover_sales);
            log("      num_txn_cc_discover_tips: " + ret.num_txn_cc_discover_tips + "  num_txn_cc_discover_refunds: " + ret.num_txn_cc_discover_refunds);
            log("      cc_discover_sales: " + ret.cc_discover_sales + "  cc_discover_tips: " + ret.cc_discover_tips);
            log("      cc_discover_refunds: " + ret.cc_discover_refunds + "  cc_discover_net: " + ret.cc_discover_net);
            log("    credit/other:");
            log("      num_txn_cc_other: " + ret.num_txn_cc_other + "  num_txn_cc_other_sales: " + ret.num_txn_cc_other_sales);
            log("      num_txn_cc_other_tips: " + ret.num_txn_cc_other_tips + "  num_txn_cc_other_refunds: " + ret.num_txn_cc_other_refunds);
            log("      cc_other_sales: " + ret.cc_other_sales + "  cc_other_tips: " + ret.cc_other_tips);
            log("      cc_other_refunds: " + ret.cc_other_refunds + "  cc_other_net: " + ret.cc_other_net);
            log("  coupon:");
            log("    num_txn_coupon: " + ret.num_txn_coupon + "  num_txn_coupon_sales: " + ret.num_txn_coupon_sales);
            log("    num_txn_coupon_tips: " + ret.num_txn_coupon_tips + "  num_txn_coupon_refunds: " + ret.num_txn_coupon_refunds);
            log("    coupon_sales: " + ret.coupon_sales + "  coupon_tips: " + ret.coupon_tips);
            log("    coupon_refunds: " + ret.coupon_refunds + "  coupon_net: " + ret.coupon_net);
            log("  gift_certificate:");
            log("    num_txn_gift_certificate: " + ret.num_txn_gift_certificate + "  num_txn_gift_certificate_sales: " + ret.num_txn_gift_certificate_sales);
            log("    num_txn_gift_certificate_tips: " + ret.num_txn_gift_certificate_tips + "  num_txn_gift_certificate_refunds: " + ret.num_txn_gift_certificate_refunds);
            log("    gift_certificate_sales: " + ret.gift_certificate_sales + "  gift_certificate_tips: " + ret.gift_certificate_tips);
            log("    gift_certificate_refunds: " + ret.gift_certificate_refunds + "  gift_certificate_net: " + ret.gift_certificate_net);
            log("  check:");
            log("    num_txn_check: " + ret.num_txn_check + "  num_txn_check_sales: " + ret.num_txn_check_sales);
            log("    num_txn_check_tips: " + ret.num_txn_check_tips + "  num_txn_check_refunds: " + ret.num_txn_check_refunds);
            log("    check_sales: " + ret.check_sales + "  check_tips: " + ret.check_tips);
            log("    check_refunds: " + ret.check_refunds + "  check_net: " + ret.check_net);
            log("  deal_redemption:");
            log("    num_txn_deal_redemption: " + ret.num_txn_deal_redemption + "  num_txn_deal_redemption_sales: " + ret.num_txn_deal_redemption_sales);
            log("    num_txn_deal_redemption_tips: " + ret.num_txn_deal_redemption_tips + "  num_txn_deal_redemption_refunds: " + ret.num_txn_deal_redemption_refunds);
            log("    deal_redemption_sales: " + ret.deal_redemption_sales + "  deal_redemption_tips: " + ret.deal_redemption_tips);
            log("    deal_redemption_refunds: " + ret.deal_redemption_refunds + "  deal_redemption_net: " + ret.deal_redemption_net);
            log("  other:");
            log("    num_txn_other: " + ret.num_txn_other + "  num_txn_other_sales: " + ret.num_txn_other_sales);
            log("    num_txn_other_tips: " + ret.num_txn_other_tips + "  num_txn_other_refunds: " + ret.num_txn_other_refunds);
            log("    other_sales: " + ret.other_sales + "  other_tips: " + ret.other_tips);
            log("    other_refunds: " + ret.other_refunds + "  other_net: " + ret.other_net);
            log("-------------------------------------------------------------------------------");

            if (ret.payment_list != null)
            {
                if (ret.payment_list.Count > 0)
                {
                    log("  payment_detail: " + ret.payment_list.Count + " records");
                    log("  ID: type / cc_type / cc_last_four / amount / date");
                    foreach (payment_report_detail curr_detail in ret.payment_list)
                    {
                        string log_string = "  " + curr_detail.payment_id + ": " + curr_detail.method + " ";
                        if (String.Compare(curr_detail.method, "CreditCard") == 0)
                        {
                            log_string += "/ " + curr_detail.cc_type + " / " + curr_detail.cc_redacted_number + " ";
                        }

                        log_string += "/ " + curr_detail.amount + " / " + curr_detail.created.ToString("MM/dd/yyyy");
                        log(log_string);
                    }
                }
                else
                {
                    log("  payment_detail: no records");
                }
            }
            else
            {
                log("  payment_detail: null records");
            }
            
            log("===============================================================================");

            #endregion

            return ret;
        }
    }
}
