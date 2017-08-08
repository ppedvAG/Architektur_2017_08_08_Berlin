using System.Collections.Generic;

namespace DecoratorExample.Core
{
    internal interface IDataService
    {
        IEnumerable<string> GetAllProducts();
    }
}
