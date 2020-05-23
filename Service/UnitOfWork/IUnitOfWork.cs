using CommonTypes.Response;
using Service.Category;
using Service.Product;
using System;

namespace Service.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        ServicePrimitiveResponse Commit(long userId);
    }
}