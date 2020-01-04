using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Extensions;
using TMS_Services.Infraestructure.Interfaces;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Infraestructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly DeltaDBEntities dbContext;
        // Connection Template API ODOO
        
        public Repository(DeltaDBEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public T create(T entity)
        {
            // modificacion realizada a EF (extension method)
            return dbContext.Set<T>().createWithSaveChanges(entity);
            /*T entityAdd = contextDb.Set<T>().Add(entity);
            int rowAffected = save();
            return rowAffected > 0 ? entityAdd : null;*/
        }
        public T remove(int id)
        {
            /*var findEntity = getById(id);
            int rowAffected = save();
            T entityRemove = contextDb.Set<T>().Remove(findEntity);
            return rowAffected > 0 ? entityRemove : null;*/
            return dbContext.Set<T>().removeWithSaveChanges(id);
        }

        public IEnumerable<T> get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null, params string[] includes)
        {
            includes.ToList()
                .ForEach(i => dbContext.Set<T>().Include(i));

            IQueryable<T> query = dbContext.Set<T>();
            if (!isNull(filter))
            {
                query = query.Where(filter);
            }
            if (!isNull(orderBy))
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
            //return contextDb.Set<T>().ToList();
        }

        public T getById(long id, params string[] includes)
        {
            includes.ToList()
               .ForEach(i => dbContext.Set<T>().Include(i));
            return dbContext.Set<T>().Find(id);
        }

        public T getFirstOrDefault(Expression<Func<T, bool>> filter = null, params string[] includes)
        {
            includes.ToList()
                .ForEach(ip => dbContext.Set<T>().Include(ip));

            IQueryable<T> query = dbContext.Set<T>();
            if (!isNull(filter))
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }


        public T edit(T entity)
        {
            return dbContext.Set<T>().updateWithSaveChanges(entity);
        }

        public IEnumerable<T> removeAll()
        {
            return dbContext.Set<T>().removeAllwithSaveChanges(); // extension method
        }

        public int save() => dbContext.SaveChanges();

        public int max(Expression<Func<T, int>> expression) => dbContext.Set<T>().Max(expression);

      
    }
}