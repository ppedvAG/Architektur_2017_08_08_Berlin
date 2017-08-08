using System;

namespace FactoryMethodExample
{
    internal class Kantine
    {
        internal static IEssen GibEssen()
        {
            var time = DateTime.Now.Hour;

            if (time > 6 && time <= 12)
                return new Frühstück();
            if (time > 12 && time <= 16)
                return new Mittagessen();
            if (time > 16 && time < 22)
                return new Abendessen();

            return new KeinEssen();
        }
    }
}