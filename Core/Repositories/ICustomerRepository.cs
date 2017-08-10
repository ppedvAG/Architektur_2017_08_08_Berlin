using Core.Models;
using System.Collections.Generic;

namespace Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetWithProducts(int id);
        IEnumerable<(int ergebnis, Customer customer)> CallStoredProcedure();
    }
}
