using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        #region Class-Variables

        #region General-Variables

        public bool _debug_output = false;
        public string _proxy_url = "";
        public string _version = "v1.0.1";

        #endregion

        #region Authentication

        public string _endpoint_discovery_url = "https://supervisor.getcube.com:65532/rest.svc/API/endpoint";
        public string _endpoint_url = "";
        public string _email = "";
        public string _password = "";
        public string _token_string = "";
        public DateTime _token_created = DateTime.Now;
        public token _token;

        #endregion

        #endregion
    }
}
