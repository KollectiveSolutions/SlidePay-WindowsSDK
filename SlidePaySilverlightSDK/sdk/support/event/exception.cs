using System;
using System.Net;
using System.Diagnostics;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        private void exception(string method, string text, Exception e)
        {
            #region Return-if-Debug-Disabled

            if (!_debug_output) return;

            #endregion

            #region Get-Line-Number
            var st = new StackTrace(e);
            var frame = st.GetFrame(0);
            int line = frame.GetFileLineNumber();
            //string filename = frame.GetFileName();

            #endregion

            #region Send-Log-Details

            log("===============================================================================", true);
            log("Exception encountered", true);
            log("", true);
            log("  Type: " + e.GetType().ToString(), true);
            log("  Text: " + text, true);
            log("  Data: " + e.Data, true);
            log("  Inner: " + e.InnerException, true);
            log("  Message: " + e.Message, true);
            log("  Source: " + "stupid silverlight 5 hides stack traces", true);
            log("  StackTrace: " + e.StackTrace, true);
            log("  Line: " + line, true);
            log("  File: " + "Stupid Silverlight 5 wont let me get filenames", true);
            log("  ToString: " + e.ToString(), true);
            log("===============================================================================", true);
            
            #endregion

            return;
        }
    }
}
