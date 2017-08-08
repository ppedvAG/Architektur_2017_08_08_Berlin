using System;

namespace BuilderExample
{
    internal class Schrank
    {
        public const int MinTüren = 2;
        public const int MaxTüren = 7;
        public const int MinBöden = 0;
        public const int MaxBöden = 6;

        private Schrank(int anzahlTüren)
        {
            AnzahlTüren = anzahlTüren;
        }

        public int AnzahlTüren { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public Farbe Farbe { get; private set; }
        public int AnzahlBöden { get; private set; }
        public bool Metallschienen { get; private set; }
        public bool Kleiderstange { get; private set; }

        public override string ToString()
        {
            return $"Ein Schrank mit {AnzahlTüren} Türen, {(Oberfläche == Oberfläche.Lackiert ? $"{Oberfläche} in {Farbe}" : Oberfläche.ToString())}, mit {AnzahlBöden} Einlegeböden{(Metallschienen ? ", Metallschienen" : "")}{(Kleiderstange ? "und Kleiderstange" : "")}";
        }

        public class Builder
        {
            private Schrank _schrank;

            public Builder(int anzahlTüren)
            {
                if (anzahlTüren < MinTüren || anzahlTüren > MaxTüren)
                    throw new ArgumentException($"Die Anzahl der Türen muss zwischen {MinTüren} und {MaxTüren} liegen;");

                _schrank = new Schrank(anzahlTüren)
                {
                    Oberfläche = Oberfläche.Lackiert,
                    Farbe = Farbe.Weiß,
                    AnzahlBöden = 2,
                    Kleiderstange = false,
                    Metallschienen = false
                };
            }

            public Builder MitOberfläche(Oberfläche oberfläche)
            {
                if (oberfläche != Oberfläche.Lackiert && _schrank.Farbe != Farbe.KeineFarbe)
                    _schrank.Farbe = Farbe.KeineFarbe;

                _schrank.Oberfläche = oberfläche;

                return this;
            }

            public Builder MitFarbe(Farbe farbe)
            {
                if (farbe != Farbe.KeineFarbe && _schrank.Oberfläche != Oberfläche.Lackiert)
                    throw new ArgumentException("Eine Farbe kann nur bei Oberläche Lackiert gesetzt werden.");

                _schrank.Farbe = farbe;

                return this;
            }

            public Builder AnzahlBöden(int anzahlBöden)
            {
                if (anzahlBöden < MinBöden || anzahlBöden > MaxBöden)
                    throw new ArgumentException($"Die Anzahl der Einlegeböden muss zwischen {MinBöden} und {MaxBöden} liegen.");

                _schrank.AnzahlBöden = anzahlBöden;

                return this;
            }

            public Builder MitKleiderstange()
            {
                return MitKleiderstange(true);
            }
            private Builder MitKleiderstange(bool kleiderstange)
            {
                _schrank.Kleiderstange = kleiderstange;
                return this;
            }
            public Builder MitMetallschienen()
            {
                return MitMetallschienen(true);
            }
            public Builder MitMetallschienen(bool metallschienen)
            {
                _schrank.Metallschienen = metallschienen;
                return this;
            }

            public Schrank Konstruiere()
            {
                //return _schrank;
                return _schrank.MemberwiseClone() as Schrank;
            }
        }
    }
}
