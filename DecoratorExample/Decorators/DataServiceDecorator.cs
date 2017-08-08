using System.Collections.Generic;
using DecoratorExample.Core;

namespace DecoratorExample.Decorators
{
    internal abstract class DataServiceDecorator : IDataService
    {
        protected IDataService BaseDataService { get; }

        public DataServiceDecorator(IDataService baseDataService)
        {
            BaseDataService = baseDataService;
        }

        public abstract IEnumerable<string> GetAllProducts();
    }
}
