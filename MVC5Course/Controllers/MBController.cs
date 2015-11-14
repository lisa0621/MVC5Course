using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            var data = new NewProductVM()
            {
                Price = 100,
                ProductName = "T-Shirt"
            };

            //弱
            ViewData["MyName"] = "SHA";

            //弱
            ViewBag.MyTitle = "ASP.NET MVC";
            ViewData["MyTitle"] = "ASP.NET MVC 2";

            ViewBag.Products = db.Product.Take(5).ToList();

            ViewData.Model = data;

            TempData["Msg"] = "test";

            return View(data);
        }
    }
}