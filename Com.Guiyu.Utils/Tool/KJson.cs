using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace Com.Guiyu.Utils.Tool
{
    public class KJson
    {
        private static JavaScriptSerializer jss = new JavaScriptSerializer();
        public static string ToJson(Object obj)
        {

            return jss.Serialize(obj);
        }

        public static Dictionary<string, object> DecodeJson(string json)
        {
            return jss.Deserialize<Dictionary<string, object>>(json);
        }
    }
}
