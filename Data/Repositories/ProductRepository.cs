using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class ProductRepository : Repository<FroshDbContext, Product>, IProductRepository
    {
        public ProductRepository(FroshDbContext context) : base(context) { }
    }
}
