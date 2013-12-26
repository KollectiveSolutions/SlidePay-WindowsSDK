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
        public List<payment> sp_put_payment(List<search_filter> sf_list)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_put_payment null value detected for token, please authenticate", true);
                return null;
            }

            if (sf_list == null)
            {
                log("sp_put_payment null value detected for search filter list", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response put_payment_rest_resp = new rest_response();
            response put_payment_resp = new response();
            List<payment> curr_payment_list = new List<payment>();

            #endregion

            #region Process-Request

            put_payment_rest_resp = rest_client<List<search_filter>>(
                _endpoint_url + "payment/",
                "PUT",
                null,
                sf_list);

            if (put_payment_rest_resp == null)
            {
                log("sp_put_payment null response from rest_client for payment search call", true);
                return null;
            }

            if (put_payment_rest_resp.status_code != 200)
            {
                log("sp_put_payment rest_client returned status other than 200 for payment search call", true);
                return null;
            }

            try
            {
                put_payment_resp = deserialize_json<response>(put_payment_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_put_payment unable to deserialize response from server for payment search call", true);
                return null;
            }

            if (!put_payment_resp.success)
            {
                log("sp_put_payment success false returned from server for payment search call", true);
                return null;
            }

            try
            {
                curr_payment_list = deserialize_json<List<payment>>(put_payment_resp.data.ToString());
                log("sp_put_payment response retrieved");
            }
            catch (Exception)
            {
                log("sp_put_payment unable to deserialize payment list object", true);
                return null;
            }

            if (curr_payment_list == null)
            {
                log("sp_put_payment null payment list retrieved", true);
                return null;
            }

            if (curr_payment_list.Count < 1)
            {
                log("sp_put_payment no payments retrieved", true);
                return null;
            }

            #endregion

            #region Enumerate

            foreach (payment curr_payment in curr_payment_list)
            {
                log("===============================================================================");
                log("Payment retrieved: " + curr_payment.payment_id);
                log("  " + curr_payment.method + " " + curr_payment.cc_type + " " + curr_payment.cc_redacted_number + " " + curr_payment.cc_expiry_month + "/" + curr_payment.cc_expiry_year + " " + decimal_tostring(curr_payment.amount));
                log("  Approval " + curr_payment.provider_approval_code + " Status " + curr_payment.provider_status_code + " " + curr_payment.provider_status_message + " " + curr_payment.provider_transaction_state);
                log("  Response time " + curr_payment.processor_time_ms + "ms");
                log("  Stored Payment GUID " + curr_payment.stored_payment_guid);
                log("===============================================================================");
            }

            #endregion

            return curr_payment_list;
        }
    }
}
