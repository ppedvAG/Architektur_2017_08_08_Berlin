using System;

namespace ObserverExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var heizung = new Heizung();
            var kühlung = new Kühlung();

            var sensor = new Sensor();

            sensor.Anmelden(heizung);
            sensor.Anmelden(kühlung);

            sensor.MesseTemperatur(10);
            Console.WriteLine();

            sensor.Abmelden(heizung);
            sensor.MesseTemperatur(40);

            Console.WriteLine();
            sensor.MesseTemperatur(25);

            Console.ReadKey();
        }
    }
}
