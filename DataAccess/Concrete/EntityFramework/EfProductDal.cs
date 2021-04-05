using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {   // c# ozel bir yapi. using icerisine yazdigimiz nesneler using bitince aninda garbage collocter gelib deyirki
            // meni bellekden at
            using (NorthwindContext context = new NorthwindContext())
            {   
                // git veri kaynagindan menim gonderdiyim Productdan bir tane nesneyi eslesdir
                //amma bu bir ekleme oldugu icin her hansi birseyle eslestirmek onu yerine direk ekleyecek
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                // git veri kaynagindan menim gonderdiyim Productdan bir tane nesneyi eslesdir
                //amma bu bir ekleme oldugu icin her hansi birseyle eslestirmek onu yerine direk ekleyecek
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList(); 
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                // git veri kaynagindan menim gonderdiyim Productdan bir tane nesneyi eslesdir
                //amma bu bir ekleme oldugu icin her hansi birseyle eslestirmek onu yerine direk ekleyecek
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
