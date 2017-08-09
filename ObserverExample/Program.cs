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

            //sensor.Anmelden(heizung);
            //sensor.Anmelden(kühlung);

            sensor.TemperaturGeändert += heizung.NeueTemperatur;
            sensor.TemperaturGeändert += kühlung.NeueTemperatur;
            sensor.TemperaturGeändert += Display;
            sensor.TemperaturGeändert += t => Console.WriteLine($"Lambda: {t}");

            sensor.MesseTemperatur(10);
            Console.WriteLine();

            //sensor.Abmelden(heizung);
            sensor.TemperaturGeändert -= heizung.NeueTemperatur;
            sensor.MesseTemperatur(40);

            Console.WriteLine();
            sensor.MesseTemperatur(25);

            Console.ReadKey();
        }

        private static void Display(int t)
        {
            Console.WriteLine($"Neue Temperatur: {t}°C");
        }
    }
}
