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
        public decimal? sp_ach_balance(int location_id)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_ach_balance null value detected for token, please authenticate", true);
                return null;
            }

            if (location_id <= 0)
            {
                log("sp_ach_balance location_id must be greater than zero", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response get_ach_balance_rest_resp = new rest_response();
            response get_ach_balance_resp = new response();
            decimal ret = 0m;

            #endregion

            #region Process-Request

            get_ach_balance_rest_resp = rest_client<report_request>(
                _endpoint_url + "settlement/balance/" + location_id,
                "POST",
                null,
                null);

            if (get_ach_balance_rest_resp == null)
            {
                log("sp_ach_balance null response from rest_client for ach balance retrieval call", true);
                return null;
            }

            if (get_ach_balance_rest_resp.status_code != 200)
            {
                log("sp_ach_balance rest_client returned status other than 200 for ach balance retrieval call", true);
                return null;
            }

            try
            {
                get_ach_balance_resp = deserialize_json<response>(get_ach_balance_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_ach_balance unable to deserialize response from server for ach balance retrieval call", true);
                return null;
            }

            if (!get_ach_balance_resp.success)
            {
                log("sp_ach_balance success false returned from server for ach balance retrieval call", true);
                return null;
            }

            try
            {
                ret = Convert.ToDecimal(get_ach_balance_resp.data.ToString());
                log("sp_ach_balance response retrieved");
            }
            catch (Exception)
            {
                log("sp_ach_balance unable to retrieve ach balance from response data object", true);
                return null;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("sp_ach_balance: " + ret);
            log("===============================================================================");

            #endregion

            return ret;
        }
    }
}
