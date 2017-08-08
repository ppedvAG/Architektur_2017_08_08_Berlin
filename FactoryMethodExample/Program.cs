using System;

namespace FactoryMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var essen = Kantine.GibEssen();

            Console.WriteLine(essen.Beschreibung);
            Console.ReadKey();
        }
    }
}