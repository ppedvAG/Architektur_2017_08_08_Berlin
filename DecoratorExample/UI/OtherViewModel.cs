using DecoratorExample.Core;

namespace DecoratorExample.UI
{
    internal class OtherViewModel
    {
        private readonly IDataService _ds;

        public OtherViewModel(IDataService ds)
        {
            _ds = ds;
        }
    }
}
