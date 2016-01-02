using System;
using System.Collections.Generic;
using System.Text;
using System.Web;


namespace Com.Guiyu.Utils.Tool
{
    public class KCookie
    {
        //设置单点登录后之前的cookie获取出现问题 所以给所有cookie的名字前加一个字符
        private const string NewNameHeader = "Yijin";
        private const string WineyunNewNameHeader = "WINEYUN";
        private const string Domain = "Yijin.com";
        private const string wineyunDomain = "wineyun.com";
        /// <summary>
        /// 添加一个Cookie
        /// </summary>
        public static void WriteCookie(string CoName, string CoValue)
        {
            string YijinCoName = NewNameHeader + CoName;
            string wineyunCoName = WineyunNewNameHeader + CoName;
            try
            {
                if (HttpContext.Current.Request.Browser.Cookies)
                {

                    //酒斛网
                    HttpCookie aCookie = new HttpCookie(YijinCoName);
                    aCookie.Value = CoValue;
                    aCookie.Domain = Domain;
                    aCookie.Path = "/";
                    HttpContext.Current.Response.Cookies.Add(aCookie);

                    HttpCookie aCookie2 = new HttpCookie(wineyunCoName);
                    aCookie2.Value = CoValue;
                    aCookie2.Domain = wineyunDomain;
                    aCookie2.Path = "/";
                    HttpContext.Current.Response.Cookies.Add(aCookie2);


                    HttpCookie aCookie3 = new HttpCookie(CoName);
                    aCookie3.Value = CoValue;
                    aCookie3.Path = "/";
                    HttpContext.Current.Response.Cookies.Add(aCookie3);
                }
                else
                {
                    HttpContext.Current.Session[CoName] = CoValue;
                }
            }
            catch { }
        }


        public static void WriteCookieByNoGobal(string CoName, string CoValue)
        {
          
            try
            {
                if (HttpContext.Current.Request.Browser.Cookies)
                {

                    HttpCookie aCookie3 = new HttpCookie(CoName);
                    aCookie3.Value = CoValue;
                    aCookie3.Path = "/";
                    HttpContext.Current.Response.Cookies.Add(aCookie3);
                }
                else
                {
                    HttpContext.Current.Session[CoName] = CoValue;
                }
            }
            catch { }
        }

        /// <summary>
        /// 添加一个计时COOKIE
        /// </summary>
        /// <param name="CoName"></param>
        /// <param name="CoValue"></param>
        /// <param name="CoTime">天数</param>
        public static void WriteCookie(string CoName, string CoValue, int CoTime)
        {
            //设置单点登录后之前的cookie获取出现问题 所以给所有cookie的名字前加一个字符
            string YijinCoName = NewNameHeader + CoName;
            string wineyunCoName = WineyunNewNameHeader + CoName;

            try
            {

                if (HttpContext.Current.Request.Browser.Cookies)
                {
                    //酒斛网
                    HttpCookie aCookie = new HttpCookie(YijinCoName);
                    aCookie.Value = CoValue;
                    aCookie.Domain = Domain;
                    aCookie.Path = "/";
                    aCookie.Expires = DateTime.Now.AddDays(CoTime);
                    HttpContext.Current.Response.Cookies.Add(aCookie);

                    HttpCookie aCookie2 = new HttpCookie(wineyunCoName);
                    aCookie2.Value = CoValue;
                    aCookie2.Domain = wineyunDomain;
                    aCookie2.Path = "/";
                    aCookie2.Expires = DateTime.Now.AddDays(CoTime);
                    HttpContext.Current.Response.Cookies.Add(aCookie2);



                    HttpCookie aCookie3 = new HttpCookie(CoName);
                    aCookie3.Value = CoValue;
                    aCookie3.Expires = DateTime.Now.AddDays(CoTime);
                    aCookie3.Path = "/";
                    HttpContext.Current.Response.Cookies.Add(aCookie3);
                }
                else
                {
                    HttpContext.Current.Session[CoName] = CoValue;
                }


            }
            catch { }
        }


        public static void WriteCookieByNoGobal(string CoName, string CoValue, int CoTime)
        {
            //设置单点登录后之前的cookie获取出现问题 所以给所有cookie的名字前加一个字符
            

            try
            {

                if (HttpContext.Current.Request.Browser.Cookies)
                {
                 

                    HttpCookie aCookie3 = new HttpCookie(CoName);
                    aCookie3.Value = CoValue;
                    aCookie3.Expires = DateTime.Now.AddDays(CoTime);
                    aCookie3.Path = "/";
                    HttpContext.Current.Response.Cookies.Add(aCookie3);
                }
                else
                {
                    HttpContext.Current.Session[CoName] = CoValue;
                }


            }
            catch { }
        }
        /// <summary>
        /// 添加一个计时COOKIE
        /// </summary>
        /// <param name="CoName"></param>
        /// <param name="CoValue"></param>
        /// <param name="CoTime">时间</param>
        public static void WriteCookie(string CoName, string CoValue, DateTime CoTime)
        {
            //设置单点登录后之前的cookie获取出现问题 所以给所有cookie的名字前加一个字符
            string YijinCoName = NewNameHeader + CoName;
            string wineyunCoName = WineyunNewNameHeader + CoName;

            try
            {


                if (HttpContext.Current.Request.Browser.Cookies)
                {

                    //酒斛网
                    HttpCookie aCookie = new HttpCookie(YijinCoName);
                    aCookie.Value = CoValue;
                    aCookie.Domain = Domain;
                    aCookie.Path = "/";
                    aCookie.Expires = CoTime;
                    HttpContext.Current.Response.Cookies.Add(aCookie);

                    HttpCookie aCookie2 = new HttpCookie(wineyunCoName);
                    aCookie2.Value = CoValue;
                    aCookie2.Domain = wineyunDomain;
                    aCookie2.Path = "/";
                    aCookie2.Expires = CoTime;
                    HttpContext.Current.Response.Cookies.Add(aCookie2);


                    HttpCookie aCookie3 = new HttpCookie(CoName);
                    aCookie3.Value = CoValue;
                    aCookie3.Expires = CoTime;
                    aCookie3.Path = "/";
                    HttpContext.Current.Response.Cookies.Add(aCookie3);
                }
                else
                {
                    HttpContext.Current.Session[CoName] = CoValue;
                }


            }
            catch { }
        }

