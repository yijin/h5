using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Guiyu.Utils.Tool;
using Com.Guiyu.Utils.Caching;
using Com.Guiyu.Utils.Config;

namespace Com.Guiyu.Utils.Tool
{
    public static class  TGroupUserAuth
    {


        private static string GetToken(string timeStamp, string nonceStr,int groupid,int userid)
        {

            return KSHA1Util.Sha1("userid="+userid+"&groupid=" + groupid + "&timestamp=" + timeStamp + "&noncestr=" + nonceStr + "&key=" + KAuthConfig.YijinTokenKey);
        }


        public static string GetGroupTokenEndUrlParameters(int groupid, int userid)
        {
            string token = KCache.GetCacheStr(KAuthConfig.YijinTokenKey+"&"+groupid+"&"+userid);
            if (String.IsNullOrEmpty(token))
            {
                string timeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
                string nonceStr = KNoncestr.CreateNoncestr(8);
                token = "timestamp=" + timeStamp + "&noncestr=" + nonceStr + "&token=" + GetToken(timeStamp, nonceStr,groupid,userid);
                KCache.AddCacheObj(KAuthConfig.YijinTokenKey + "&" + groupid + "&" + userid, token, KAuthConfig.GroupUserTokenKeepTime / 60);
            }
            return token;
        }

        public static bool CheckToken(string timeStamp, string nonceStr, string token, int groupid, int userid)
        {
            //throw new Exception(GetToken(timeStamp, nonceStr, groupid, userid) + "&userid=" + userid + "&groupid=" + groupid + "&timestamp=" + timeStamp + "&noncestr=" + nonceStr + "&key=" + KAuthConfig.YijinTokenKey);
            return GetToken(timeStamp, nonceStr, groupid, userid) ==token;
        }
    }
}
