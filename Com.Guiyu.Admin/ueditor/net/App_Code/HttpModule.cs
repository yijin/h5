using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

//using Vinehoo.CMS.Lib;
//using com.playgoogle.common;


/// <summary>
/// Url重写类
/// </summary>
public class HttpModule : System.Web.IHttpModule
{
    /// <summary>
    /// 实现接口的Init方法
    /// </summary>
    /// <param name="context"></param>
    public void Init(HttpApplication context)
    {
        //  context.BeginRequest += new EventHandler(ReUrl_BeginRequest);
        //  context.BeginRequest += new EventHandler(context_BeginRequest);
        context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
    }

    void context_AcquireRequestState(object sender, EventArgs e)
    {

        HttpApplication app = (HttpApplication)sender;
        HttpContext ctx = app.Context;
        if (HttpContext.Current.Session != null)
        {


           // int userid = 0;
            /*if (HttpContext.Current.Session["UserId"] != null && HttpContext.Current.Session["AuthCode"] != null && HttpContext.Current.Session["AuthCode"].ToString().Length > 0)
            {
                if (HttpContext.Current.Session["UserId"].ToString() == KMd5.Decrypt(HttpContext.Current.Session["AuthCode"].ToString(), "KARRYKAI"))
                {
                    userid = Convert.ToInt32(HttpContext.Current.Session["UserId"].ToString());
                }
            }
            if (userid <= 0 && ctx.Request.Url.AbsolutePath.ToLower().IndexOf("/ueditor/") > -1)
            {
                ctx.Response.Write(ctx.Request.Url.AbsolutePath.ToLower());
                ctx.Response.End();
            }*/

        }

    }




    public void Application_OnError(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 实现接口的Dispose方法
    /// </summary>
    public void Dispose()
    {

    }
    /// <summary>
    /// 重写Url
    /// </summary>
    /// <param name="sender">事件的源</param>
    /// <param name="e"></param>
    private void ReUrl_BeginRequest(object sender, EventArgs e)
    {
        /* HttpContext context = ((HttpApplication)sender).Context;
         string requestPath = context.Request.Path.ToLower();  ///绝对地址
         string newUrl = "";
         if (requestPath.IndexOf("/") > -1)
         {
             foreach (KSiteUrls.URLRewrite url in KSiteUrls.GetSiteUrls().Urls)
             {
                 if (Regex.IsMatch(requestPath, url.Pattern, RegexOptions.IgnoreCase))
                 {
                     newUrl = Regex.Replace(requestPath, url.Pattern, url.QueryString, RegexOptions.IgnoreCase);  
                     context.RewritePath(url.Page, string.Empty, newUrl);
                 }
             }
         }*/
    }
}

