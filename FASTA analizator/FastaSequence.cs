using System;
using System.Collections.Generic;

namespace FASTA_analizator
{
    public class FastaSequence
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Sekwencja { get; set; }
        public int Dlugosc => Sekwencja?.Length ?? 0;

        public FastaSequence(string nazwa, string opis, string sekwencja)
        {
            Nazwa = nazwa;
            Opis = opis;
            Sekwencja = sekwencja;
        }

        public double ObliczGC()
        {
            if (string.IsNullOrEmpty(Sekwencja)) return 0;
            int gc = 0;
            foreach (char c in Sekwencja)
            {
                if (c == 'G' || c == 'g' || c == 'C' || c == 'c')
                    gc++;
            }
            return (double)gc / Sekwencja.Length * 100;
        }

        public int LiczbaKodonow()
        {
            return Sekwencja?.Length / 3 ?? 0;
        }

        public Dictionary<char, int> LiczZasady()
        {
            var wynik = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };
            if (Sekwencja == null) return wynik;
            foreach (char c in Sekwencja.ToUpper())
            {
                if (wynik.ContainsKey(c))
                    wynik[c]++;
            }
            return wynik;
        }
    }
} 