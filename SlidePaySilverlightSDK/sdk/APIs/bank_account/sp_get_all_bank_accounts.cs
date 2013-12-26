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
        public List<bank_account> sp_get_all_bank_accounts()
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_get_all_bank_accounts null value detected for token, please authenticate", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response get_bank_account_rest_resp = new rest_response();
            response get_bank_account_resp = new response();
            List<bank_account> curr_bank_account_list = new List<bank_account>();

            #endregion

            #region Process-Request

            get_bank_account_rest_resp = rest_client<string>(
                _endpoint_url + "bank_account/",
                "GET",
                null,
                null);

            if (get_bank_account_rest_resp == null)
            {
                log("sp_get_all_bank_accounts null response from rest_client for bank_account retrieval call", true);
                return null;
            }

            if (get_bank_account_rest_resp.status_code != 200)
            {
                log("sp_get_all_bank_accounts rest_client returned status other than 200 for bank_account retrieval call", true);
                return null;
            }

            try
            {
                get_bank_account_resp = deserialize_json<response>(get_bank_account_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_get_all_bank_accounts unable to deserialize response from server for bank_account retrieval call", true);
                return null;
            }

            if (!get_bank_account_resp.success)
            {
                log("sp_get_all_bank_accounts success false returned from server for bank_account retrieval call", true);
                return null;
            }

            try
            {
                curr_bank_account_list = deserialize_json<List<bank_account>>(get_bank_account_resp.data.ToString());
                log("sp_get_all_bank_accounts response retrieved");
            }
            catch (Exception)
            {
                log("sp_get_all_bank_accounts unable to deserialize bank_account list object", true);
                return null;
            }

            if (curr_bank_account_list == null)
            {
                log("sp_get_all_bank_accounts null bank_account list retrieved", true);
                return null;
            }

            if (curr_bank_account_list.Count < 1)
            {
                log("sp_get_all_bank_accounts no bank_accounts retrieved", true);
                return null;
            }

            #endregion

            #region Enumerate

            foreach (bank_account curr_bank_account in curr_bank_account_list)
            {
                log("===============================================================================");
                log("bank_account retrieved: " + curr_bank_account.bank_account_id);
                log("  type " + curr_bank_account.type + " routing " + curr_bank_account.routing_number + " account " + curr_bank_account.account_number);
                log("  is_settlement_account " + curr_bank_account.is_settlement_account + " is_verified " + curr_bank_account.is_verified);
                log("===============================================================================");
            }

            #endregion

            return curr_bank_account_list;
        }
    }
}
