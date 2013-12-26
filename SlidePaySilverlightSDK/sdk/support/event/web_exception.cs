using System;
using System.Net;
using System.IO;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        private void webexception(
            string url,
            string method,
            string text,
            string request_body,
            WebException e)
        {
            #region Return-if-Debug-Disabled

            if (!_debug_output) return;

            #endregion

            #region Read-Response

            string string_response = "";
            if (e.Response != null)
            {
                try
                {
                    using (Stream stream = e.Response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string_response = reader.ReadToEnd();
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            #endregion

            #region Send-Log-Details

            log("===============================================================================", true);
            log("WebException encountered", true);
            log(method + " " + url, true);
            log("", true);
            log("  Text: " + text, true);
            log("  Data: " + e.Data + "   ", true);
            log("  Inner Exception: " + e.InnerException + "   ", true);
            log("  Message: " + e.Message + "   ", true);
            log("  Source: " + "stupid silverlight" + "   ", true);
            log("  StackTrace: " + e.StackTrace + "   ", true);
            log("  Response: " + string_response + "   ", true);
            log("  Request Body: " + request_body + "   ", true);
            log("===============================================================================", true);

            #endregion

            return;
        }
    }
}
