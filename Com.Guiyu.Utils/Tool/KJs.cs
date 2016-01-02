using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.Guiyu.Utils.Tool
{
    public class KJs
    {
        /// <summary>
        /// 跳出警告对话框,背景页面无
        /// </summary>
        /// <param name="str"></param>
        public static void alert(string str)
        {
            HttpContext.Current.Response.Write("<script>alert('" + str + "');</script>");
        }

        /// <summary>
        /// 跳出警告对话框,背景页存在
        /// </summary>
        /// <param name="str"></param>
        /// <param name="page">当前页面,直接用this</param>
        public static void alert(string str, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "Startup", "<script>alert('" + str + "')</script>");
        }

        /// <summary>
        /// 跳出警告对话框,跳转页面,背景页面无
        /// </summary>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public static void alertgo(string str, string url)
        {
            HttpContext.Current.Response.Write("<script>alert('" + str + "');document.location='" + url + "'</script>");
        }
        /// <summary>
        /// 跳出警告对话框,跳转页面,背景页存在
        /// </summary>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public static void alertgo(string str, string url, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "Startup", "<script>alert('" + str + "');document.location='" + url + "'</script>");
        }

        /// <summary>
        /// 直接跳转页面
        /// </summary>
        /// <param name="url"></param>
        /// <param name="page"></param>
        public static void redirect(string url, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "Startup", "<script>document.location='" + url + "'</script>");
        }
        /// <summary>
        /// 跳出警告对话框,父框架跳转页面
        /// </summary>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public static void alertgoParent(string str, string url)
        {
            HttpContext.Current.Response.Write("<script>alert('" + str + "');parent.location.href='" + url + "'</script>");
        }
    }
}
