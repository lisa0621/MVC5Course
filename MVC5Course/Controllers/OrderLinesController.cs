using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class OrderLinesController : Controller
    {
        private FabricsEntities db = new FabricsEntities();
        OrderRepository orderRepo = RepositoryHelper.GetOrderRepository();

        // GET: OrderLines
        public ActionResult Index(int productId, string OrderStatus)
        {
            ViewBag.productId = productId;

            //var plist = orderRepo.All().GroupBy(x => x.OrderStatus).Select(g => g.Key);
            var plist = db.OrderLine.GroupBy(x => x.Order.OrderStatus).Select(g => g.Key);
            var orderLine = db.OrderLine.Where(x => x.ProductId == productId);

            var list = from p in orderLine
                       group p by p.Order.OrderStatus into g
                       select g.Key;

            ViewBag.OrderStatus = new SelectList(list);
            ViewBag.OrderStatusSelected = OrderStatus;

            if (!String.IsNullOrEmpty(OrderStatus))
            {
                orderLine = orderLine.Where(x => x.Order.OrderStatus == OrderStatus);
            }

            return PartialView("Index", orderLine.ToList());
        }

        // GET: OrderLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLine.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // GET: OrderLines/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Order, "OrderId", "OrderStatus");
            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "ProductName");
            return View();
        }

        // POST: OrderLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,LineNumber,ProductId,Qty,LineTotal")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.OrderLine.Add(orderLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Order, "OrderId", "OrderStatus", orderLine.OrderId);
            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "ProductName", orderLine.ProductId);
            return View(orderLine);
        }

        // GET: OrderLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLine.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Order, "OrderId", "OrderStatus", orderLine.OrderId);
            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "ProductName", orderLine.ProductId);
            return View(orderLine);
        }

        // POST: OrderLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,LineNumber,ProductId,Qty,LineTotal")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Order, "OrderId", "OrderStatus", orderLine.OrderId);
            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "ProductName", orderLine.ProductId);
            return View(orderLine);
        }

        // POST: OrderLines/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int OrderId, int LineNumber, string OrderStatus)
        {
            OrderLine ol = db.OrderLine.Find(OrderId, LineNumber);
            db.OrderLine.Remove(ol);
            db.SaveChanges();
            //return RedirectToAction("Index");

            var productId = ol.ProductId;
            ViewBag.productId = ol.ProductId;

            //var plist = orderRepo.All().GroupBy(x => x.OrderStatus).Select(g => g.Key);
            var plist = db.OrderLine.GroupBy(x => x.Order.OrderStatus).Select(g => g.Key);
            var orderLine = db.OrderLine.Where(x => x.ProductId == productId);

            var list = from p in orderLine
                       group p by p.Order.OrderStatus into g
                       select g.Key;

            ViewBag.OrderStatus = new SelectList(plist);
            ViewBag.OrderStatusSelected = OrderStatus;

            if (!String.IsNullOrEmpty(OrderStatus))
            {
                orderLine = orderLine.Where(x => x.Order.OrderStatus == OrderStatus);
            }

            return PartialView("Index", orderLine.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
