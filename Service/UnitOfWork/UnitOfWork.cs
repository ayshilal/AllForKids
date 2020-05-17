using CommonType;
using CommonTypes.Response;
using EntityLibrary;
using Service.Product;
using Service.Product.Atom;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext context;

        public UnitOfWork()
        {
            context = new AppDBContext();
        }
        public UnitOfWork(AppDBContext _context)
        {
            context = _context;
        }

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        private IProductRepository _productRepository;

        public IProductRepository ProductRepository { get { return _productRepository ?? (_productRepository = new ProductService(context)); } }
       


        public IGenericRepository<T> Repository<T>() where T : class
        {
            // It doesn't work if repositories is not static object...
            if (repositories.Keys.Contains(typeof(T)))
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            GenericRepository<T> repo = new GenericRepository<T>(context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public ServicePrimitiveResponse Commit(long userId)
        {
            ServicePrimitiveResponse primitiveResponse = new ServicePrimitiveResponse();
            try
            {
                primitiveResponse.EntityPrimaryKey = context.SaveChanges(true).ToString();
                primitiveResponse.ResponseCode = ResponseCode.SUCCESSFUL;
            }
            //catch (DbEntityValidationException dbEx)
            //{
            //    primitiveResponse.ResponseCode = ResponseCodes.DB_VALIDATION_ERROR;
            //    //while (dbEx.InnerException != null)
            //    primitiveResponse.InnerException = dbEx.InnerException;
            //    throw new Exception(dbEx.DbEntityValidationExceptionToString(), dbEx);
            //}
            catch (Exception ex)
            {
                primitiveResponse.ResponseCode = ResponseCode.DB_VALIDATION_ERROR;
                //while (ex.InnerException != null)
                primitiveResponse.InnerException = ex.InnerException;

                throw new Exception("UnitOfWork Commit Method", ex);
            }
            return primitiveResponse;
        }

        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}