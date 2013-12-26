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
        public bool sp_reset()
        {
            _endpoint_url = "";
            _email = "";
            _password = "";
            _token_string = "";
            _token = null;
            log("sp_reset complete");
            return true;
        }
    }
}
