using System;
using System.Collections.Generic;

namespace TemplateMethodExample
{
    public abstract class UiElement
    {
        public List<UiElement> Children { get; } = new List<UiElement>();

        // Die Template Method (Schablonenmethode)
        public void Zeichnen()      // darf nicht virtual, oder abstract sein!
        {
            // Der Algorithmus:
            // 1. Rahmen zeichnen
            // 2. Inhalt zeichnen
            // 3. Unterelemente zeichnen

            ZeichneRahmen();
            ZeichneInhalt();
            ZeichneSchatten();
            ZeichneUnterelemente();
        }

        // 1. kann verändert werden
        protected virtual void ZeichneRahmen()
        {
            Console.WriteLine("Zeichne default Rahmen");
        }

        // 2. muss überschrieben werden
        protected abstract void ZeichneInhalt();

        // 3. kann nicht verändert werden
        private void ZeichneUnterelemente()
        {
            Children.ForEach(c => c.Zeichnen());
        }

        // 4. Hook - kann überschrieben werden -> absichtlich leer
        protected virtual void ZeichneSchatten() { }
    }
}
