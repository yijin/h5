using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Guiyu.Utils.Config
{
    public static class KUrlConfig
    {
       
        /// <summary>
        /// 移动网站的地址
        /// </summary>
        public static string ImageUrl
        {

            get
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings["ImageUrl"];
            }
        }

        public static string StaticUrl
        {

            get
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings["StaticUrl"];
            }
        }

    }
}
