using System;

namespace DelegatesExample
{
    public delegate string MyDelegate(int i, double d);

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del = new MyDelegate(MeineMethode);

            var result = del(5, 9.8);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static string MeineMethode(int zahl, double wert)
        {
            return (zahl + wert).ToString();
        }
    }
}
