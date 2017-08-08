using DecoratorExample.Core;
using DecoratorExample.Data;
using DecoratorExample.Decorators;
using DecoratorExample.Logging;
using DecoratorExample.UI;
using StructureMap;
using System;

namespace DecoratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ds = new DataService();
            //var logger = new ConsoleLogger();
            //var lds = new LoggingDataService(ds, logger);
            //var cds = new CachingDataService(lds);
            //var vm = new ViewModel(cds);


            var container = new Container(config =>
            {
                config.For<ILogger>().Use<ConsoleLogger>();

                config.For<IDataService>().Use<DataService>();
                config.For<IDataService>().DecorateAllWith<LoggingDataService>();
                config.For<IDataService>().DecorateAllWith<CachingDataService>();
            });


            var vm = container.GetInstance<ViewModel>();
            var ovm = container.GetInstance<OtherViewModel>();

            var vm1 = container.GetInstance<ViewModel>();
            var vm2 = container.GetInstance<ViewModel>();
            var vm3 = container.GetInstance<ViewModel>();
            var vm4 = container.GetInstance<ViewModel>();
            var vm5 = container.GetInstance<ViewModel>();
            var vm6 = container.GetInstance<ViewModel>();
            var vm7 = container.GetInstance<ViewModel>();


            while (true)
            {
                vm.Initialize();

                foreach (var product in vm.Products)
                    Console.WriteLine(product);

                Console.WriteLine();

                Console.ReadKey();
            }
        }
    }
}
