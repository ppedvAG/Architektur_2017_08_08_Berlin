using System.Collections.Generic;

namespace Core.Models
{
    public class Product : Entity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Customer> Customers { get; } = new HashSet<Customer>();
    }
}
