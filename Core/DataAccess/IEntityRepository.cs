using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess       
{   //generic constraint generici filtirleyirik
    // class: referans tip ola biler demekdi class ola biler demek deyil
    // T:class,IEntity T bir referans tipdir ya IEntity ola biler yadaki ondan implement olan
    // new(): newlee bilir olmali (IEntity intefacedi ve interface newlene bilmez)
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {   
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
