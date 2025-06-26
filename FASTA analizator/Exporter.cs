using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FASTA_analizator
{
    public static class Exporter
    {
        public static void ExportToCSV(List<FastaSequence> sekwencje, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Nazwa sekwencji;Opis;Długość;Zawartość GC (%);Liczba kodonów;A;T;C;G");
            foreach (var seq in sekwencje)
            {
                var zasady = seq.LiczZasady();
                sb.AppendLine(string.Join(";",
                    seq.Nazwa,
                    seq.Opis,
                    seq.Dlugosc,
                    seq.ObliczGC().ToString("F2"),
                    seq.LiczbaKodonow(),
                    zasady['A'],
                    zasady['T'],
                    zasady['C'],
                    zasady['G']
                ));
            }
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        public static void ExportToJSON(List<FastaSequence> sekwencje, string filePath)
        {
            var lista = new List<object>();
            foreach (var seq in sekwencje)
            {
                var zasady = seq.LiczZasady();
                lista.Add(new
                {
                    nazwa = seq.Nazwa,
                    opis = seq.Opis,
                    dlugosc = seq.Dlugosc,
                    gc = seq.ObliczGC(),
                    kodony = seq.LiczbaKodonow(),
                    A = zasady['A'],
                    T = zasady['T'],
                    C = zasady['C'],
                    G = zasady['G']
                });
            }
            var jsonString = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString, Encoding.UTF8);
        }
    }
} 