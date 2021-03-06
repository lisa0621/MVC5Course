﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        /// <summary>
        /// 全站啟用的規則
        /// </summary>
        /// <returns></returns>
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.Active == true);
        }

        /// <summary>
        /// 全站啟用的規則
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> All(bool isGetAll)
        {
            if (isGetAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }

        //public IQueryable<Product> Get取得前面10筆範例資料()
        //{
        //    return this.All().Where(p => p.ProductId < 10);
        //}

        public IQueryable<Product> Get取得前面10筆範例資料()
        {
            return this.Get取得前面n筆範例資料(10,null);
        }

        public IQueryable<Product> Get取得前面10筆範例資料(bool active)
        {
            return this.Get取得前面n筆範例資料(10,active);
        }

        public IQueryable<Product> Get取得前面n筆範例資料(int n, bool? active)
        {
            //return this.All().Where(p => p.ProductId < n);
            //return this.All().OrderBy(p => p.ProductId).Take(n);

            var data = this.All(true);

            if (active.HasValue) {
                data = data.Where(p => p.Active.HasValue &&
                p.Active.Value == active);
            }

            return data.OrderBy(p => p.ProductId).Take(n);
        }

        public Product GetByID(int? id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id.Value);
        }

        public override void Delete(Product product)
        {
            var db = ((FabricsEntities)this.UnitOfWork.Context);
            db.OrderLine.RemoveRange(product.OrderLine);
            base.Delete(product);
        }

    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}