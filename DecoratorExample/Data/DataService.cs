using DecoratorExample.Core;
using System.Collections.Generic;

namespace DecoratorExample.Data
{
    internal class DataService : IDataService
    {
        public IEnumerable<string> GetAllProducts()
        {
            // SQL CODE / Entity Framework
            return new List<string>
            {
                "Apfel", "Birne", "Banane"
            };
        }
    }
}
