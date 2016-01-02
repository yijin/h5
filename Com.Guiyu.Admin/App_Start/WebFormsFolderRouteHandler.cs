using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;

namespace Com.Guiyu.Admin.App_Start
{
    /// <summary>
    /// 对WebForms里的子文件夹路径处理
    /// </summary>
    public class WebFormsFolderRouteHandler : IRouteHandler
    {
        private string _folderName = string.Empty;
        private string _pageName = string.Empty;

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            // 从URL中获取folder参数
            _folderName = requestContext.RouteData.GetRequiredString("folder");
            // 从URL中获取page参数
            _pageName = requestContext.RouteData.GetRequiredString("page");

            IHttpHandler hander;
            // 创建实例
            // 根据folder 和 page 参数拼接成类似/WebForms/folder/page.aspx地址来访问WebForms页面
            hander = BuildManager.CreateInstanceFromVirtualPath("/WebForms/" + this._folderName + "/" + this._pageName + ".aspx", typeof(System.Web.UI.Page)) as IHttpHandler;
            return hander;

        }
    }
}