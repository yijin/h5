using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Guiyu.Utils.Config
{
    public static class KLogConfig
    {
        /// <summary>
        /// 日记的地址
        /// </summary>
        public static string ErrorLogUrl
        {

            get
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings["ErrorLogUrl"];
            }
        }

        /// <summary>
        /// 日记的地址
        /// </summary>
        public static string ExceptionLogUrl
        {

            get
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings["ExceptionLogUrl"];
            }
        }
    }
}
