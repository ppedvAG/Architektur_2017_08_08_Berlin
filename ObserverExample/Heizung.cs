using System;

namespace ObserverExample
{
    internal class Heizung : ITemperaturÜberwacher
    {
        private bool _istEingeschalten = false;

        public void NeueTemperatur(int temperatur)
        {
            if(!_istEingeschalten && temperatur < 15)
            {
                _istEingeschalten = true;
                Console.WriteLine("Heizung einschalten.");
            }
            else if(_istEingeschalten && temperatur > 24)
            {
                _istEingeschalten = false;
                Console.WriteLine("Heizung ausschalten.");
            }
        }
    }
}