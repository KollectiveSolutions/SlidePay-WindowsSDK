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
        public List<processor_ach_txn_response> sp_ach_settlement(
            int company_id,
            int location_id,
            List<manual_settlement_entry> settlement_list,
            string notes)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_ach_settlement null value detected for token, please authenticate", true);
                return null;
            }

            if (company_id <= 0)
            {
                log("sp_ach_settlement company_id must be greater than zero", true);
                return null;
            }

            if (location_id <= 0)
            {
                log("sp_ach_settlement location_id must be greater than zero", true);
                return null;
            }

            if (settlement_list == null)
            {
                log("sp_ach_settlement null value for settlement_list");
                return null;
            }

            if (settlement_list.Count < 1)
            {
                log("sp_ach_settlement no entries in settlement_list");
                return null;
            }

            #endregion

            #region Variables

            manual_settlement req = new manual_settlement();
            rest_response get_ach_settlement_rest_resp = new rest_response();
            response get_ach_settlement_resp = new response();
            List<processor_ach_txn_response> ret = new List<processor_ach_txn_response>();

            #endregion

            #region Build-Request-Body

            req.company_id = company_id;
            req.location_id = location_id;
            req.notes = notes;
            req.settlement_list = settlement_list;

            #endregion

            #region Process-Request

            get_ach_settlement_rest_resp = rest_client<manual_settlement>(
                _endpoint_url + "settlement/manual",
                "POST",
                null,
                req);

            if (get_ach_settlement_rest_resp == null)
            {
                log("sp_ach_settlement null response from rest_client for manual settlement call", true);
                return null;
            }

            if (get_ach_settlement_rest_resp.status_code != 200)
            {
                log("sp_ach_settlement rest_client returned status other than 200 for manual settlement call", true);
                return null;
            }

            try
            {
                get_ach_settlement_resp = deserialize_json<response>(get_ach_settlement_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_ach_settlement unable to deserialize response from server for manual settlement call", true);
                return null;
            }

            if (!get_ach_settlement_resp.success)
            {
                log("sp_ach_settlement success false returned from server for manual settlement call", true);
                return null;
            }

            try
            {
                ret = deserialize_json<List<processor_ach_txn_response>>(get_ach_settlement_resp.data.ToString());
                log("sp_ach_settlement response retrieved");
            }
            catch (Exception)
            {
                log("sp_ach_settlement unable to deserialize settlement response list object", true);
                return null;
            }

            if (ret == null)
            {
                log("sp_ach_settlement null settlement response list retrieved", true);
                return null;
            }

            if (ret.Count < 1)
            {
                log("sp_ach_settlement empty settlement response list retrieved", true);
                return null;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("sp_ach_settlement: " + ret.Count + " entries");
            log("  ID: amount / routing / account");
            log("      status / transaction_token");

            foreach (processor_ach_txn_response curr in ret)
            {
                log("  " + curr.settlement_id + ": " + curr.amount + " / " + curr.routing_number + " / " + curr.account_number);
                log("      " + curr.provider_status + " / " + curr.settlement_transaction_token);
            }
            
            log("===============================================================================");

            #endregion

            return ret;
        }
    }
}
