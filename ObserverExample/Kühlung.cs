using System;

namespace ObserverExample
{
    internal class Kühlung : ITemperaturÜberwacher
    {
        private bool _istEingeschalten = false;

        public void NeueTemperatur(int temperatur)
        {
            if(!_istEingeschalten && temperatur > 30)
            {
                _istEingeschalten = true;
                Console.WriteLine("Kühlung einschalten.");
            }
            else if(_istEingeschalten && temperatur < 26)
            {
                _istEingeschalten = false;
                Console.WriteLine("Kühlung ausschalten.");
            }
        }
    }
}