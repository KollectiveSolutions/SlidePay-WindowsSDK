using System;
using Newtonsoft.Json;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        private string serialize_json<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { });
            }
            catch (Exception e)
            {
                exception("serialize_json", "Exception while serializing object to JSON", e);
                return null;
            }
        }
    }
}

