using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Guiyu.Utils.Tool;
using Com.Guiyu.Utils.Log;


namespace Com.Guiyu.Utils.SmsVCode
{
    public static class K189Open
    {

        static string app_id = "241109160000037934";
        static string app_secret = "5a5ae83b652ff7b02a1f2b3fa7a9359e";
        private static readonly string TokenCacheKey = "189OpenAccessToken";
        private static readonly object GetAccessTokenObj = new object();

        public static string GetAccessToken()
        {

            string token = KCache.GetCacheStr(TokenCacheKey);
            if (String.IsNullOrEmpty(token))
            {
                lock (GetAccessTokenObj)
                {
                    string str = KHttpWebResponse.Post("https://oauth.api.189.cn/emp/oauth2/v3/access_token?grant_type=client_credentials&app_id=" + app_id + "&app_secret=" + app_secret, null, Encoding.UTF8, null, "application/json");
                    if (str != null || !String.IsNullOrEmpty(str))
                    {
                        Dictionary<string, Object> json = KJson.DecodeJson(str);
                        if (json != null)
                        {
                            string access_token = json["access_token"] + "";
                            string expires_in = json["expires_in"] + "";
                            string res_code = json["res_code"] + "";
                            if (res_code == "0" && !String.IsNullOrEmpty(access_token))
                            {
                                int expires = Convert.ToInt32(expires_in) / 2;
                                KCache.AddCacheObj(TokenCacheKey, access_token, expires / 60);

                                token = access_token;
                            }

                        }
                    }
                    if (String.IsNullOrEmpty(token))
                    {
                        KExceptionLog.WriteExcetion("获取token失败", "token:" + str);
                    }
                    return token;
                }
            }
            else
            {
                return token;
            }



        }

        public static string SendSMSVC(string mobileNum,string randcode, int? exptime = 6)
        {

            SendSMSVC_API sendsmsvc = new SendSMSVC_API(app_id, app_secret, GetAccessToken(), mobileNum, exptime, randcode);
            return sendsmsvc.Result;
        }
    }
}
