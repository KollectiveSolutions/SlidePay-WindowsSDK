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
        public bool sp_login()
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_email) || string_null_or_empty(_password))
            {
                log("sp_login null value detected for either email or password", true);
                return false;
            }

            if (string_null_or_empty(_endpoint_url))
            {
                log("sp_login null value detected for endpoint URL", true);
                return false;
            }

            #endregion

            #region Variables

            rest_response login_rest_resp = new rest_response();
            response login_resp = new response();

            rest_response detail_rest_resp = new rest_response();
            response detail_resp = new response();

            #endregion

            #region Process-Login

            login_rest_resp = rest_client<string>(
                _endpoint_url + "login",
                "GET",
                null,
                null);

            if (login_rest_resp == null)
            {
                log("sp_login null response from rest_client for login call", true);
                return false;
            }

            if (login_rest_resp.status_code != 200)
            {
                log("sp_login rest_client returned status other than 200 for login call", true);
                return false;
            }

            try
            {
                login_resp = deserialize_json<response>(login_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_login unable to deserialize response from server for login call", true);
                return false;
            }

            if (!login_resp.success)
            {
                log("sp_login success false returned from server for login call", true);
                return false;
            }

            _token_string = login_resp.data.ToString();
            log("sp_login token retrieved: " + _token_string);

            #endregion

            #region Retrieve-Token-Details

            detail_rest_resp = rest_client<string>(
                _endpoint_url + "token/detail",
                "GET",
                null,
                null);

            if (detail_rest_resp == null)
            {
                log("sp_login null response from rest_client for token detail call", true);
                return false;
            }

            if (detail_rest_resp.status_code != 200)
            {
                log("sp_login rest_client returned status other than 200 for token detail call", true);
                return false;
            }

            try
            {
                detail_resp = deserialize_json<response>(detail_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_login unable to deserialize response from server for token detail call", true);
                return false;
            }

            if (!detail_resp.success)
            {
                log("sp_login success false returned from server for token detail call", true);
                return false;
            }

            try
            {
                log("sp_login retrieved token detail: " + detail_resp.data.ToString());
                _token = deserialize_json<token>(detail_resp.data.ToString());
                _token_created = DateTime.Now;
                log("sp_login token detail retrieved");
            }
            catch (Exception)
            {
                log("sp_login unable to deserialize token detail", true);
                return false;
            }

            #endregion

            log("sp_login login successful for email " + _email);
            return true;
        }
    }
}
