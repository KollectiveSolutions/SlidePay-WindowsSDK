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
        public bool sp_delete_stored_payment(int stored_payment_id)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_delete_stored_payment null value detected for token, please authenticate", true);
                return false;
            }

            if (stored_payment_id <= 0)
            {
                log("sp_delete_stored_payment stored_payment_id must be greater than zero", true);
                return false;
            }

            #endregion

            #region Variables

            rest_response get_stored_payment_rest_resp = new rest_response();
            response get_stored_payment_resp = new response();

            #endregion

            #region Process-Request

            get_stored_payment_rest_resp = rest_client<string>(
                _endpoint_url + "stored_payment/" + stored_payment_id,
                "DELETE",
                null,
                null);

            if (get_stored_payment_rest_resp == null)
            {
                log("sp_delete_stored_payment null response from rest_client for stored_payment deletion call", true);
                return false;
            }

            if (get_stored_payment_rest_resp.status_code != 200)
            {
                log("sp_delete_stored_payment rest_client returned status other than 200 for stored_payment deletion call", true);
                return false;
            }

            try
            {
                get_stored_payment_resp = deserialize_json<response>(get_stored_payment_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_delete_stored_payment unable to deserialize response from server for stored_payment deletion call", true);
                return false;
            }

            if (!get_stored_payment_resp.success)
            {
                log("sp_delete_stored_payment success false returned from server for stored_payment deletion call", true);
                return false;
            }

            log("sp_delete_stored_payment success true returned from server for stored_payment deletion");
            return true;

            #endregion
        }
    }
}
