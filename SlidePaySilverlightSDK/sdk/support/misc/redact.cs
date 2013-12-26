using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public string redact(string val)
        {
            try
            {
                #region Check-for-Null-Values

                if (string_null_or_empty(val))
                {
                    log("redact val is null");
                    return null;
                }

                #endregion

                string redacted_val = "";
                try
                {
                    for (int i = 0; i < val.Length; i++)
                    {
                        if ((val.Length - i) > 4)
                        {
                            redacted_val += "*";
                        }
                        else
                        {
                            redacted_val += val[i];
                        }
                    }
                    return redacted_val;
                }
                catch (Exception)
                {
                    log("redact unable to redact, using all asterisks");
                    return "****************";
                }

            }
            catch (Exception e)
            {
                exception("redact", "general exception", e);
                return "****************";
            }
        }
    }
}