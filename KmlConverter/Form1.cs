using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace KmlConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxBrackets.SelectedIndex = 0;
            comboBoxSeparator.SelectedIndex = 0; // Domyœlnie nowa linia
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Pliki KML (*.kml)|*.kml",
                Title = "Wybierz plik KML"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
            {
                lblStatus.Text = "B³¹d: Wybierz poprawny plik KML.";
                return;
            }

            string kmlPath = txtFilePath.Text;
            string csvPath = Path.ChangeExtension(kmlPath, ".csv");

            try
            {
                XNamespace ns = "http://www.opengis.net/kml/2.2";
                XDocument kml = XDocument.Load(kmlPath);

                int coordinateCount = (int)numericUpDownCoords.Value;
                string selectedBrackets = comboBoxBrackets.SelectedItem?.ToString() ?? "[]";
                string openBracket = selectedBrackets.Substring(0, 1);
                string closeBracket = selectedBrackets.Substring(1, 1);
                string separator = comboBoxSeparator.SelectedItem.ToString() == "Nowa linia" ? Environment.NewLine : " ";

                var placemarks = kml.Descendants().Where(e => e.Name.LocalName == "Placemark")
                    .SelectMany(p => FormatCoordinates(
                        p.Descendants().FirstOrDefault(e => e.Name.LocalName == "coordinates")?.Value.Trim() ?? "",
                        coordinateCount, openBracket, closeBracket
                    )).ToList();

                using (var writer = new StreamWriter(csvPath))
                {
                    writer.Write(string.Join(separator, placemarks));
                }

                lblStatus.Text = "Konwersja zakoñczona! Plik zapisany jako: " + csvPath;
                MessageBox.Show("Konwersja zakoñczona!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "B³¹d: " + ex.Message;
            }
        }

        private IEnumerable<string> FormatCoordinates(string rawCoordinates, int count, string openBracket, string closeBracket)
        {
            return rawCoordinates.Split(' ')
                .Select(coord =>
                {
                    var values = coord.Split(',');
                    if (values.Length < count) return null;
                    return openBracket + string.Join(",", values.Take(count)) + closeBracket;
                })
                .Where(coord => coord != null);
        }
    }

}
