using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Guiyu.Admin.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/
        [Authorize]
        public ActionResult Image()
        {
            return View();
        }

    }
}
