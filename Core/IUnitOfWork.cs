using Core.Repositories;
using System;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }

        void Complete();
    }
}
