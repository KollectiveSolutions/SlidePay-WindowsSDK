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
        public bool sp_delete_bank_account(int bank_account_id)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_delete_bank_account null value detected for token, please authenticate", true);
                return false;
            }

            if (bank_account_id <= 0)
            {
                log("sp_delete_bank_account bank_account_id must be greater than zero", true);
                return false;
            }

            #endregion

            #region Variables

            rest_response get_bank_account_rest_resp = new rest_response();
            response get_bank_account_resp = new response();

            #endregion

            #region Process-Request

            get_bank_account_rest_resp = rest_client<string>(
                _endpoint_url + "bank_account/" + bank_account_id,
                "DELETE",
                null,
                null);

            if (get_bank_account_rest_resp == null)
            {
                log("sp_delete_bank_account null response from rest_client for bank_account deletion call", true);
                return false;
            }

            if (get_bank_account_rest_resp.status_code != 200)
            {
                log("sp_delete_bank_account rest_client returned status other than 200 for bank_account deletion call", true);
                return false;
            }

            try
            {
                get_bank_account_resp = deserialize_json<response>(get_bank_account_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_delete_bank_account unable to deserialize response from server for bank_account deletion call", true);
                return false;
            }

            if (!get_bank_account_resp.success)
            {
                log("sp_delete_bank_account success false returned from server for bank_account deletion call", true);
                return false;
            }

            log("sp_delete_bank_account success true returned from server for bank_account deletion");
            return true;

            #endregion
        }
    }
}
