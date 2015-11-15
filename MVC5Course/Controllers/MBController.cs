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

        public ActionResult SimpleBinding(int p1 = 1, string p2 = "", double p3 = 0)
        {
            return Content(p1+" "+ p2+" "+p3);
        }

        public ActionResult FormBinding()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult FormBinding(double Price, FormCollection form)
        //{
        //    //form["Price"]

        //    return View();
        //}

        /// <summary>
        /// 強型別
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FormBinding(Product data)
        {
            //form["Price"]

            return Json(data);
        }
    }
}