using Entities.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic constraint
    //Class : referans tip  
    public interface IEntityRepository <T> where T : class , IEntity,new() //T  IEntity olamaz ama implement olanlar olabilir
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);  //Ürünleri getirirken filtreleme işlemi. Hiçbir filre verilemsse hepsi getirilir
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
