using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;
using Omu.ValueInjecter;

namespace MVC5Course.Controllers
{
    public class ProductsController : Controller
    {
        //private FabricsEntities db = new FabricsEntities();

        ProductRepository repo = RepositoryHelper.GetProductRepository();

        //// GET: Products
        //public ActionResult Index(string search)
        //{
        //    var data = db.Product.AsQueryable();

        //    data = data.
        //            Where(p => p.ProductId < 10);

        //    if (!String.IsNullOrEmpty(search))
        //    {
        //        data = data.Where(p => p.ProductName.Contains(search));
        //    }

        //    var data1 = from p in db.Product
        //                where p.ProductName.Contains("100")
        //                orderby p.ProductName
        //                select p;

        //    var data2 = from p in db.Product
        //                where p.ProductName.Contains("100")
        //                orderby p.ProductName
        //                select new NewProductVM
        //                {
        //                    ProductName = p.ProductName,
        //                    Price = p.Price
        //                };

        //    return View(data);
        //}

        // GET: Products
        public ActionResult Index(string search)
        {
            //return View(db.Product.ToList());
            //var data = db.Product
            //    .Where(x => x.ProductName.Contains("100"))
            //    .OrderBy(p => p.ProductName);


            //var data = db.Product.AsQueryable();
            //data.Where(x => x.ProductName.Contains("100"));

            //if (true)
            //{
            //    data.Where(p => p.Active == true);
            //}
            //data.OrderBy(p => p.ProductName);


            //var data1 = from p in db.Product
            //            where p.ProductName.Contains("100")
            //            orderby p.ProductName
            //            select p;


            ////馬上取回來
            //data1.ToList();


            ////輸出轉型別
            //var data2 = from p in db.Product
            //            where p.ProductName.Contains("100")
            //            orderby p.ProductName
            //            select new NewProductVM
            //            {
            //                ProductName = p.ProductName,
            //                Price = p.Price
            //            };

            //var data3 = db.Product.AsQueryable();
            //data3.Where(x => x.ProductId < 10);


            //var data4 = db.Product.AsQueryable();

            //if (!String.IsNullOrEmpty(search))
            //{
            //    data4 = data4.Where(x => x.ProductName.Contains(search));
            //}

            
            //var data = db.Product.Where(x => x.ProductId < 10);
            //var data = repo.Where(x => x.ProductId < 10);
            var data = repo.Get取得前面10筆範例資料();

            if (!String.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.ProductName.Contains(search));
            }

            return View(data);

        }

        public ActionResult BatchUpdate()
        {

            //db.Database.ExecuteSqlCommand("UPDATE dbo.Product SET Price=5 WHERE ProductId < @p0", 10);

            //var data = db.Product.Where(x => x.ProductId < 10);
            var data = repo.Get取得前面10筆範例資料();

            foreach (var item in data)
            {
                item.Price = 5;
            }
            try
            {
                //db.SaveChanges();
                repo.UnitOfWork.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
                //var allErrors = new List<string>();

                //foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
                //{
                //    foreach (DbValidationError err in re.ValidationErrors)
                //    {
                //        allErrors.Add(err.ErrorMessage);
                //    }
                //}

                //ViewBag.Errors = allErrors;
            }

            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            //Product product = db.Product.Where(x => x.ProductId == id).FirstOrDefault();
            //Product product = db.Product.FirstOrDefault(x => x.ProductId == id);
            Product product = repo.GetByID(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                //db.SaveChanges();
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.GetByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(product).State = EntityState.Modified;
                (repo.UnitOfWork.Context).Entry(product).State = EntityState.Modified;

                //db.SaveChanges();
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.GetByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = db.Product.Find(id);
            Product product = repo.GetByID(id);

            //var orderLines = db.OrderLine.Where(p => p.ProductId == id);
            //var orderLines = product.OrderLine.ToList();
            //foreach (var item in orderLines)
            //{
            //    db.OrderLine.Remove(item);
            //}

            //一次刪掉多筆
            //db.OrderLine.RemoveRange(product.OrderLine);

            //db.Product.Remove(product);
            repo.Delete(product);

            //db.SaveChanges();
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }

        public string TestInsert()
        {
            var db = new FabricsEntities();
            var prod = new Product()
            {
                ProductName = "EF",
                Price = 99,
                Stock = 5,
                Active = true
            };
            db.Product.Add(prod);

            db.SaveChanges();

            return "OK: "+prod.ProductId;
        }

        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(NewProductVM product)
        {
            if (ModelState.IsValid)
            {
                //var prod = new Product();
                //prod.ProductName = product.ProductName;
                //prod.Price = product.ProductPrice;
                //prod.Stock = 10;
                //prod.Active = true;

                var prod = Mapper.Map<Product>(product);
                prod.Stock = 10;
                prod.Active = true;

                repo.Add(prod);
                try
                {
                    //db.SaveChanges();
                    repo.UnitOfWork.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    //throw ex;
                    var allErrors = new List<string>();

                    foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
                    {
                        foreach (DbValidationError err in re.ValidationErrors)
                        {
                            allErrors.Add(err.ErrorMessage);
                        }
                    }

                    ViewBag.Errors = allErrors;
                }

                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
