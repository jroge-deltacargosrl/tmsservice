using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TMS_Services.Infraestructure.Interfaces
{
    public interface IRepository<T> where T: class
    { 
        IEnumerable<T> get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null , params string[] includes);

        T getById(long id,params string[] includes);

        T getFirstOrDefault(Expression<Func<T, bool>> filter = null, params string[] includes);

        T create(T entity);
        T edit(T entity);
        T remove(int id);
        IEnumerable<T> removeAll();


        // Method SQL Query
        int max(Expression<Func<T,int>> expression);
        //IEnumerable<T> select(Expression<Func<T> expression);

        // persistencia en la base de datos
        int save();


    }
}