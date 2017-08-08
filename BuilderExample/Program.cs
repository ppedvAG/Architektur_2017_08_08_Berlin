using System;
using System.Text;

namespace BuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var defaultSchrank = new Schrank.Builder(3).Konstruiere();
            Console.WriteLine(defaultSchrank);

            var großerSchrank = new Schrank.Builder(7)
                .AnzahlBöden(6)
                .MitOberfläche(Oberfläche.Gewachst)
                .MitKleiderstange()
                .MitMetallschienen()
                .Konstruiere();
            Console.WriteLine(großerSchrank);

            var builder = new Schrank.Builder(3);

            // Auf nächste Seit navigieren
            // es vergeht viel Zeit


            builder.MitOberfläche(Oberfläche.Lackiert);


            // Auf nächste Seit navigieren
            // es vergeht viel Zeit

            builder.MitMetallschienen();


            // Auf nächste Seit navigieren
            // es vergeht viel Zeit
            // Es wird bezahlt

            var schrank = builder.Konstruiere();

            Console.WriteLine(schrank);

            builder.AnzahlBöden(6);
            builder.MitKleiderstange();

            Console.WriteLine(schrank);

            Console.ReadKey();
        }
    }
}