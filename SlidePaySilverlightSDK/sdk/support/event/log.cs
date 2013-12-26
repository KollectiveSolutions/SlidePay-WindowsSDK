using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        private void log(string message, bool warning)
        {
            if (warning) log("*** " + message);
            else log(message);
        }

        private void log(string message)
        {
            if (_debug_output)
            {
                Debug.WriteLine(message);
            }
        }
    }
}
