using CommonTypes.Response;
using Service.Product;
using System;

namespace Service.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IProductRepository ProductRepository { get; }

        ServicePrimitiveResponse Commit(long userId);
    }
}