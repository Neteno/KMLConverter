using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;

namespace KmlConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxBrackets.SelectedIndex = 0;
            comboBoxSeparator.Items.AddRange(new string[] { "Nowa linia", "Spacja", "," + " Nowa linia", ";", "|", "TAB" });
            comboBoxSeparator.SelectedIndex = 0; // Domy�lnie nowa linia
            comboBoxCoords.Items.AddRange(new string[] { "X", "Y", "Z", "X,Y", "X,Z", "Y,Z", "X,Y,Z" });
            comboBoxCoords.SelectedIndex = 3; // Domy�lnie "X,Y"
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
                lblStatus.Text = "B��d: Wybierz poprawny plik KML.";
                return;
            }

            string kmlPath = txtFilePath.Text;
            string csvPath = Path.ChangeExtension(kmlPath, ".csv");

            try
            {
                XNamespace ns = "http://www.opengis.net/kml/2.2";
                XDocument kml = XDocument.Load(kmlPath);

                string selectedBrackets = comboBoxBrackets.SelectedItem?.ToString() ?? "[]";
                string openBracket = selectedBrackets.Substring(0, 1);
                string closeBracket = selectedBrackets.Substring(1, 1);
                string selectedFormat = comboBoxCoords.SelectedItem.ToString();

                string separator;
                switch (comboBoxSeparator.SelectedItem.ToString())
                {
                    case "Nowa linia":
                        separator = Environment.NewLine;
                        break;
                    case "Spacja":
                        separator = " ";
                        break;
                    case "," + " Nowa linia":
                        separator = "," + Environment.NewLine;
                        break;
                    case ";":
                        separator = ";";
                        break;
                    case "|":
                        separator = "|";
                        break;
                    case "TAB":
                        separator = "\t";
                        break;
                    default:
                        separator = Environment.NewLine;
                        break;
                }

                var placemarks = kml.Descendants().Where(e => e.Name.LocalName == "Placemark")
                    .SelectMany(p => FormatCoordinates(
                        p.Descendants().FirstOrDefault(e => e.Name.LocalName == "coordinates")?.Value.Trim() ?? "",
                        selectedFormat, openBracket, closeBracket
                    )).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

                // Zapisujemy do pliku CSV
                using (var writer = new StreamWriter(csvPath))
                {
                    writer.Write(string.Join(separator, placemarks));
                }

                // Usuwamy puste nawiasy po zapisaniu pliku
                RemoveEmptyBrackets(csvPath, openBracket, closeBracket);

                lblStatus.Text = "Konwersja zako�czona! Plik zapisany jako: " + csvPath;
                MessageBox.Show("Konwersja zako�czona!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B��d: " + ex.Message, "B��d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCoords.SelectedIndex = 3; // Resetujemy do domy�lnego "X,Y"
            }
        }

        private IEnumerable<string> FormatCoordinates(string rawCoordinates, string selectedFormat, string openBracket, string closeBracket)
        {
            return rawCoordinates.Split(' ')
                .Select(coord =>
                {
                    var values = coord.Split(',');
                    int availableCoords = values.Length;

                    if (availableCoords == 0)
                        return null; // Ignoruj puste wiersze

                    List<string> selectedValues = new List<string>();

                    // Sprawdzamy, kt�re wsp�rz�dne nale�y doda� na podstawie wybranego formatu
                    if (selectedFormat.Contains("X") && availableCoords >= 1)
                        selectedValues.Add(values[0]);
                    if (selectedFormat.Contains("Y") && availableCoords >= 2)
                        selectedValues.Add(values[1]);
                    if (selectedFormat.Contains("Z") && availableCoords >= 3)
                        selectedValues.Add(values[2]);

                    // Je�li �adna warto�� nie zosta�a dodana, zwr�� null (czyli ignoruj ten punkt)
                    if (selectedValues.Count == 0)
                        return null;

                    // Zwracamy poprawnie sformatowane wsp�rz�dne w nawiasach
                    return openBracket + string.Join(",", selectedValues) + closeBracket;
                })
                .Where(coord => coord != null); // Ignorujemy null (czyli puste wsp�rz�dne)
        }

        private void RemoveEmptyBrackets(string filePath, string openBracket, string closeBracket)
        {
            // Wczytujemy plik CSV
            var lines = File.ReadAllLines(filePath).Where(line =>
            {
                // Sprawdzamy, czy linia nie zawiera pustych nawias�w
                return !line.Contains(openBracket + closeBracket); // Ignorujemy linie zawieraj�ce puste nawiasy
            }).ToList();

            // Zapisujemy z powrotem do pliku bez pustych nawias�w
            File.WriteAllLines(filePath, lines);
        }
    }
}
