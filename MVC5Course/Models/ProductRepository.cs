using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public IQueryable<Product> Get���o�e��10���d�Ҹ��()
        {
            return this.All().Where(p => p.ProductId < 10);
        }

	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}