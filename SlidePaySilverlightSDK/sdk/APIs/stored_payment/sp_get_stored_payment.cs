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
        public List<stored_payment> sp_get_stored_payment(string guid)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_get_stored_payment null value detected for token, please authenticate", true);
                return null;
            }

            if (string_null_or_empty(guid))
            {
                log("sp_get_stored_payment null value detected for guid", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response get_sp_rest_resp = new rest_response();
            response get_sp_resp = new response();
            List<stored_payment> ret = new List<stored_payment>();

            #endregion
            
            #region Process-Request

            get_sp_rest_resp = rest_client<simple_payment>(
                _endpoint_url + "stored_payment?guid=" + guid,
                "GET",
                null,
                null);

            if (get_sp_rest_resp == null)
            {
                log("sp_get_stored_payment null response from rest_client for stored payment retrieval call", true);
                return null;
            }

            if (get_sp_rest_resp.status_code != 200)
            {
                log("sp_get_stored_payment rest_client returned status other than 200 for stored payment retrieval call", true);
                return null;
            }

            try
            {
                get_sp_resp = deserialize_json<response>(get_sp_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_get_stored_payment unable to deserialize response from server for stored payment retrieval call", true);
                return null;
            }

            if (!get_sp_resp.success)
            {
                log("sp_get_stored_payment success false returned from server for stored payment retrieval call", true);
                return null;
            }

            try
            {
                ret = deserialize_json<List<stored_payment>>(get_sp_resp.data.ToString());
                log("sp_get_stored_payment response retrieved");
            }
            catch (Exception)
            {
                log("sp_get_stored_payment unable to deserialize stored payment list object", true);
                return null;
            }

            if (ret == null)
            {
                log("sp_get_stored_payment null stored payment list retrieved", true);
                return null;
            }

            if (ret.Count < 1)
            {
                log("sp_get_stored_payment empty stored payment list retrieved", true);
                return null;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("Stored payment response received: " + ret.Count + " entries");
            foreach (stored_payment curr in ret)
            {
                log("  " + curr.stored_payment_id + ": " + curr.cc_type + " " + curr.cc_redacted_number + " guid " + curr.guid);
            }
            log("===============================================================================");

            #endregion

            return ret;
        }
    }
}
