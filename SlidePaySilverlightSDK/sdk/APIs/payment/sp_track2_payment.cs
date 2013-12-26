using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public processor_cc_txn_response sp_track2_payment(
            string track2,
            string notes,
            decimal amount)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_track2_payment null value detected for token, please authenticate", true);
                return null;
            }

            if (string_null_or_empty(track2))
            {
                log("sp_track2_payment null value detected in one of the input values", true);
                return null;
            }

            if (amount <= 0)
            {
                log("sp_track2_payment amount must be greater than zero", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response track_payment_rest_resp = new rest_response();
            response track_payment_resp = new response();
            processor_cc_txn_response curr_resp = new processor_cc_txn_response();

            #endregion

            #region Create-Request-Body

            simple_payment curr = new simple_payment();
            curr.cc_track2data = track2;
            curr.notes = notes;
            curr.amount = amount;
            curr.method = "CreditCard";

            #endregion

            #region Process-Request

            track_payment_rest_resp = rest_client<simple_payment>(
                _endpoint_url + "payment/simple",
                "POST",
                null,
                curr);

            if (track_payment_rest_resp == null)
            {
                log("sp_track2_payment null response from rest_client for simple payment call", true);
                return null;
            }

            if (track_payment_rest_resp.status_code != 200 &&
                track_payment_rest_resp.status_code != 201)
            {
                log("sp_track2_payment rest_client returned status other than 200/201 for simple payment call", true);
                return null;
            }

            try
            {
                track_payment_resp = deserialize_json<response>(track_payment_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_track2_payment unable to deserialize response from server for simple payment call", true);
                return null;
            }

            if (!track_payment_resp.success)
            {
                log("sp_track2_payment success false returned from server for simple payment call", true);
                return null;
            }

            try
            {
                curr_resp = deserialize_json<processor_cc_txn_response>(track_payment_resp.data.ToString());
                log("sp_track2_payment response retrieved");
            }
            catch (Exception)
            {
                log("sp_track2_payment unable to deserialize processor response", true);
                return null;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("Payment response received: " + curr_resp.is_approved);
            log("  " + curr_resp.cc_type + " " + curr_resp.cc_redacted_number + " " + curr_resp.cc_expiry_month + "/" + curr_resp.cc_expiry_year + " " + decimal_tostring(curr_resp.amount));
            log("  Approval " + curr_resp.approval_code + " Status " + curr_resp.status_code + " " + curr_resp.status_message + " " + curr_resp.transaction_state);
            log("  Response time " + curr_resp.processor_time_ms + "ms");
            log("  Card present " + curr_resp.cc_present);

            if (curr_resp.is_approved)
            {
                log("  Payment ID " + curr_resp.payment_id);
                log("  Stored Payment GUID " + curr_resp.stored_payment_guid);
            }
            
            log("===============================================================================");
            
            #endregion

            return curr_resp;
        }
    }
}
