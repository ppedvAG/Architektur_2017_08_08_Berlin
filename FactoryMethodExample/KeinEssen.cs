using System;

namespace FactoryMethodExample
{
    internal class KeinEssen : IEssen
    {
        public string Beschreibung => "In der Nacht gibts nichts zu Essen.";
    }
}