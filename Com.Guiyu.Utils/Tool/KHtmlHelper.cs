using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Com.Guiyu.Utils.Config;

namespace Com.Guiyu.Utils.Tool
{
    public static class KHtmlHelper
    {
        private static Regex reUrl = new Regex(@"(http|ftp|https):\/\/[\w]+(.[\w]+)([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        /// <summary>
        /// 查找字符串中的链接，并给其加上<a>标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlForamrt(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return "";
            }
            //用来去除链接中的中文字符。
            MatchCollection mc = reUrl.Matches(str);
            foreach (Match m in mc)
            {
                str = str.Replace(m.Value, "<a href=" + m.Value + " target=\"_blank\">" + m.Value + "</a> ");
            }
            return str;
        }
        /// <summary>
        /// 将Html标签转化为空格
        /// </summary>
        /// <param name="strHtml">待转化的字符串</param>
        /// <returns>经过转化的字符串</returns>
        public static string StripHtml(string Htmlstring)
        {
            if (String.IsNullOrEmpty(Htmlstring))
            {
                return "";
            }
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = System.Web.HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }


        /// <summary>
        /// 将Html标签转化为空格
        /// </summary>
        /// <param name="strHtml">待转化的字符串</param>
        /// <returns>经过转化的字符串</returns>
        public static string SpaceHtml(string Htmlstring)
        {
            if (String.IsNullOrEmpty(Htmlstring))
            {
                return "";
            }
            //删除脚本

            Htmlstring = Regex.Replace(Htmlstring, "\r\n", "");
            Htmlstring = Regex.Replace(Htmlstring, "\n", "");
            Htmlstring = Regex.Replace(Htmlstring, "\r", "");
            Htmlstring = Regex.Replace(Htmlstring, "\"", "\\\"");

            // Htmlstring = System.Web.HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        /// <summary>
        /// 将Html标签转化为空格
        /// </summary>
        /// <param name="strHtml">待转化的字符串</param>
        /// <returns>经过转化的字符串</returns>
        public static string StripHtml(string Htmlstring, bool htmlEncode)
        {
            if (String.IsNullOrEmpty(Htmlstring))
            {
                return "";
            }
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            if (htmlEncode)
            {
                Htmlstring = System.Web.HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            }
            return Htmlstring;
        }


        /// <summary>
        /// 将Html标签转化为空格
        /// </summary>
        /// <param name="strHtml">待转化的字符串</param>
        /// <returns>经过转化的字符串</returns>
        public static string FormatBBSHtml(string Htmlstring)
        {
            if (String.IsNullOrEmpty(Htmlstring))
            {
                return "";
            }

            Htmlstring = Regex.Replace(Htmlstring, @"\[img\](.*?)\[/img\]", "<img src='$1' style='max-width:80%;'/>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[attach\](.*?)\[/attach\]", "<img src='http://bbs.Yijin.com/Attachment/$1' style='max-width:80%;' />", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[attachimg\](.*?)\[/attachimg\]", "<img src='http://bbs.Yijin.com/Attachment/$1' style='max-width:80%;' />", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[quote\](.*?)\[/quote\]", "<div class='bbsquote'><span class='bbsquote_label'> 引用:</span><span class='bbsquote_msg'>$1</span></div>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[url\](.??)\[/url\]", "<a href='$1' target='_blank'>$1</a>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[url=(.*?)\](.*?)\[/url\]", "<a href='$1' target='_blank'>$2</a>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[email=(.*?)\](.*?)\[/email\]", "<a href='mailto:$1' target='_blank'>$2</a>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[img=(\d*),(\d*)\](.*?)\[/img\]", "<img src='$3' width='$1' height='$2' />", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[font=(.*?)\](.*?)\[/font\]", "<font face='$1'>$2</font>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[(\w*?)=(.*?)\](.*?)\[/\1\]", "<font $1='$2'>$3</font>", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[(\w*)\](.*?)\[/\1\]", "<$1>$2</$1>", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"\[(.[^\]]*)\]", "", RegexOptions.IgnoreCase);
            //  Htmlstring= Htmlstring.Replace("bbs.Yijin.com", "b.Yijin.com");
            //  Htmlstring=Htmlstring.Replace("\r\n", "</br>");
            return Htmlstring;
        }

        /// <summary>   
        /// 取得HTML中所有图片的 URL。   
        /// </summary>   
        /// <param name="sHtmlText">HTML代码</param>   
        /// <returns>图片的URL列表</returns>   
        public static string[] GetHtmlImageUrlList(string sHtmlText)
        {
            if (String.IsNullOrEmpty(sHtmlText))
            {
                return new string[0];
            }
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(@"<img\s+[^>]*src\s*=\s*(?:(['""])(?<url>[^'""]+)\1|(?<url>\S+))[^>]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表   
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["url"].Value;
            return sUrlList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sHtmlText"></param>
        /// <returns></returns>
        public static string FormatImgHtml(string sHtmlText)
        {
            if (String.IsNullOrEmpty(sHtmlText))
            {
                return "";
            }
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(@"<img\s+[^>]*src\s*=\s*(?:(['""])(?<url>[^'""]+)\1|(?<url>\S+))[^>]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表   
            foreach (Match match in matches)
                sHtmlText.Replace(match.Value, "<img src='" + match.Groups["url"].Value + "'>");

            return sHtmlText;
        }

        /// <summary>   
        /// 取得HTML中第一张图片的 URL。   
        /// </summary>   
        /// <param name="sHtmlText">HTML代码</param>   
        /// <returns>图片的URL</returns>   
        public static string GetHtmlFirstImageUrl(string sHtmlText)
        {
            if (String.IsNullOrEmpty(sHtmlText))
            {
                return "";
            }
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(@"<img\s+[^>]*src\s*=\s*(?:(['""])(?<url>[^'""]+)\1|(?<url>\S+))[^>]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches(sHtmlText);
            string sUrl = "";
            if (matches.Count > 0)
            {
                sUrl = matches[0].Groups["url"].Value;
            }
            return sUrl;
        }


        public static string RemoveJs()
        {
            return "";
        }



    }
}
