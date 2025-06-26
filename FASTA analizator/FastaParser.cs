using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FASTA_analizator
{
    public class FastaParser
    {
        public static List<FastaSequence> Parse(string path)
        {
            var wynik = new List<FastaSequence>();
            string naglowek = null;
            string opis = null;
            var sb = new StringBuilder();

            foreach (var linia in File.ReadLines(path))
            {
                if (string.IsNullOrWhiteSpace(linia)) continue;
                if (linia.StartsWith(">"))
                {
                    if (naglowek != null)
                    {
                        wynik.Add(new FastaSequence(naglowek, opis, sb.ToString()));
                    }
                    var header = linia.Substring(1).Trim();
                    var split = header.Split(new[] { ' ' }, 2);
                    naglowek = split[0];
                    opis = split.Length > 1 ? split[1] : string.Empty;
                    sb.Clear();
                }
                else
                {
                    sb.Append(linia.Trim());
                }
            }
            if (naglowek != null)
                wynik.Add(new FastaSequence(naglowek, opis, sb.ToString()));
            return wynik;
        }

        public static bool Validate(string path, out string error)
        {
            error = null;
            bool hasHeader = false;
            foreach (var linia in File.ReadLines(path))
            {
                if (linia.StartsWith(">"))
                {
                    hasHeader = true;
                }
            }
            if (!hasHeader)
            {
                error = "Brak nagłówka FASTA (linia zaczynająca się od >).";
                return false;
            }
            return true;
        }
    }
} 