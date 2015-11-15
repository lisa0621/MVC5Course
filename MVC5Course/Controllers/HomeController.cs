using MVC5Course.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string id)
        {
            //ViewBag.Message = "Your application description page.";
            ViewBag.Message = id;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [MyFilter]
        public ActionResult Test()
        {
            System.Diagnostics.Debug.WriteLine("Test Action");
            return View();
        }



    }
}