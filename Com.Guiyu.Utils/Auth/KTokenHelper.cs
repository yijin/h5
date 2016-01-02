using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Guiyu.Utils.Tool;
using Com.Guiyu.Utils.Config;
using System.Globalization;

namespace Com.Guiyu.Utils.Auth
{
    public static class KTokenHelper
    {
        private static readonly object TokenObj = new object();



        private static string GetToken(string timeStamp, string nonceStr,string body)
        {

            return KSHA1Util.Sha1("body="+body+"&timestamp=" + timeStamp + "&noncestr=" + nonceStr + "&key=" + KAuthConfig.YijinTokenKey);
        }

        public static string GetYijinTokenRequestStr(string body)
        {
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string nonceStr = KNoncestr.CreateNoncestr(8);
            return timeStamp + "&" + nonceStr + "&" + GetToken(timeStamp, nonceStr, body);
        }

        private static bool CheckTokenHelper(string timeStamp, string nonceStr, string Yijintoken,string body)
        {

         
            return GetToken(timeStamp, nonceStr, body) == Yijintoken;
        }

        public static bool CheckToken(string tokenStr,string body)
        {

            string[] str = tokenStr.Split(new string[] { "&" }, 3, StringSplitOptions.RemoveEmptyEntries);
            if (str == null || str.Length != 3)
            {
                return false;
            }
            return CheckTokenHelper(str[0], str[1],str[2], body);
        }



    }
}
