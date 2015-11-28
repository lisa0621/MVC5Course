using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public String GetTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH::mm:ss:ffff");
        }
    }
}