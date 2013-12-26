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
        public account_report sp_account_report(int location_id)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_account_report null value detected for token, please authenticate", true);
                return null;
            }

            if (location_id <= 0)
            {
                log("sp_account_report location_id must be greater than zero", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response get_account_report_rest_resp = new rest_response();
            response get_account_report_resp = new response();
            account_report ret = new account_report();
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

            report_req.csv = false;
            report_req.email_address = null;
            report_req.html = false;
            report_req.raw_data = true;
            report_req.sfa = sf_list.ToArray();

            #endregion

            #region Process-Request

            get_account_report_rest_resp = rest_client<report_request>(
                _endpoint_url + "report/account",
                "POST",
                null,
                report_req);

            if (get_account_report_rest_resp == null)
            {
                log("sp_account_report null response from rest_client for account report retrieval call", true);
                return null;
            }

            if (get_account_report_rest_resp.status_code != 200)
            {
                log("sp_account_report rest_client returned status other than 200 for account report retrieval call", true);
                return null;
            }

            try
            {
                get_account_report_resp = deserialize_json<response>(get_account_report_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_account_report unable to deserialize response from server for account report retrieval call", true);
                return null;
            }

            if (!get_account_report_resp.success)
            {
                log("sp_account_report success false returned from server for account report retrieval call", true);
                return null;
            }

            try
            {
                ret = deserialize_json<account_report>(get_account_report_resp.data.ToString());
                log("sp_account_report response retrieved");
            }
            catch (Exception)
            {
                log("sp_account_report unable to deserialize account report object", true);
                return null;
            }

            if (ret == null)
            {
                log("sp_account_report null account report retrieved", true);
                return null;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("account_report retrieved: ");
            log("  " + ret.start_time + " to " + ret.end_time);
            
            if (ret.report_detail != null)
            {
                if (ret.report_detail.Count > 0)
                {
                    foreach (account_report_detail curr_detail in ret.report_detail)
                    {
                        log("-------------------------------------------------------------------------------");
                        log("  report for company_id " + curr_detail.company_id + " " + curr_detail.company_name);
                        log("             location_id " + curr_detail.location_id + " " + curr_detail.location_name);
                        log("             account_id " + curr_detail.account_id + " " + curr_detail.account_name);
                        
                        log("  account details:");
                        if (curr_detail.account_record != null)
                        {
                            log("    " + curr_detail.account_record.account_type + " created " + curr_detail.account_record.created);
                            log("    " + curr_detail.account_record.description);
                            log("    reserve amount: " + curr_detail.account_record.reserve_amount);
                        }
                        else
                        {
                            log("    no account record to show (null)");
                        }

                        if (curr_detail.account_balance != null)
                        {
                            log("  account balance: " + curr_detail.account_balance.balance);
                        }
                        else
                        {
                            log("  no account balance to show (null)");
                        }

                        log("    commit_balance: " + curr_detail.commit_balance);
                        log("    reserve_amount: " + curr_detail.reserve_amount);
                        log("    available_balance: " + curr_detail.available_balance);
                        log("    pending_credits: " + curr_detail.pending_credits);
                        log("    pending_debits: " + curr_detail.pending_debits);
                        log("    pending_net: " + curr_detail.pending_net);
                        log("    pending_balance: " + curr_detail.pending_balance);

                        log("  ledger entries: ");
                        log("    (balance entries and entries that are newer than balance entry");

                        if (curr_detail.entries != null)
                        {
                            if (curr_detail.entries.Count > 0)
                            {
                                log("    ID: type / amount / committed / ledgered / date");
                                log("        notes");
                                foreach (account_ledger curr_ledger in curr_detail.entries)
                                {
                                    string log_string = "    " + curr_ledger.account_ledger_id + ": " + curr_ledger.entry_type + " / ";

                                    switch (curr_ledger.entry_type)
                                    {
                                        case "credit":
                                            log_string += curr_ledger.credit_amount + " / ";
                                            break;

                                        case "debit":
                                            log_string += "(" + curr_ledger.debit_amount + ") / ";
                                            break;

                                        case "balance":
                                            log_string += "NA / ";
                                            break;

                                        default:
                                            log_string += "unknown / ";
                                            break;
                                    }

                                    log_string += curr_ledger.transaction_status + " / " + curr_ledger.ledgered + " / " + Convert.ToDateTime(curr_ledger.created).ToString("MM/dd/yyyy");
                                    log(log_string);
                                    log("        " + curr_ledger.description);
                                }
                            }
                            else
                            {
                                log("    no account ledger records to show (empty)");
                            }
                        }
                        else
                        {
                            log("    no account ledger records to show (null)");
                        }
                    }
                }
                else
                {
                    log("  no account detail to show (empty)");
                }
            }
            else
            {
                log("  no account detail to show (null)");
            }

            log("===============================================================================");

            #endregion

            return ret;
        }
    }
}
