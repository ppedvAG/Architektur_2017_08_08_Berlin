using System;
using System.Text;

namespace CompositeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var wasSoZuTunIst = new AufgabenListe("Alles Mögliche");
            var patternsÜben = new Einzelaufgabe("Alle möglichen Designpattern üben und verstehen.");
            wasSoZuTunIst.Hinzufügen(patternsÜben);
            wasSoZuTunIst.Hinzufügen(new Einzelaufgabe("Urlaub haben"));

            var kofferPacken = new AufgabenListe("Den Koffer packen.");
            kofferPacken.Hinzufügen(new Einzelaufgabe("Badesachen"));
            kofferPacken.Hinzufügen(new Einzelaufgabe("Strandtuch"));
            kofferPacken.Hinzufügen(new Einzelaufgabe("Sonnencreme"));
            wasSoZuTunIst.Hinzufügen(kofferPacken);

            patternsÜben.WirdErledigt();

            wasSoZuTunIst.WirdErledigt();

            foreach (var a in wasSoZuTunIst)
            {

            }

            Console.ReadKey();
        }
    }
}