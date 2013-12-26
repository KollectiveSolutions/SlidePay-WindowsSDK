using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public SlidePayWindowsSDK(string email, string password)
        {
            _email = email;
            _password = password;
            _debug_output = false;
            _proxy_url = "";
            log_sdk_init();
        }

        public SlidePayWindowsSDK(string email, string password, bool debug_output)
        {
            _email = email;
            _password = password;
            _debug_output = debug_output;
            _proxy_url = "";
            log_sdk_init();
        }

        public SlidePayWindowsSDK(string email, string password, bool debug_output, string proxy_url)
        {
            _email = email;
            _password = password;
            _debug_output = debug_output;
            _proxy_url = proxy_url;
            log_sdk_init();
        }
    }
}
