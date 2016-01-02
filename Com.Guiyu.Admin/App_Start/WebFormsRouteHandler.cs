using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;

namespace Com.Guiyu.Admin.App_Start
{
    public class WebFormsRouteHandler : IRouteHandler
    {
        private string _pageName = string.Empty;

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            // 从URL中获取page参数
            _pageName = requestContext.RouteData.GetRequiredString("page");
            IHttpHandler hander = BuildManager.CreateInstanceFromVirtualPath("/WebForms/" + this._pageName + ".aspx", typeof(System.Web.UI.Page)) as IHttpHandler;
            return hander;
        }
    }
}