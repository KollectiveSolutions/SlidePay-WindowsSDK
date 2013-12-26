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
        public stored_payment sp_create_stored_payment(
            int company_id,
            int location_id,
            string cc_number,
            string cc_expiry_month,
            string cc_expiry_year,
            string cc_name_on_card,
            string cc_billing_zip)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_create_stored_payment null value detected for token, please authenticate", true);
                return null;
            }

            if (string_null_or_empty(cc_number) ||
                string_null_or_empty(cc_expiry_month) ||
                string_null_or_empty(cc_expiry_year) ||
                string_null_or_empty(cc_name_on_card) ||
                string_null_or_empty(cc_billing_zip))
            {
                log("sp_create_stored_payment null value detected in one of the input values", true);
                return null;
            }

            if (company_id <= 0)
            {
                log("sp_create_stored_payment company_id must be greater than zero", true);
                return null;
            }

            if (location_id <= 0)
            {
                log("sp_create_stored_payment location_id must be greater than zero", true);
                return null;
            }

            #endregion

            #region Variables

            stored_payment req = new stored_payment();
            rest_response sp_rest_resp = new rest_response();
            response sp_resp = new response();
            stored_payment ret = new stored_payment();

            #endregion

            #region Create-Request-Body

            req.company_id = company_id;
            req.location_id = location_id;
            req.method = "CreditCard";
            req.cc_number = cc_number;
            req.cc_redacted_number = redact(cc_number);
            req.cc_expiry_month = cc_expiry_month;
            req.cc_expiry_year = cc_expiry_year;
            req.cc_name_on_card = cc_name_on_card;
            req.cc_billing_zip = cc_billing_zip;

            #endregion

            #region Process-Request

            sp_rest_resp = rest_client<stored_payment>(
                _endpoint_url + "stored_payment",
                "POST",
                null,
                req);

            if (sp_rest_resp == null)
            {
                log("sp_create_stored_payment null response from rest_client for stored_payment call", true);
                return null;
            }

            if (sp_rest_resp.status_code != 200 &&
                sp_rest_resp.status_code != 201)
            {
                log("sp_create_stored_payment rest_client returned status other than 200/201 for stored_payment call", true);
                return null;
            }

            try
            {
                sp_resp = deserialize_json<response>(sp_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_create_stored_payment unable to deserialize response from server for stored_payment call", true);
                return null;
            }

            try
            {
                ret = deserialize_json<stored_payment>(sp_resp.data.ToString());
                log("sp_create_stored_payment response retrieved");
            }
            catch (Exception)
            {
                log("sp_create_stored_payment unable to deserialize processor response", true);
                return null;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("Stored payment response received: ");
            log("  " + ret.stored_payment_id + ": " + ret.cc_type + " " + ret.cc_redacted_number + " guid " + ret.guid);
            log("===============================================================================");
            
            #endregion

            return ret;
        }
    }
}