        public static void WriteCookieByNoGobal(string CoName, string CoValue, DateTime CoTime)
        {
            //设置单点登录后之前的cookie获取出现问题 所以给所有cookie的名字前加一个字符


            try
            {


                if (HttpContext.Current.Request.Browser.Cookies)
                {

                 


                    HttpCookie aCookie3 = new HttpCookie(CoName);
                    aCookie3.Value = CoValue;
                    aCookie3.Expires = CoTime;
                    aCookie3.Path = "/";
                    HttpContext.Current.Response.Cookies.Add(aCookie3);
                }
                else
                {
                    HttpContext.Current.Session[CoName] = CoValue;
                }


            }
            catch { }
        }
        /// <summary>
        /// 获取一个Cookie值
        /// </summary>
        /// <param name="CoName"></param>
        /// <returns></returns>
        public static string RequestCookie(string CoName)
        {
            string YijinCoName = NewNameHeader + CoName;
            string wineyunCoName = WineyunNewNameHeader + CoName;
            string CoValue = string.Empty;
            try
            {
                if (HttpContext.Current.Request.Browser.Cookies)
                {
                    if (HttpContext.Current.Request.Url.Host.ToLower().IndexOf(Domain) >= 0 && HttpContext.Current.Request.Cookies[YijinCoName] != null)
                    {
                        CoValue = HttpContext.Current.Request.Cookies[YijinCoName].Value.ToString();


                    }
                    else if (HttpContext.Current.Request.Url.Host.ToLower().IndexOf(wineyunDomain) > 0 && HttpContext.Current.Request.Cookies[wineyunCoName] != null)
                    {
                        CoValue = HttpContext.Current.Request.Cookies[wineyunCoName].Value.ToString();
                    }

                    else if (HttpContext.Current.Request.Cookies[CoName] != null)
                    {
                        CoValue = HttpContext.Current.Request.Cookies[CoName].Value.ToString();
                    }

                }
                else
                {
                    CoValue = HttpContext.Current.Session[CoName].ToString();
                }
            }
            catch
            {

            }
            return CoValue;
        }

        public static string RequestCookieByNoGobal(string CoName)
        {
          
            string CoValue = string.Empty;
            try
            {
                if (HttpContext.Current.Request.Browser.Cookies)
                {
                    if (HttpContext.Current.Request.Cookies[CoName] != null)
                    {
                        CoValue = HttpContext.Current.Request.Cookies[CoName].Value.ToString();
                    }

                }
                else
                {
                    CoValue = HttpContext.Current.Session[CoName].ToString();
                }
            }
            catch
            {

            }
            return CoValue;
        }


        /// <summary>
        /// 删除一个Cookie值
        /// </summary>
        public static void DeleteCookie(string CoName)
        {
            string YijinCoName = NewNameHeader + CoName;
            string wineyunCoName = WineyunNewNameHeader + CoName;
            if (HttpContext.Current.Request.Browser.Cookies)
            {
                HttpCookie aCookie1 = new HttpCookie(YijinCoName);
                aCookie1.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(aCookie1);
                HttpContext.Current.Response.Cookies.Remove(YijinCoName);

                HttpCookie aCookie2 = new HttpCookie(wineyunCoName);
                aCookie2.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(aCookie2);
                HttpContext.Current.Response.Cookies.Remove(wineyunCoName);

                HttpCookie aCookie3 = new HttpCookie(CoName);
                aCookie3.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(aCookie3);
                HttpContext.Current.Response.Cookies.Remove(CoName);
            }
            else
            {
                HttpContext.Current.Session[CoName] = "";
            }
        }


        public static void DeleteCookieByNoGobal(string CoName)
        {
           
            if (HttpContext.Current.Request.Browser.Cookies)
            {
               

                HttpCookie aCookie3 = new HttpCookie(CoName);
                aCookie3.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(aCookie3);
                HttpContext.Current.Response.Cookies.Remove(CoName);
            }
            else
            {
                HttpContext.Current.Session[CoName] = "";
            }
        }
    }
}
