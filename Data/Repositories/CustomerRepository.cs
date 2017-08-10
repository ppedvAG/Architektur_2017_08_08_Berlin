using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class CustomerRepository : Repository<FroshDbContext, Customer>, ICustomerRepository
    {
        public CustomerRepository(FroshDbContext context) : base(context) { }

        public IEnumerable<(int ergebnis, Customer customer)> CallStoredProcedure()
        {
            var result = Context.Database
                                .SqlQuery<StoredProcedureResult>("MySpecialProcedure")
                                .ToList();

            foreach (var item in result)
                yield return
                    (
                        item.Ergebnis,
                        new Customer
                        {
                            Id = item.Id,
                            Firstname = item.Firstname,
                            Lastname = item.Lastname
                        }
                    );
        }

        public Customer GetWithProducts(int id) => 
            Entries.Include(c => c.Products)
                   .SingleOrDefault(c => c.Id == id);

        private class StoredProcedureResult
        {
            public int Ergebnis { get; set; }
            public int Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
        }
    }
}
