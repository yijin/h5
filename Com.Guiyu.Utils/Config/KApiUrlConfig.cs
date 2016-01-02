using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Com.Guiyu.Utils.Config
{
    public static class KApiUrlConfig
    {
        public static string UserApiUrl
        {
            get
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings["UserApiUrl"];
            }
        }


        public static string ProductApiUrl
        {
            get
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings["ProductApiUrl"];
            }
        }

        public static string DboApiUrl
        {
            get
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings["DboApiUrl"];
            }
        }
      
    }
}
