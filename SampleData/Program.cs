using Core.Models;
using Data;
using System;
using System.Data.Entity;
using System.Linq;
using Tynamix.ObjectFiller;

namespace SampleData
{
    class Program
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=FroschDb;Integrated Security=True;MultipleActiveResultSets=True";

        static void Main(string[] args)
        {
            ChangeTracker();
            Console.ReadKey();
        }

        private static void GenerateSampleData()
        {
            var customerFiller = new Filler<Customer>();
            customerFiller.Setup()
                .OnProperty(c => c.Id).IgnoreIt()
                .OnProperty(c => c.Products).IgnoreIt()
                .OnProperty(c => c.Firstname).Use(new RealNames(NameStyle.FirstName))
                .OnProperty(c => c.Lastname).Use(new RealNames(NameStyle.LastName));

            var productfiller = new Filler<Product>();
            productfiller.Setup()
                .OnProperty(p => p.Id).IgnoreIt()
                .OnProperty(p => p.Customers).IgnoreIt()
                .OnProperty(p => p.Number).Use(new PatternGenerator("P-{A:8}"))
                .OnProperty(p => p.Name).Use(new RandomListItem<string>(
                    "Apfel", "Birne", "Banane", "Mango", "Kiwi", "Kirsche",
                    "Drachenfrucht", "Banane", "Kokusnuss", "Litschi", "Papaya",
                    "Clementine", "Grapefruit", "Himbeere", "Honigmelone"))
                .OnProperty(p => p.Description).Use(new Lipsum(LipsumFlavor.InDerFremde));

            var customers = customerFiller.Create(200);
            var products = productfiller.Create(500).ToList();

            var random = new Random();

            foreach (var c in customers)
            {
                for (int i = 0; i < random.Next(3, 50); i++)
                {
                    var randomProductIndex = random.Next(0, products.Count);
                    c.Products.Add(products[randomProductIndex]);
                }
            }

            using (var context = new FroshDbContext(ConnectionString))
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }
        }

        private static void LazyLoading()
        {
            using (var context = new FroshDbContext(ConnectionString))
            {
                // Voraussetzungen für Lazy Loading
                context.Configuration.LazyLoadingEnabled = true;    // Default
                // Alle Navigationsproperties virtual!

                var customers = context.Customers.OrderBy(c => c.Lastname)
                                                 .ThenBy(c => c.Firstname)
                                                 .Take(20).ToList();

                //var customer = context.Customers.First();

                // N+1 Problem

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.Firstname} {customer.Lastname}");
                    foreach (var p in customer.Products)
                        Console.WriteLine($"\t{p.Name}");
                }
            }
        }
        private static void EagerLoading()
        {
            using (var context = new FroshDbContext(ConnectionString))
            {
                // wichtig: using System.Data.Entity;
                var customers = context.Customers.Include(c => c.Products)
                                                 .OrderBy(c => c.Lastname)
                                                 .ThenBy(c => c.Firstname)
                                                 .Take(20)
                                                 .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.Firstname} {customer.Lastname}");
                    foreach (var p in customer.Products)
                        Console.WriteLine($"\t{p.Name}");
                }
            }
        }

        private static void ChangeTracker()
        {
            using (var context = new FroshDbContext(ConnectionString))
            {
                var customers = context.Customers.AsNoTracking().OrderBy(c => c.Lastname)
                                                 .ThenBy(c => c.Firstname)
                                                 .Take(20)
                                                 .ToList();
                
                var customer = customers.First();

                customer.Firstname = "whatever";
                context.Customers.Attach(customer);

                //context.Entry(customer).State = EntityState.Modified;
                context.Entry(customer).Property(c => c.Firstname).IsModified = true;

                foreach (var entry in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(entry.State);
                }
            }
        }
    }
}
