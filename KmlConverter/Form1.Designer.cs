namespace KmlConverter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox comboBoxBrackets;
        private System.Windows.Forms.ComboBox comboBoxSeparator;
        private System.Windows.Forms.ComboBox comboBoxCoords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.comboBoxBrackets = new System.Windows.Forms.ComboBox();
            this.comboBoxSeparator = new System.Windows.Forms.ComboBox();
            this.comboBoxCoords = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.txtFilePath.Location = new System.Drawing.Point(12, 12);
            this.txtFilePath.Size = new System.Drawing.Size(300, 20);
            this.txtFilePath.ReadOnly = true;

            this.btnSelectFile.Location = new System.Drawing.Point(320, 10);
            this.btnSelectFile.Size = new System.Drawing.Size(100, 23);
            this.btnSelectFile.Text = "Wybierz plik";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);

            this.btnConvert.Location = new System.Drawing.Point(320, 170);
            this.btnConvert.Size = new System.Drawing.Size(100, 30);
            this.btnConvert.Text = "Konwertuj";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);

            this.lblStatus.Location = new System.Drawing.Point(12, 210);
            this.lblStatus.Size = new System.Drawing.Size(400, 20);
            this.lblStatus.Text = "Status: Oczekiwanie na wybór pliku";

            this.comboBoxCoords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCoords.Location = new System.Drawing.Point(150, 50);
            this.comboBoxCoords.Items.AddRange(new object[] { "X", "Y", "Z", "X,Y", "X,Z", "Y,Z", "X,Y,Z" });

            this.comboBoxBrackets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrackets.Location = new System.Drawing.Point(150, 90);
            this.comboBoxBrackets.Items.AddRange(new object[] { "[]", "{}", "()" });

            this.comboBoxSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeparator.Location = new System.Drawing.Point(150, 130);
            this.comboBoxSeparator.Items.AddRange(new object[] { "Nowa linia", "Spacja", ", + Nowa linia"});

            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.Text = "Wybór współrzędnych:";

            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.Text = "Typ nawiasów:";

            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.Text = "Separator współrzędnych:";

            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.Text = "Przetwarzanie:";

            this.ClientSize = new System.Drawing.Size(440, 240);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.comboBoxCoords);
            this.Controls.Add(this.comboBoxBrackets);
            this.Controls.Add(this.comboBoxSeparator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Text = "KML to CSV Converter";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}