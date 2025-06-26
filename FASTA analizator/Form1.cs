using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace FASTA_analizator
{
    public partial class Form1 : Form
    {
        private List<FastaSequence> sekwencje = new List<FastaSequence>();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonWczytajFasta_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Pliki FASTA|*.fasta;*.fa|Wszystkie pliki|*.*";
                openFileDialog.Title = "Wybierz plik FASTA";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        if (!FastaParser.Validate(fileName, out string error))
                        {
                            MessageBox.Show($"Błąd walidacji pliku {Path.GetFileName(fileName)}: {error}");
                            continue;
                        }
                        var nowe = FastaParser.Parse(fileName);
                        foreach (var seq in nowe)
                        {
                            // Nadpisuje sekwencje o tej samej nazwie
                            var idx = sekwencje.FindIndex(s => s.Nazwa == seq.Nazwa);
                            if (idx >= 0)
                                sekwencje[idx] = seq;
                            else
                                sekwencje.Add(seq);
                        }
                    }
                    AktualizujListe();
                    AktualizujWykres();
                }
            }
        }

        private void AktualizujListe()
        {
            listaSekwencji.Items.Clear();
            foreach (var seq in sekwencje)
            {
                var item = new ListViewItem(seq.Nazwa);
                item.SubItems.Add(seq.Dlugosc.ToString());
                listaSekwencji.Items.Add(item);
            }
        }

        private void listaSekwencji_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaSekwencji.SelectedItems.Count > 0)
            {
                var nazwa = listaSekwencji.SelectedItems[0].Text;
                var seq = sekwencje.FirstOrDefault(s => s.Nazwa == nazwa);
                if (seq != null)
                    PokazSzczegoly(seq);
            }
        }

        private void PokazSzczegoly(FastaSequence seq)
        {
            textBoxGC.Text = $"{seq.ObliczGC():F2}%";
            textBoxKodony.Text = seq.LiczbaKodonow().ToString();
            var zasady = seq.LiczZasady();
            textBoxZasady.Text = $"A: {zasady['A']}\r\nT: {zasady['T']}\r\nC: {zasady['C']}\r\nG: {zasady['G']}";
        }

        private void AktualizujWykres()
        {
            wykres.Series.Clear();
            wykres.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            var seria = new Series
            {
                Name = "Długość sekwencji",
                ChartType = SeriesChartType.Column
            };
            foreach (var seq in sekwencje)
            {
                seria.Points.AddXY(seq.Nazwa, seq.Dlugosc);
            }
            wykres.Series.Add(seria);
        }

        private void buttonEksportCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Pliki CSV|*.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Exporter.ExportToCSV(sekwencje, saveFileDialog.FileName);
                        MessageBox.Show("Plik został pomyślnie wyeksportowany!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Wystąpił błąd podczas eksportu: {ex.Message}");
                    }
                }
            }
        }

        private void buttonEksportJSON_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Pliki JSON|*.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Exporter.ExportToJSON(sekwencje, saveFileDialog.FileName);
                        MessageBox.Show("Dane zostały zapisane do pliku JSON");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Wystąpił błąd podczas eksportu do JSON: {ex.Message}");
                    }
                }
            }
        }
    }
}
