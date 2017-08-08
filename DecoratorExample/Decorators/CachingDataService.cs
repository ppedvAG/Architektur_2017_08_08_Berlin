using System;
using System.Collections.Generic;
using DecoratorExample.Core;

namespace DecoratorExample.Decorators
{
    internal class CachingDataService : DataServiceDecorator
    {
        private DateTime lastLoadedTime;
        private IEnumerable<string> cache;

        public CachingDataService(IDataService baseDataService) 
            : base(baseDataService)
        { }

        public override IEnumerable<string> GetAllProducts()
        {
            var shouldRealoadData = (DateTime.Now - lastLoadedTime).TotalMinutes >= 1;

            if (cache == null || shouldRealoadData)
            {
                cache = BaseDataService.GetAllProducts();
                lastLoadedTime = DateTime.Now;
            }

            return cache;
        }
    }
}
