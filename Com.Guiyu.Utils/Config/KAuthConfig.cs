using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Com.Guiyu.Utils.Config
{
    public static class KAuthConfig
    {
        public readonly static string YijinTokenKey = "Yijinf716e6405e3ebe718a65yijin";

        public readonly static string YijinTokenCacheKey = "YijinTokenCacheKey";

        /// <summary>
        ///用户token能保存的时间
        /// </summary>
        public readonly static int YijinTokenKeepTime = 7200;
        public readonly static int GroupUserTokenKeepTime =3600*48;

        public readonly static string YijinTokenRequestName = "YijinToken";
    }
}
