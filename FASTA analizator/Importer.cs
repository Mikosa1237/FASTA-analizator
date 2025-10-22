using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace FASTA_analizator
{
    public static class Importer
    {
        public static List<FastaSequence> ImportFromJSON(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath, Encoding.UTF8);
                var jsonData = JsonSerializer.Deserialize<List<JsonSequenceData>>(jsonContent);
                
                var sequences = new List<FastaSequence>();
                foreach (var data in jsonData)
                {
                    var sequence = new FastaSequence(data.nazwa, data.opis, data.sekwencja);
                    sequences.Add(sequence);
                }
                
                return sequences;
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas importu pliku JSON: {ex.Message}", ex);
            }
        }

        public static List<FastaSequence> ImportFromXML(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(XmlSequenceData));
                using (var reader = new FileStream(filePath, FileMode.Open))
                {
                    var xmlData = (XmlSequenceData)serializer.Deserialize(reader);
                    
                    var sequences = new List<FastaSequence>();
                    foreach (var seqData in xmlData.Sequences)
                    {
                        var sequence = new FastaSequence(seqData.Nazwa, seqData.Opis, seqData.Sekwencja);
                        sequences.Add(sequence);
                    }
                    
                    return sequences;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas importu pliku XML: {ex.Message}", ex);
            }
        }

        public static bool ValidateJSON(string filePath, out string error)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath, Encoding.UTF8);
                JsonSerializer.Deserialize<List<JsonSequenceData>>(jsonContent);
                error = null;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static bool ValidateXML(string filePath, out string error)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(XmlSequenceData));
                using (var reader = new FileStream(filePath, FileMode.Open))
                {
                    serializer.Deserialize(reader);
                }
                error = null;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }

    // Klasa pomocnicza dla deserializacji JSON
    public class JsonSequenceData
    {
        public string nazwa { get; set; }
        public string opis { get; set; }
        public string sekwencja { get; set; }
    }

    // Klasa pomocnicza dla deserializacji XML
    [XmlRoot("FastaData")]
    public class XmlSequenceData
    {
        [XmlArray("Sequences")]
        [XmlArrayItem("Sequence")]
        public List<XmlSequence> Sequences { get; set; } = new List<XmlSequence>();
    }

    public class XmlSequence
    {
        [XmlAttribute("nazwa")]
        public string Nazwa { get; set; }
        
        [XmlElement("Opis")]
        public string Opis { get; set; }
        
        [XmlElement("Sekwencja")]
        public string Sekwencja { get; set; }
    }
}
