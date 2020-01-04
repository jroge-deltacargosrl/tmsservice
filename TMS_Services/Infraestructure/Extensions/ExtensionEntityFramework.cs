using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TMS_Services.Infraestructure.Extensions
{
    public static class ExtensionEntityFramework
    {

        #region "Section Additional Configuration"
        public static DbContext getContext<TEntity>(this DbSet<TEntity> dbSet)
        where TEntity : class
        {
            object internalSet = dbSet
                .GetType()
                .GetField("_internalSet", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(dbSet);
            object internalContext = internalSet
                .GetType()
                .BaseType
                .GetField("_internalContext", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(internalSet);
            return (DbContext)internalContext
                .GetType()
                .GetProperty("Owner", BindingFlags.Instance | BindingFlags.Public)
                .GetValue(internalContext, null);
        }
        #endregion


        #region "Section Create Entities"
        public static T createWithSaveChanges<T>(this DbSet<T> dbSet, T entity) where T : class
        {
            T entityAdd = dbSet.Add(entity);
            int rowsAffected = dbSet.getContext().SaveChanges();
            return rowsAffected > 0 ? entityAdd : default;
        }

        public static IEnumerable<T> createManyWithSaveChanges<T>(this DbSet<T> dbSet, IEnumerable<T> entities) where T:class
        {
            IEnumerable<T> entitiesAdd = dbSet.AddRange(entities);
            int rowsAffected = dbSet.getContext().SaveChanges();
            return rowsAffected > 0 ? entitiesAdd : default;
        }


        #endregion

        #region "Section Update Entities"
        public static T updateWithSaveChanges<T>(this DbSet<T> dbSet, T entity) where T : class
        {
            /*T entityUpdate = dbSet.Attach(entity);
            int rowsAffected = dbSet.getContext().SaveChanges();*/
            dbSet.getContext().Entry(entity).State = EntityState.Modified;
            int rowsAffected = dbSet.getContext().SaveChanges();
            var property = entity.GetType().GetProperty("id");
            var value = property.GetValue(entity, null);
            
            return rowsAffected > 0 ? dbSet.Find(value) : default;
            
        } 
        #endregion

        #region "Section Remove Entities"

        public static T removeWithSaveChanges<T>(this DbSet<T> dbSet, int id) where T : class
        {
            T entityBeforeRemove = dbSet.Find(id);
            dbSet.Remove(entityBeforeRemove);
            int rowsAffected = dbSet.getContext().SaveChanges();
            return rowsAffected > 0 ? entityBeforeRemove : default; // analizar

        }

        public static T removeWithSaveChanges<T>(this DbSet<T> dbSet, T entity) where T : class
        {
            T entityBeforeRemove = dbSet.Find(entity);
            dbSet.Remove(entity);
            int rowsAffected = dbSet.getContext().SaveChanges();
            return rowsAffected > 0 ? entityBeforeRemove : default; // analizar

        }

        public static IEnumerable<T> removeManyWithSaveChanges<T>(this DbSet<T> dbSet, IEnumerable<T> entities) where T : class
        {
            dbSet.RemoveRange(entities);
            int rowsAffected = dbSet.getContext().SaveChanges();
            return rowsAffected > 0 ? entities : default; // analizar

        }

        public static IEnumerable<T> removeAllwithSaveChanges<T>(this DbSet<T> dbSet) where T : class
        {
            IEnumerable<T> entitiesBeforeRemove = dbSet.ToList();
            dbSet.RemoveRange(dbSet);
            int rowAffected = dbSet.getContext().SaveChanges();
            return rowAffected > 0 ? entitiesBeforeRemove : default;
        }

        #endregion




        // modificar posteriormente los metodos de eliminar y actualizar, para solo cambiar 
        // los estados


    }
}