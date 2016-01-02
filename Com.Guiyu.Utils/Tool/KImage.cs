using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.Utils.Tool
{
   public static class KImage
    {
       public static System.Drawing.Imaging.ImageFormat GetImageType(string imgname)
       {
           System.Drawing.Imaging.ImageFormat type = null;
           string newext = KFile.GetFileExtensions(imgname);
           if (newext!="")
           {
           
               switch (newext)
               {
                   case "gif":
                       type = System.Drawing.Imaging.ImageFormat.Gif;
                       break;
                   case "jpg":
                       type = System.Drawing.Imaging.ImageFormat.Jpeg;
                       break;
                   case "jpeg":
                       type = System.Drawing.Imaging.ImageFormat.Jpeg;
                       break;
                   case "png":
                       type = System.Drawing.Imaging.ImageFormat.Png;
                       break;
               }
           }


           return type;
       }
       public static String GetImageTypeDes(string imgname)
       {
      
           string newext = KFile.GetFileExtensions(imgname);
           if (newext != "")
           {

               switch (newext)
               {
                   case "gif":
                       return "gif";
                       break;
                   case "jpg":
                       return "jpg";
                       break;
                   case "jpeg":
                       return "jpg";
                       break;
                   case "png":
                       return "png";
                       break;
               }
           }


           return "jpg";
       }

     
    }
}
