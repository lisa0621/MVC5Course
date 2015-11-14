using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller
    {
        protected FabricsEntities db = new FabricsEntities();

        public ActionResult Debug()
        {
            return View();
            //return new ViewResult() { ViewName = "About" };
        }


        /// <summary>
        /// 找不到頁面－連回首頁
        /// </summary>
        /// <param name="actionName"></param>
        protected override void HandleUnknownAction(string actionName)
        {
            if (Request.IsLocal)
            {
                //不是很好的作法
                //this.View(actionName).ExecuteResult(this.ControllerContext);
                //this.Redirect("/").ExecuteResult(this.ControllerContext);
                this.Redirect("/?unknow-action="+actionName).ExecuteResult(this.ControllerContext);
            }
            else
            {
                base.HandleUnknownAction(actionName);
            }
        }
    }
}