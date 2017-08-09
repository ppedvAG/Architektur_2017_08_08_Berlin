using DecoratorExample.Core;
using DecoratorExample.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DecoratorExample.Decorators
{
    internal class LoggingDataService : DataServiceDecorator
    {
        private readonly ILogger _logger;

        public LoggingDataService(IDataService baseDataService, ILogger logger)
            : base(baseDataService)
        {
            _logger = logger;
        }

        public override IEnumerable<string> GetAllProducts()
        {
            // logging
            _logger.Log($"{DateTime.Now.ToString("hh:mm:ss:fff")}: Produkte werden geladen.");

            var data = BaseDataService.GetAllProducts();

            // logging
            _logger.Log($"{DateTime.Now.ToString("hh:mm:ss:fff")}: {data.Count()} Produkte geladen.");

            return data;
        }
    }
}
