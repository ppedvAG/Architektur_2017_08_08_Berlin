using DecoratorExample.Core;
using System.Collections.Generic;

namespace DecoratorExample.UI
{
    internal class ViewModel
    {
        private readonly IDataService _dataService;

        public IEnumerable<string> Products { get; private set; }

        public ViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void Initialize()
        {
            //var ds = new Data.DataService(); //  -> Böse

            Products = _dataService.GetAllProducts();
        }
    }
}
