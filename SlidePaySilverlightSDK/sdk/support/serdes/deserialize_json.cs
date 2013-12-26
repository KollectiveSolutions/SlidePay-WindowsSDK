using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
//using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        private T deserialize_json<T>(string json_string)
        {
            try
            {
                if (string_null_or_empty(json_string))
                {
                    log("deserialize_json null input supplied", true);
                    throw new Exception();
                }

                return JsonConvert.DeserializeObject<T>(json_string);
            }
            catch (Exception)
            {
                log("deserialize_json unable to deserialize JSON string", true);
                throw new Exception();
            }
        }
    }
}
