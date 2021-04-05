using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProuctDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProuctDal()
        {   
            //Datalari Oracle,Sql Server , Postgre ,MongoDBden gelirmis kimi simulasiya eleyirik
            _products = new List<Product> { 
                new Product{
                    ProductId = 1 ,
                    CategoryId = 1 ,
                    ProductName = "Cup",
                    UnitPrice = 15,
                    UnitsInStock = 15
                },
                new Product{
                    ProductId = 2 ,
                    CategoryId = 1 ,
                    ProductName = "Camera",
                    UnitPrice = 500,
                    UnitsInStock = 3
                },
                new Product{
                    ProductId = 3 ,
                    CategoryId = 2 ,
                    ProductName = "Telephon",
                    UnitPrice = 1500,
                    UnitsInStock = 2
                },
                new Product{
                    ProductId = 4 ,
                    CategoryId = 2 ,
                    ProductName = "Keyboard",
                    UnitPrice = 150,
                    UnitsInStock = 65
                },
                new Product{
                    ProductId = 5 ,
                    CategoryId = 2 ,
                    ProductName = "Mouse",
                    UnitPrice = 85,
                    UnitsInStock = 1
                },
            };
        }

        //Businessden gelen product veri tabanina elave olur
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);


            //_products.Remove(product); bu silmez cunki referanslar ferqlidi 
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;

            //    }
            //}
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        //Veritabanindaki datayi Businessa veririk
        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategoty(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gonderdigim urun id-sine sahip olan listedki urun id-sini tap demekdi
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
