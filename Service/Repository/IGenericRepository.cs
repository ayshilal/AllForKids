using CommonTypes.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service.Repository
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        List<T> GetAll();
        List<T> FindAllBy(Expression<Func<T, bool>> predicate);
        IPagedList<T> GetForPaging(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> sortCondition, int pageIndex = 0, int pageSize = Int32.MaxValue);
        T FindFirstBy(Expression<Func<T, bool>> predicate);
        T Find(int id);
        void Add(T entity);
        void Delete(T entity);
        void Delete(IQueryable<T> entities);
        void Edit(T entity);
        void Refresh(T entity);
    }
}