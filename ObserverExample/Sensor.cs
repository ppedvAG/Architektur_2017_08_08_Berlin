using System;
using System.Collections.Generic;

namespace ObserverExample
{
    internal class Sensor
    {
        //private Heizung _heizung;
        //private Kühlung _kühlung;

        //public Sensor(Heizung heizung, Kühlung kühlung)
        //{
        //    _heizung = heizung;
        //    _kühlung = kühlung;
        //}

        public event Action<int> TemperaturGeändert;

        private List<ITemperaturÜberwacher> _geräte = new List<ITemperaturÜberwacher>();

        public void MesseTemperatur(int temperatur)
        {
            // intelligente Logik um die Temperatur zu messen

            // Heizung und Kühlung müssen über der neuen Temperatur informiert werden
            //_heizung.NeueTemperatur(temperatur);
            //_kühlung.NeueTemperatur(temperatur);
            //foreach (var gerät in _geräte)
            //    gerät.NeueTemperatur(temperatur);

            TemperaturGeändert?.Invoke(temperatur);
        }

        public void Anmelden(ITemperaturÜberwacher gerät)
        {
            _geräte.Add(gerät);
        }
        public void Abmelden(ITemperaturÜberwacher gerät)
        {
            _geräte.Remove(gerät);
        }
    }
}
