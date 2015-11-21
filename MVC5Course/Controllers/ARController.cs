using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult PartialIndex()
        {
            return PartialView("Index");
        }

        public ActionResult ContentIndex()
        {
            return Content("<h1>Hello World</h1>", "text/plain");
        }

        public string StringIndex()
        {
            //糟糕的寫法－應在view做
            return "<h1>Hello World</h1>";
        }

        public ActionResult FileIndex()
        {
            string fileName = Server.MapPath(@"~/Content/test.xlsx");
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(fileName, contentType, "簡易預算表.xlsx");
        }


        public ActionResult ImageIndex()
        {
            string fileName = Server.MapPath(@"~/Content/avatarpic-xl.png");
            string contentType = "image/png";
            return File(fileName, contentType);
        }

        public ActionResult ImageDownload()
        {
            string fileName = Server.MapPath(@"~/Content/avatarpic-xl.png");
            string contentType = "image/png";
            return File(fileName, contentType, Path.GetFileName(fileName));
        }

        public ActionResult JsonIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JsonData()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(5).ToList();
            return Json(data);

            //return Json(new {
            //    id = 1,
            //    Name = "Sha"
            //});
        }

        public ActionResult RedirectToIndex()
        {
            //var a = new ViewResult();
            //a.ViewName = "Index";
            //a.ExecuteResult(this.);
            return RedirectToActionPermanent("Index");

        }
    }
}