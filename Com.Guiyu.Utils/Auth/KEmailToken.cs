using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Guiyu.Utils.Tool;
using Com.Guiyu.Utils.Caching;
using Com.Guiyu.Utils.Config;
namespace Com.Guiyu.Utils.Auth
{
   public static class KEmailToken
    {

        public static string GetEmailToken(int id,  string email)
        {
            return KSHA1Util.Sha1("emial=" + email + "&id=" + id  + "&key=" + KAuthConfig.YijinTokenKey);
        }

        public static bool CheckEmailToken(int id, string email, string token)
        {


            return KSHA1Util.Sha1("emial=" + email + "&id=" + id  + "&key=" + KAuthConfig.YijinTokenKey) == token;
        }
    }
}
