﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		//EfProductDal
		private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
		{
			return _productDal.GetList();
		}

		public List<Product> GetByCategory(int categoryId)
		{
			return _productDal.GetList(p=>p.CategoryId==categoryId);
		}

		Product IProductService.GetById(int productId)
		{
			return _productDal.Get(p => p.ProductId == productId);
		}
	}
}
