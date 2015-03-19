using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MySocialNetwork2.Repository
{
    public interface IRepository<T> where T : class 
    {
        void Insert(T entity);
        T FindByID(object entityId);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         string includeProperties = "");
    }
}