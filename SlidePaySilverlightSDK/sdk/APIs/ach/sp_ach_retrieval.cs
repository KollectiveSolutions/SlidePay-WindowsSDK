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
        public processor_ach_txn_response sp_ach_retrieval(
            int? company_id,
            int? location_id,
            int? user_master_id,
            int? bank_account_id,
            string bank_account_type,
            string bank_account_routing_number,
            string bank_account_account_number,
            string bank_account_company_name,  
            string bank_account_first_name,  
            string bank_account_last_name,  
            string bank_account_address_1,
            string bank_account_address_2,  
            string bank_account_city,
            string bank_account_state,
            string bank_account_postal_code,
            string bank_account_country,
            string bank_account_phone_country_code,
            string bank_account_phone,
            decimal? retrieval_amount,
            string notes
            )
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_ach_retrieval null value detected for token, please authenticate", true);
                return null;
            }

            if (company_id <= 0)
            {
                log("sp_ach_retrieval company_id must be greater than zero", true);
                return null;
            }

            if (location_id <= 0)
            {
                log("sp_ach_retrieval location_id must be greater than zero", true);
                return null;
            }

            if (user_master_id <= 0)
            {
                log("sp_ach_retrieval user_master_id must be greater than zero", true);
                return null;
            }

            if (string_null_or_empty(bank_account_type))
            {
                log("sp_ach_retrieval null value for bank_account_type");
                return null;
            }

            if (String.Compare(bank_account_type, "Personal Checking") != 0 &&
                String.Compare(bank_account_type, "Personal Savings") != 0 &&
                String.Compare(bank_account_type, "Business Checking") != 0 &&
                String.Compare(bank_account_type, "Business Savings") != 0)
            {
                log("sp_ach_retrieval invalid bank_account_type.  Use Personal||Business Checking||Savings");
                return null;
            }
            
            if (string_null_or_empty(bank_account_routing_number))
            {
                log("sp_ach_retrieval null value for bank_account_routing_number");
                return null;
            }

            if (string_null_or_empty(bank_account_account_number))
            {
                log("sp_ach_retrieval null value for bank_account_account_number");
                return null;
            }

            if (retrieval_amount == null)
            {
                log("sp_ach_retrieval retrieval_amount cannot be null and must be greater than zero");
                return null;
            }

            if (retrieval_amount <= 0)
            {
                log("sp_ach_retrieval retrieval_amount must be greater than zero");
                return null;
            }

            #endregion

            #region Variables

            retrieval req = new retrieval();
            rest_response ach_retrieval_rest_resp = new rest_response();
            response ach_retrieval_resp = new response();
            processor_ach_txn_response ret = new processor_ach_txn_response();

            #endregion

            #region Build-Request-Body

            req.company_id = company_id;
            req.location_id = location_id;
            req.user_master_id = user_master_id;
            req.bank_account_id = bank_account_id;
            req.bank_account_type = bank_account_type;
            req.bank_account_routing_number = bank_account_routing_number;
            req.bank_account_account_number = bank_account_account_number;
            req.bank_account_company_name = bank_account_company_name;
            req.bank_account_first_name = bank_account_first_name;
            req.bank_account_last_name = bank_account_last_name;
            req.bank_account_address_1 = bank_account_address_1;
            req.bank_account_address_2 = bank_account_address_2;
            req.bank_account_city = bank_account_city;
            req.bank_account_state = bank_account_state;
            req.bank_account_postal_code = bank_account_postal_code;
            req.bank_account_country = bank_account_country;
            req.bank_account_phone_country_code = bank_account_phone_country_code;
            req.bank_account_phone = bank_account_phone;
            req.retrieval_amount = retrieval_amount;
            req.notes = notes;

            #endregion

            #region Process-Request

            ach_retrieval_rest_resp = rest_client<retrieval>(
                _endpoint_url + "retrieval/manual",
                "POST",
                null,
                req);

            if (ach_retrieval_rest_resp == null)
            {
                log("sp_ach_retrieval null response from rest_client forach retrievalcall", true);
                return null;
            }

            if (ach_retrieval_rest_resp.status_code != 200)
            {
                log("sp_ach_retrieval rest_client returned status other than 200 forach retrievalcall", true);
                return null;
            }

            try
            {
                ach_retrieval_resp = deserialize_json<response>(ach_retrieval_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_ach_retrieval unable to deserialize response from server forach retrievalcall", true);
                return null;
            }

            if (!ach_retrieval_resp.success)
            {
                log("sp_ach_retrieval success false returned from server forach retrievalcall", true);
                return null;
            }

            try
            {
                ret = deserialize_json<processor_ach_txn_response>(ach_retrieval_resp.data.ToString());
                log("sp_ach_retrieval response retrieved");
            }
            catch (Exception)
            {
                log("sp_ach_retrieval unable to deserialize settlement response list object", true);
                return null;
            }

            if (ret == null)
            {
                log("sp_ach_retrieval null settlement response list retrieved", true);
                return null;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("sp_ach_retrieval:");
            log("  ID: amount / routing / account");
            log("      status / transaction_token");
            log("  " + ret.settlement_id + ": " + ret.amount + " / " + ret.routing_number + " / " + ret.account_number);
            log("      " + ret.provider_status + " / " + ret.settlement_transaction_token);          
            log("===============================================================================");

            #endregion

            return ret;
        }
    }
}
