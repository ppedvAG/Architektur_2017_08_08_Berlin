using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeExample
{
    internal class AufgabenListe : Aufgabe
    {
        private List<Aufgabe> _aufgaben = new List<Aufgabe>();

        public AufgabenListe(string beschreibung) : base(beschreibung)
        { }

        public override bool IstErledigt()
        {
            //foreach (var a in _aufgaben)
            //    if (!a.IstErledigt())
            //        return false;

            //return true;

            return _aufgaben.All(a => a.IstErledigt());
        }

        public override void WirdErledigt()
        {
            if(!IstErledigt())
            {
                Console.WriteLine($"{Beschreibung} wird erledigt.");
                _aufgaben.ForEach(a => a.WirdErledigt());
            }
        }

        public void Hinzufügen(Aufgabe aufgabe)
        {
            _aufgaben.Add(aufgabe);
        }
    }
}
