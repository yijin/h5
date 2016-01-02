using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Com.Guiyu.Utils.Config
{
   public static class KPathConfig
    {
       public static string ShortDataPath
       {
           get
           {
               return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\guiyu\\shordata\\";
           }
       }

     

      

       /// <summary>
       /// 资源路径
       /// </summary>
       public static string CDNPath
       {
           get
           {
               return System.Web.Configuration.WebConfigurationManager.AppSettings["CDNPath"];
           }
       }


       public static string ImagePath
       {
           get
           {
               return System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"];
           }
       }


      public static string RssPath
       {
           get
           {
               return System.Web.Configuration.WebConfigurationManager.AppSettings["RssPath"];
           }
       }
    }
}
