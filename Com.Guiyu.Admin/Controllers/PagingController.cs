using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace Com.Guiyu.Admin.Controllers
{
    public class PagingController : Controller
    {
        //
        // GET: /Paging/

     

        public PartialViewResult Normal(int pagesize, int itemcount)
        {
            string query = Request.Url.Query;
            int curpage = 1;
            if (Request["page"] != null)
            {
                curpage = Convert.ToInt32(Request["Page"]);
            }

            if (String.IsNullOrEmpty(query) || query == "?")
            {
                query = "?page=";
            }
            else
            {
                if (Regex.IsMatch(query, @"\?page=\d+\&", RegexOptions.IgnoreCase))
                {
                    string pattern = @"page=\d+\&";
                    string replacement = "";
                    Regex rgx = new Regex(pattern);
                    string result = rgx.Replace(query, replacement);
                    query = result + "&page=";
                }
                else
                {
                    string pattern = @"\&?page=\d+";
                    string replacement = "";
                    Regex rgx = new Regex(pattern);
                    string result = rgx.Replace(query, replacement);
                    if (result == "?")
                    {
                        query = "?page=";
                    }
                    else
                    {
                        query = result + "&page=";
                    }
                }

            }
            if (itemcount < 1)
            {
                return null;
            }
            int pageCount = (itemcount - 1) / pagesize + 1;
            if (pageCount < 2)
            {
                return null;
            }
            ViewBag.Curpage = curpage;
            ViewBag.Query = query;
            ViewBag.Url = "http://" + Request.Url.Authority + Request.Path;
            ViewBag.Pagecount = pageCount;
            return PartialView();
        }



    }
}
