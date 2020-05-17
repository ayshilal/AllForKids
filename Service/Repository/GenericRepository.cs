using CommonType;
using CommonTypes.Page;
using CommonTypes.Response;
using Microsoft.EntityFrameworkCore;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public EntityLibrary.AppDBContext Context { get; set; }

        public GenericRepository(EntityLibrary.AppDBContext iarContext)
        {
            Context = iarContext;
        }

        public virtual List<T> GetAll()
        {
            return new List<T>(Context.Set<T>());
        }

        public virtual List<T> FindAllBy(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public IPagedList<T> GetForPaging(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> sortCondition, int pageIndex = 0, int pageSize = Int32.MaxValue)
        {
            return new PagedList<T>(Context.Set<T>().Where(predicate).OrderByDescending(sortCondition), pageIndex, pageSize);
        }

        public virtual T FindFirstBy(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual T Find(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Context.Set<T>().Add(entity);
                Context.Entry(entity).State = EntityState.Added;
            }
            catch (Exception dbEx)
            {
                throw new Exception("GenericRepository Add", dbEx);
            }
        }
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Context.Set<T>().Remove(entity);
                Context.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception dbEx)
            {
                throw new Exception("Generic Repository Delete", dbEx);
            }
        }

        public virtual void Delete(IQueryable<T> entities)
        {
            try
            {
                if (!entities.Any())
                    throw new ArgumentNullException("entities");

                foreach (T entity in entities.ToList())
                    Context.Set<T>().Remove(entity);
            }
            catch (Exception dbEx)
            {
                throw new Exception("Generic Repository Delete", dbEx);
            }
        }

        public virtual void Edit(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

            }

            catch (Exception dbEx)
            {
                throw new Exception("GenericRepository Edit", dbEx);
            }
        }

        public void Refresh(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Context.Entry(entity).Reload();
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork.UnitOfWork(Context);
                }
                return unitOfWork;
            }
        }

        private IUnitOfWork unitOfWork;

        public ServicePrimitiveResponseObject<T> NoDataFound(bool NoDataFound = true)
        {
            return new ServicePrimitiveResponseObject<T> { ResponseCode = ResponseCode.NO_RECORD_FOUND };
        }
        public ServicePrimitiveResponse NoDataFound()
        {
            return new ServicePrimitiveResponse { ResponseCode = ResponseCode.NO_RECORD_FOUND };
        }
        public ServicePrimitiveResponse IncorrectData(string message)
        {
            var servicePrimitiveResponse = new ServicePrimitiveResponse { ResponseCode = ResponseCode.INCORRECT_DATA };
            servicePrimitiveResponse.Errors.Add(message);
            return servicePrimitiveResponse;
        }


        public ServicePrimitiveResponse IncorrectData(IList<string> errors)
        {
            return new ServicePrimitiveResponse { ResponseCode = ResponseCode.INCORRECT_DATA, Errors = errors };
        }
    }
}