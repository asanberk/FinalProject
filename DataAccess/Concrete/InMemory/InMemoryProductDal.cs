using DataAccess.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> 
            { 
                new Product{CategoryID=1,ProductID=1,ProductName="Bardak",UnitPrice=15,UnitInStock=15},
                new Product{CategoryID=1,ProductID=2,ProductName="Kamera",UnitPrice=500,UnitInStock=3},
                new Product{CategoryID=2,ProductID=3,ProductName="Telefon",UnitPrice=1500,UnitInStock=2},
                new Product{CategoryID=2,ProductID=4,ProductName="Klavye",UnitPrice=150,UnitInStock=65},
                new Product{CategoryID=2,ProductID=5,ProductName="Fare",UnitPrice=85,UnitInStock=1}
            };


        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda p=>    
            //SingleOrDefault tek eleman döndürür bu sorgu sonucu 2 eleman gelirse hata verir.
            //Bu yüzden Id sorgularında kullanılır
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);

          _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
           return _products;    
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return  _products.Where( p=> p.CategoryID == categoryId).ToList();       
        }

        public void Update(Product product)
        {   
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName= product.ProductName;
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.CategoryID= product.CategoryID;
            productToUpdate.UnitInStock= product.UnitInStock;
        }
        
    }
}
