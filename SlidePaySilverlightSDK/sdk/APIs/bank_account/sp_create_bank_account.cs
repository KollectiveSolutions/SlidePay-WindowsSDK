using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public bank_account sp_create_bank_account(
            string account_type,
            string routing_number,
            string account_number,
            string company_name,
            string first_name,
            string last_name,
            string address,
            string city,
            string state,
            string postal_code,
            string phone,
            int is_settlement_account
            )
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_create_bank_account null value detected for token, please authenticate", true);
                return null;
            }

            if (string_null_or_empty(account_type) ||
                string_null_or_empty(routing_number) ||
                string_null_or_empty(account_number) ||
                string_null_or_empty(address) ||
                string_null_or_empty(city) ||
                string_null_or_empty(state) ||
                string_null_or_empty(postal_code) ||
                string_null_or_empty(phone))
            {
                log("sp_create_bank_account null values specified for a required field", true);
                return null;
            }

            if (is_settlement_account < 0 || is_settlement_account > 1)
            {
                log("sp_create_bank_account is_settlement_account must be either 0 or 1", true);
                return null;
            }

            if ((String.Compare(account_type, "Business Checking") != 0) &&
                (String.Compare(account_type, "Business Savings") != 0) &&
                (String.Compare(account_type, "Personal Checking") != 0) &&
                (String.Compare(account_type, "Personal Savings") != 0))
            {
                log("sp_create_bank_account invalid value for account_type, use 'Business Checking', 'Business Savings', 'Personal Checking', or 'Personal Savings'", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response create_bank_account_rest_resp = new rest_response();
            response create_bank_account_resp = new response();
            bank_account request_bank_account = new bank_account();
            bank_account created_bank_account = new bank_account();

            #endregion

            #region Create-Object

            request_bank_account.company_id = _token.company_id;
            request_bank_account.location_id = _token.location_id;
            request_bank_account.account_address_1 = address;
            request_bank_account.account_city = city;
            request_bank_account.account_company_name = company_name;
            request_bank_account.account_country = "USA";
            request_bank_account.account_first_name = first_name;
            request_bank_account.account_last_name = last_name;
            request_bank_account.account_number = account_number;
            request_bank_account.account_phone_country_code = "1";
            request_bank_account.account_postal_code = postal_code;
            request_bank_account.account_state = state.ToUpper();
            request_bank_account.account_phone = phone;
            request_bank_account.is_settlement_account = is_settlement_account;
            request_bank_account.routing_number = routing_number;
            request_bank_account.type = account_type;

            #endregion

            #region Process-Request

            create_bank_account_rest_resp = rest_client<bank_account>(
                _endpoint_url + "bank_account/",
                "POST",
                null,
                request_bank_account);

            if (create_bank_account_rest_resp == null)
            {
                log("sp_create_bank_account null response from rest_client for bank_account creation call", true);
                return null;
            }

            if ((create_bank_account_rest_resp.status_code != 200) &&
                (create_bank_account_rest_resp.status_code != 201))
            {
                log("sp_create_bank_account rest_client returned status other than 200/201 for bank_account creation call", true);
                return null;
            }

            try
            {
                create_bank_account_resp = deserialize_json<response>(create_bank_account_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_create_bank_account unable to deserialize response from server for bank_account creation call", true);
                return null;
            }

            if (!create_bank_account_resp.success)
            {
                log("sp_create_bank_account success false returned from server for bank_account creation call", true);
                return null;
            }

            try
            {
                created_bank_account = deserialize_json<bank_account>(create_bank_account_resp.data.ToString());
                log("sp_create_bank_account response retrieved");
            }
            catch (Exception)
            {
                log("sp_create_bank_account unable to deserialize bank_account object", true);
                return null;
            }

            if (created_bank_account == null)
            {
                log("sp_create_bank_account null bank_account retrieved", true);
                return null;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("bank_account created: " + created_bank_account.bank_account_id);
            log("  type " + created_bank_account.type + " routing " + created_bank_account.routing_number + " account " + created_bank_account.account_number);
            log("  is_settlement_account " + created_bank_account.is_settlement_account + " is_verified " + created_bank_account.is_verified);
            log("===============================================================================");

            #endregion

            return created_bank_account;
        }
    }
}
