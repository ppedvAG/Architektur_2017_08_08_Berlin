using System.Collections.Generic;

namespace Core.Models
{
    public class Customer : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ICollection<Product> Products { get; } = new HashSet<Product>();
    }
}
