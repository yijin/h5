using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using Com.Guiyu.Utils.Config;

namespace Com.Guiyu.Utils.Log
{
    public class KExceptionLog
    {
        public static void WriteExcetion(string title, string msg)
        {
            StreamWriter sw = null;
            try
            {
                string filename = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                DirectoryInfo dir = new DirectoryInfo(KLogConfig.ExceptionLogUrl);
                if (!dir.Exists)
                {
                    dir.Create();
                }

                sw = new StreamWriter(dir + filename, true, System.Text.Encoding.Default);

                sw.Write("\r\n" + HttpContext.Current.Request.Url);
                sw.Write("\r\n" + title + DateTime.Now.ToString());
                sw.Write("\r\n" + msg);
                sw.Write("\r\n");
                sw.Flush();

            }
            catch (Exception e)
            {
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }



        }

        public static void WriteExcetion( string title,Exception e)
        {
            WriteExcetion(title, e.InnerException + "/n" + e.Message + "/n" + e.Source + "/n" + e.StackTrace + "/n");
        }
   
    }
}
