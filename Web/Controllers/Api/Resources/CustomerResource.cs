using System.Collections.Generic;

namespace Web.Controllers.Api.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public IEnumerable<ProductResource> Products { get; set; }
    }
}
