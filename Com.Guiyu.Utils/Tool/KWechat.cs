using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Guiyu.Utils.Tool;
using Com.Guiyu.Utils.Config;
using System.Web;


namespace Com.Guiyu.Utils.Tool
{
    public static class KWechat
    {
        private static readonly object GetWineyunTokenObj = new object();
        private static readonly string WineyunTokenCacheKey = "WineyunToken";


        public static string WineyunAppId
        {
            get
            {
                return "wx00e096275469f624";
            }
        }

        public static string WineyunOpenId
        {
            get
            {
                return "gh_63eb3cab474d";
            }
        }

        public static string VinehooOpenId
        {
            get
            {
                return "gh_fa25b48c7875";
            }
        }

        /// <summary>
        /// 商户号
        /// </summary>
        public static string WineyunPartner
        {
            get
            {
                return "1218964201";
            }
        }

        public static string WineyunPartnerKey
        {
            get
            {
                return "42a7cb2f716e6405e3ebe718a657dab6";
            }
        }

        public static string WineyunAppkey
        {
            get
            {
                return "MH7G7XJldqIdzHJ23i4F13KVeT7eQ3Nm9jobjB4XOHiXXyVaEcDDy1UrvTJmTYbwBKlDutEDvXlvHQ1yTvSJvUruJ3q1D1fZtkp6cvNSdEe148eqVkHhLkIPE5VFw16D";
            }
        }

        public static string WineyunAppSecret
        {
            get
            {
                return "c9c88bf603f15247446d424a5bd2619c";
            }
        }

        public static string GetWineyunToken()
        {

            lock (GetWineyunTokenObj)
            {
                string token = KCache.GetCacheStr(WineyunTokenCacheKey);
                if (String.IsNullOrEmpty(token))
                {
                    string str = KHttpWebResponse.Get("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + WineyunAppId + "&secret=" + WineyunAppSecret + "", null);
                    if (str != null || !String.IsNullOrEmpty(str))
                    {
                        Dictionary<string, Object> json = KJson.DecodeJson(str);
                        if (json != null)
                        {
                            string access_token = json["access_token"] + "";
                            string expires_in = json["expires_in"] + "";
                            if (!String.IsNullOrEmpty(access_token))
                            {
                                int expires = Convert.ToInt32(expires_in) / 2;
                                KCache.AddCacheObj(WineyunTokenCacheKey, access_token, expires / 60);

                                token = access_token;
                            }

                        }
                    }
                    if (String.IsNullOrEmpty(token))
                    {
                        // KLogs.WriteError("获取token失败", "token:" + str);
                    }
                }

                return token;
            }
        }

        //发货
   
        public static string GetUserMsg()
        {
            string str = KHttpWebResponse.Get("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + KWechat.GetWineyunToken() + "&openid=" + KWechat.WineyunAppId + "&lang=zh_CN", null);
            return str;
        }


        public static string FormatQueryParaMap(Dictionary<string, string> parameters)
        {

            string buff = "";
            try
            {

                var result = from pair in parameters orderby pair.Key select pair;
                foreach (KeyValuePair<string, string> pair in result)
                {
                    if (pair.Key != "")
                    {
                        buff += pair.Key + "="
                                + System.Web.HttpUtility.UrlEncode(pair.Value) + "&";
                    }
                }
                if (buff.Length == 0 == false)
                {
                    buff = buff.Substring(0, (buff.Length - 1) - (0));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return buff;
        }

        public static bool ClientIsWechat()
        {
            if (HttpContext.Current.Request.UserAgent.IndexOf("MicroMessenger") >= 0)
            {
                return true;
            }
            return false;
        }


        public static String GetVesion()
        {
            int index = HttpContext.Current.Request.UserAgent.IndexOf("MicroMessenger");
            if (index >= 0)
            {
                return HttpContext.Current.Request.UserAgent.Substring(index + "MicroMessenger".Length + 1);
            }
            return "";
        }

        public static bool CanPay()
        {
            if (ClientIsWechat() && GetVesion().CompareTo("5.0") > 0)
            {
                return true;
            }
            return false;
        }


        public static string GetEndUrlParameter(string fromUserName, string toUserName)
        {
            string nonceStr = KNoncestr.CreateNoncestr(8);
            string timeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
            string sign = GetSign(fromUserName, toUserName, nonceStr, timeStamp);
            return "fromUserName=" + fromUserName + "&toUserName=" + toUserName + "&nonceStr=" + nonceStr + "&timeStamp=" + timeStamp + "&sign=" + sign;
        }

        public static string GetSign(string fromUserName, string toUserName, string nonceStr, string timeStamp)
        {
            //第一步，对所有需要传入的参数加上appkey作一次key＝value字典序的排序
            string keyvaluestring = "fromUserName=" + fromUserName + "&toUserName=" + toUserName + "&nonceStr=" + nonceStr + "&timeStamp=" + timeStamp + "&appkey=" + WineyunAppkey;
            return KSHA1Util.Sha1(keyvaluestring);
        }

    }
}
