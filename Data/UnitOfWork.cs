using Core;
using Core.Repositories;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FroshDbContext _context;

        public ICustomerRepository Customers { get; }
        public IProductRepository Products { get; }

        public UnitOfWork(FroshDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(context);
            Products = new ProductRepository(context);
        }

        public void Complete() => _context.SaveChanges();
        public void Dispose() => _context.Dispose();
    }
}
