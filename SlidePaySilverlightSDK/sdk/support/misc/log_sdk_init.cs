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
        private void log_sdk_init()
        {
            bool temp = _debug_output;
            _debug_output = true;

            log("===============================================================================");
            log("");
            log("Initializing SlidePay SDK " + _version + " (c)2013 Cube, Co.");
            log("");
            log("Use of this software implies agreement with the terms and conditions defined");
            log("in the README.txt file.");
            log("");
            log("===============================================================================");
            
            _debug_output = temp;
        }
    }
}