using System;

namespace CompositeExample
{
    internal class Einzelaufgabe : Aufgabe
    {
        private bool _istErledigt;

        public Einzelaufgabe(string beschreibung) : base(beschreibung)
        { }

        public override bool IstErledigt()
        {
            return _istErledigt;
        }

        public override void WirdErledigt()
        {
            if (!_istErledigt)
            {
                Console.WriteLine($"\t{Beschreibung} wird erledigt.");
                _istErledigt = true;
            }
        }
    }
}
