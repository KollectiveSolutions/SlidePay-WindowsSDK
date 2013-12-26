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
        public bool sp_find_endpoint()
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_email) || string_null_or_empty(_password))
            {
                log("sp_find_endpoint null value detected for either email or password", true);
                return false;
            }

            #endregion

            #region Variables

            rest_response rest_resp = new rest_response();
            response resp = new response();

            #endregion

            #region Process-Request

            rest_resp = rest_client<string>(
                _endpoint_discovery_url,
                "GET",
                null,
                null);

            if (rest_resp == null)
            {
                log("sp_find_endpoint null response from rest_client", true);
                return false;
            }

            if (rest_resp.status_code != 200)
            {
                log("sp_find_endpoint rest_client returned status other than 200", true);
                return false;
            }

            try
            {
                resp = deserialize_json<response>(rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_find_endpoint unable to deserialize response from server", true);
                return false;
            }

            if (!resp.success)
            {
                log("sp_find_endpoint success false returned from server", true);
                return false;
            }

            _endpoint_url = resp.data.ToString();
            log("sp_find_endpoint endpoint URL found: " + _endpoint_url);
            return true;

            #endregion
        }
    }
}
