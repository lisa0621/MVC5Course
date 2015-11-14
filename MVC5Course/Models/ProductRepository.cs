using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public IQueryable<Product> Get取得前面10筆範例資料()
        {
            return this.All().Where(p => p.ProductId < 10);
        }

        public Product GetByID(int? id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id.Value);
        }

	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}