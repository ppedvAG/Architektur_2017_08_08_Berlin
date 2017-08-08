namespace CompositeExample
{
    internal abstract class Aufgabe
    {
        public Aufgabe(string beschreibung)
        {
            Beschreibung = beschreibung;
        }

        public string Beschreibung { get; }

        public abstract void WirdErledigt();
        public abstract bool IstErledigt();
    }
}
