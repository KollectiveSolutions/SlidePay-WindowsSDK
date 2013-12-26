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
        private string decimal_tostring(object obj)
        {
            try
            {
                if (obj == null)
                {
                    log("decimal_tostring null value supplied for input obj", true);
                    return null;
                }

                if (obj is string)
                {
                    if (string_null_or_empty(obj.ToString()))
                    {
                        log("decimal_tostring null value supplied for string obj", true);
                        return null;
                    }
                }

                string ret = string.Format("{0:N2}", obj);
                ret = ret.Replace(",", "");
                return ret;
            }
            catch (Exception e)
            {
                exception("decimal_tostring", "general exception", e);
                return null;
            }
        }
    }
}