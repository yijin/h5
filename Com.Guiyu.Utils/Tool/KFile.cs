using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.Utils.Tool
{
   public static class KFile
    {
       public static string GetFileExtensions(string filename)
       {
           int index = filename.LastIndexOf(".");
           if (index > 0&&filename.Length>(index+1))
           {
               return filename.Substring(index+1).ToLower();
           }
           else
           {
               return "";
           }
       }
       
    }
}
