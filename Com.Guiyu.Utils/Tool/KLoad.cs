using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Drawing.Imaging;
using Com.Guiyu.Utils.Log;
using System.Web;
using System.Drawing;

namespace Com.Guiyu.Utils.Tool
{
    public static class KLoad
    {
        
        public static bool LoadImg(string saveimgname,string imgurl)
        {
            WebRequest wreq = WebRequest.Create(imgurl);
            HttpWebResponse wresp = (HttpWebResponse)wreq.GetResponse();
            Stream s = wresp.GetResponseStream();
            System.Drawing.Image img;
            img = System.Drawing.Image.FromStream(s);
            try
            {
                if (img != null)
                {
                    FileInfo f = new FileInfo(saveimgname);
                    if (!Directory.Exists(f.DirectoryName))
                    {
                        Directory.CreateDirectory(f.DirectoryName);
                    }
                    System.Drawing.Imaging.ImageFormat iformat = KImage.GetImageType(imgurl);

                    if (iformat != null)
                    {
                        img.Save(saveimgname, iformat);
                    }
                    else
                    {
                        img.Save(saveimgname);
                    }
                }
                if (s != null)
                {
                    s.Close();
                }
                return true;
            }
            catch(Exception e)
            {
                if (s != null)
                {
                    s.Close();
                }
                return false;
            }
            
           
        }

        public static bool LoadRequestImg(string saveimgname, ImageFormat iformat = null)
        {
    
            try
            {
                HttpPostedFile file = HttpContext.Current.Request.Files[0];

                using (System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream))
                {
                    // img = System.Drawing.Image.FromStream(s);
                    if (img != null)
                    {
                        FileInfo f = new FileInfo(saveimgname);
                        if (!Directory.Exists(f.DirectoryName))
                        {
                            Directory.CreateDirectory(f.DirectoryName);
                        }


                        if (iformat != null)
                        {
                            img.Save(saveimgname, iformat);
                            
                        }
                        else
                        {
                            img.Save(saveimgname);
                        }
                       
                    }
       
                    return true;
                }
            }
            catch(Exception e)
            {
                KExceptionLog.WriteExcetion("add", e.InnerException + "/n" + e.Message + "/n" + e.Source + "/n" + e.StackTrace + "/n");
               /* if (s != null)
                {
                    s.Close();
                }*/
                return false;
            }
            


        }



        public static bool LoadRequestImg(string saveimgname, ImageFormat iformat , string outPath, int flag, int toWidth, int toHeight)
        {

            try
            {
                HttpPostedFile file = HttpContext.Current.Request.Files[0];

                using (System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream))
                {
                   
                    if (img != null)
                    {
                        FileInfo f = new FileInfo(saveimgname);
                        if (!Directory.Exists(f.DirectoryName))
                        {
                            Directory.CreateDirectory(f.DirectoryName);
                        }


                        if (iformat != null)
                        {
                            img.Save(saveimgname, iformat);

                        }
                        else
                        {
                            img.Save(saveimgname);
                        }
                        return GetPicThumbnail(img,iformat, outPath, flag, toWidth, toHeight);
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                KExceptionLog.WriteExcetion("", e);
              
                return false;
            }



        }



        public static bool GetPicThumbnail(System.Drawing.Image iSource, ImageFormat iformat, string outPath, int flag, int toWidth, int toHeight)
        {
            ImageFormat tFormat = iformat;
            if (iformat == null)
            {
                tFormat = iSource.RawFormat;
            }
           

            int owidth = iSource.Width;
            int oheight = iSource.Height;
            if (toWidth <= 0 && toHeight <= 0)
            {
                toWidth = owidth;
                toHeight = oheight;
            }
            else if (toWidth > 0 && toHeight > 0)
            {
                if (owidth < toWidth && oheight < toHeight)
                {
                    toWidth = owidth;
                    toHeight = oheight;
                }
                    
                else
                {
                    if (((double)owidth / oheight) > ((double)toWidth / toHeight))
                    {
                        toHeight = oheight * toWidth / owidth;
                    }
                    else
                    {
                        toWidth = owidth * toHeight / oheight;
                    }
                }
            }
            else if (toWidth <= 0 && toHeight > 0)
            {
                if (oheight < toHeight)
                {
                    toWidth = owidth;
                    toHeight = oheight;
                }
                else
                {
                    toWidth = owidth * toHeight / oheight;
                }
            }
            else if (toHeight <= 0 && toWidth > 0)
            {
                if (owidth < toWidth)
                {
                    toWidth = owidth;
                    toHeight = oheight;
                }
                else
                {
                    toHeight = oheight * toWidth / owidth;
                }
            }

            Bitmap toBitmap = new Bitmap(toWidth, toHeight);


            using (Graphics g = Graphics.FromImage(toBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.Clear(Color.Transparent);
                g.DrawImage(iSource,
                            new Rectangle(0, 0, toWidth, toHeight),
                            new Rectangle(0, 0, iSource.Width, iSource.Height),
                            GraphicsUnit.Pixel);
                iSource.Dispose();
              

            }
            //以下代码为保存图片时，设置压缩质量  
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100  
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                if (iformat != null)
                {
                    toBitmap.Save(outPath, iformat);
                }
                else
                {
                    ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo jpegICIinfo = null;
                    for (int x = 0; x < arrayICI.Length; x++)
                    {
                        if (arrayICI[x].FormatDescription.Equals("JPEG"))
                        {
                            jpegICIinfo = arrayICI[x];
                            break;
                        }
                    }
                    if (jpegICIinfo != null)
                    {
                        toBitmap.Save(outPath, jpegICIinfo, ep);//dFile是压缩后的新路径  
                    }
                    else
                    {
                        toBitmap.Save(outPath, tFormat);
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                KExceptionLog.WriteExcetion("", e);
                return false;
            }
            finally
            {
                
                toBitmap.Dispose();
            }
        }
        public static async Task LoadImgAsAsync(string saveimgname, string imgurl)
        {
            await Task.Run(() =>
             {
                 LoadImg(saveimgname, imgurl);
             });
           

        }
     

    }
}
