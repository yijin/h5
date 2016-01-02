using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System;

namespace Com.Guiyu.Utils.Tool
{
    public class KRamImg
    {
        //设置验证码
        public void SetValidateCode(string RamImgStr)
        {
            //新建位图
            Bitmap newBitmap = new Bitmap(62, 22, PixelFormat.Format32bppArgb);
            //从位图获得绘图画面
            Graphics g = Graphics.FromImage(newBitmap);
            //随机数生成器
            Random r = new Random();
            //绘图画面清空
            g.Clear(Color.White);
            //绘图画面划线干扰
            for (int i = 0; i < 50; i++)
            {
                int x1 = r.Next(newBitmap.Width);
                int x2 = r.Next(newBitmap.Width);
                int y1 = r.Next(newBitmap.Height);
                int y2 = r.Next(newBitmap.Height);
                g.DrawLine(new Pen(
                                    Color.FromArgb(r.Next())),
                                    x1,
                                    y1,
                                    x2,
                                    y2
                                  );
            }
            //绘图画面点数干扰
            for (int i = 0; i < 100; i++)
            {
                int x = r.Next(newBitmap.Width);
                int y = r.Next(newBitmap.Height);
                newBitmap.SetPixel(
                                               x,
                                               y,
                                               Color.FromArgb(r.Next())
                                             );
            }
            //获得随机字符串（4位长度）
            string value = GenerateRandom(4);
            //随机字符串赋值给Session
            //Session["RandCode"] = value;
            KCookie.WriteCookie(RamImgStr, value);
            //  HttpCookie a = new HttpCookie(RamImgStr, value);
            //System.Web.HttpContext.Current.Response.Cookies.Add(a);

            //定义图片显示字体样式
            Font font = new Font(
                                   "Arial",
                                   14,
                                   FontStyle.Bold
                                );
            Random rr = new Random();
            int yy = rr.Next(1, 4);
            //定义随机字符串显示图片刷子
            LinearGradientBrush brush = new LinearGradientBrush(
                                                                  new Rectangle(0, 0, 71, 21),
                                                                  Color.Red,
                                                                  Color.Blue,
                                                                  1.2f,
                                                                  true
                                                               );
            g.DrawString(value, font, brush, 2, yy);
            g.DrawRectangle(new Pen(
                                      Color.Silver),
                                      0,
    0,
                                      70,
                                      22
                                    );
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            newBitmap.Save(ms, ImageFormat.Gif);
            //输出图片
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ContentType = "image/gif";
            System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        }

        //常量集
        private static char[] constant ={
                                        '0','1','2','3','4','5','6','7','8','9',
                                        'A','B','C','D','E','F','G','H','I','J',
                                        'K','L','M','N','O','P','Q','R','S','T',
                                        'U','V','W','X','Y','Z'
                                    };


        //生成随机字符串
        public static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(36);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(36)]);
            }
            return newRandom.ToString();
        }
    }
}
