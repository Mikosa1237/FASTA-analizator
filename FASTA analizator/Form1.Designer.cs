namespace FASTA_analizator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListView listaSekwencji;
        private System.Windows.Forms.TextBox textBoxGC;
        private System.Windows.Forms.TextBox textBoxKodony;
        private System.Windows.Forms.TextBox textBoxZasady;
        private System.Windows.Forms.Button buttonWczytajFasta;
        private System.Windows.Forms.Button buttonEksportCSV;
        private System.Windows.Forms.Button buttonEksportJSON;
        private System.Windows.Forms.Button buttonImportJSON;
        private System.Windows.Forms.Button buttonImportXML;
        private System.Windows.Forms.DataVisualization.Charting.Chart wykres;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listaSekwencji = new System.Windows.Forms.ListView();
            this.textBoxGC = new System.Windows.Forms.TextBox();
            this.textBoxKodony = new System.Windows.Forms.TextBox();
            this.textBoxZasady = new System.Windows.Forms.TextBox();
            this.buttonWczytajFasta = new System.Windows.Forms.Button();
            this.buttonEksportCSV = new System.Windows.Forms.Button();
            this.buttonEksportJSON = new System.Windows.Forms.Button();
            this.buttonImportJSON = new System.Windows.Forms.Button();
            this.buttonImportXML = new System.Windows.Forms.Button();
            this.wykres = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.wykres)).BeginInit();
            this.SuspendLayout();
            // 
            // listaSekwencji
            // 
            this.listaSekwencji.Location = new System.Drawing.Point(12, 12);
            this.listaSekwencji.Size = new System.Drawing.Size(300, 300);
            this.listaSekwencji.View = System.Windows.Forms.View.Details;
            this.listaSekwencji.FullRowSelect = true;
            this.listaSekwencji.Columns.Add("Nazwa", 180);
            this.listaSekwencji.Columns.Add("Długość", 80);
            this.listaSekwencji.MultiSelect = false;
            this.listaSekwencji.SelectedIndexChanged += new System.EventHandler(this.listaSekwencji_SelectedIndexChanged);
            // 
            // textBoxGC
            // 
            this.textBoxGC.Location = new System.Drawing.Point(330, 320);
            this.textBoxGC.Size = new System.Drawing.Size(120, 23);
            this.textBoxGC.ReadOnly = true;
            this.textBoxGC.PlaceholderText = "GC %";
            // 
            // textBoxKodony
            // 
            this.textBoxKodony.Location = new System.Drawing.Point(330, 350);
            this.textBoxKodony.Size = new System.Drawing.Size(120, 23);
            this.textBoxKodony.ReadOnly = true;
            this.textBoxKodony.PlaceholderText = "Kodony";
            // 
            // textBoxZasady
            // 
            this.textBoxZasady.Location = new System.Drawing.Point(330, 380);
            this.textBoxZasady.Size = new System.Drawing.Size(120, 120);
            this.textBoxZasady.ReadOnly = true;
            this.textBoxZasady.Multiline = true;
            this.textBoxZasady.PlaceholderText = "A/T/C/G";
            // 
            // buttonWczytajFasta
            // 
            this.buttonWczytajFasta.Location = new System.Drawing.Point(12, 390);
            this.buttonWczytajFasta.Size = new System.Drawing.Size(90, 30);
            this.buttonWczytajFasta.Text = "Wczytaj";
            this.buttonWczytajFasta.Click += new System.EventHandler(this.buttonWczytajFasta_Click);
            // 
            // buttonEksportCSV
            // 
            this.buttonEksportCSV.Location = new System.Drawing.Point(108, 390);
            this.buttonEksportCSV.Size = new System.Drawing.Size(90, 30);
            this.buttonEksportCSV.Text = "Eksport CSV";
            this.buttonEksportCSV.Click += new System.EventHandler(this.buttonEksportCSV_Click);
            // 
            // buttonEksportJSON
            // 
            this.buttonEksportJSON.Location = new System.Drawing.Point(204, 390);
            this.buttonEksportJSON.Size = new System.Drawing.Size(90, 30);
            this.buttonEksportJSON.Text = "Eksport JSON";
            this.buttonEksportJSON.Click += new System.EventHandler(this.buttonEksportJSON_Click);
            // 
            // buttonImportJSON
            // 
            this.buttonImportJSON.Location = new System.Drawing.Point(12, 430);
            this.buttonImportJSON.Size = new System.Drawing.Size(90, 30);
            this.buttonImportJSON.Text = "Import JSON";
            this.buttonImportJSON.Click += new System.EventHandler(this.buttonImportJSON_Click);
            // 
            // buttonImportXML
            // 
            this.buttonImportXML.Location = new System.Drawing.Point(108, 430);
            this.buttonImportXML.Size = new System.Drawing.Size(90, 30);
            this.buttonImportXML.Text = "Import XML";
            this.buttonImportXML.Click += new System.EventHandler(this.buttonImportXML_Click);
            // 
            // wykres
            // 
            this.wykres.Location = new System.Drawing.Point(330, 12);
            this.wykres.Size = new System.Drawing.Size(450, 300);
            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.wykres.ChartAreas.Add(chartArea);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.listaSekwencji);
            this.Controls.Add(this.textBoxGC);
            this.Controls.Add(this.textBoxKodony);
            this.Controls.Add(this.textBoxZasady);
            this.Controls.Add(this.buttonWczytajFasta);
            this.Controls.Add(this.buttonEksportCSV);
            this.Controls.Add(this.buttonEksportJSON);
            this.Controls.Add(this.buttonImportJSON);
            this.Controls.Add(this.buttonImportXML);
            this.Controls.Add(this.wykres);
            this.Text = "Analizator FASTA";
            ((System.ComponentModel.ISupportInitialize)(this.wykres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
