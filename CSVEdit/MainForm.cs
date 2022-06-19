using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSVEdit
{
    public partial class MainForm : Form
    {
        private string _fileName;
        private string FileName { 
            get { return _fileName; }
            set {
                _fileName = value;


                if (!string.IsNullOrWhiteSpace(_fileName))
                {
                    this.Text = "CSVEdit: " + _fileName;
                } else
                {
                    this.Text = "CSVEdit";
                }
            } 
        }

        private EncodingInfo _selectedReadEncoding;
        private EncodingInfo SelectedReadEncoding
        {
            get
            {
                return _selectedReadEncoding;
            }
            set
            {
                _selectedReadEncoding = value;

                if (_selectedReadEncoding == null)
                {
                    this.toolStripStatusReadEncoding.Text = string.Empty;
                }
                else
                {
                    this.toolStripStatusReadEncoding.Text = "<- " + _selectedReadEncoding.Name;
                }
            }
        }

        private EncodingInfo _selectedWriteEncoding;
        private EncodingInfo SelectedWriteEncoding
        {
            get
            {
                return _selectedWriteEncoding;
            }
            set
            {
                _selectedWriteEncoding = value;

                if (_selectedWriteEncoding == null)
                {
                    this.toolStripStatusWriteEncoding.Text = string.Empty;
                }
                else
                {
                    this.toolStripStatusWriteEncoding.Text = "-> " + _selectedWriteEncoding.Name;
                }
            }
        }

        private bool UnsavedChanges { get; set; }

        public MainForm()
        {
            InitializeComponent();

            this.FileName = null;
            this.SelectedReadEncoding = null;
            this.SelectedWriteEncoding = null;
            this.btnSave.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!this.AskUserToContinue()) return;

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "CSV-Dateien (*.csv)|";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        this.FileName = ofd.FileName;
                        
                        var settingsForm = new SettingsForm(this.FileName);
                        if (settingsForm.ShowDialog(this) != DialogResult.OK)
                        {
                            return;
                        }

                        SelectedReadEncoding = settingsForm.SelectedReadEncoding;
                        SelectedWriteEncoding = settingsForm.SelectedWriteEncoding;

                        var fileContent = FileIOHelper.ReadCSV(FileName, SelectedReadEncoding, false);

                        this.dataGrid.DataSource = DataGridHelper.CreateDataTable(fileContent);
                        this.dataGrid.AllowUserToAddRows = settingsForm.AllowAddRemoveRows;
                        this.dataGrid.AllowUserToDeleteRows = settingsForm.AllowAddRemoveRows;

                        this.ApplyGridSettings();
                        this.btnSave.Enabled = true;
                        this.UnsavedChanges = false;
                    }
                }
            } 
            catch (Exception ex) 
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Es ist ein Fehler beim Lesen der Datei aufgetreten!");
                sb.AppendLine("Bitte alle anderen Programme schließen, die diese Datei verwenden könnten (z.B. EXCEL)");
                sb.AppendLine("Detail:");
                sb.AppendLine(ex.Message);

                MessageBox.Show(sb.ToString() , "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyGridSettings()
        {
            foreach(DataGridViewColumn column in this.dataGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var headers = this.GetHeaders();
            var content = this.GetContent();

            var stringBuilder = new StringBuilder();

            try
            {
                var modifiedFile = FileIOHelper.WriteCSV(FileName, headers, content, SelectedWriteEncoding);

                stringBuilder.AppendLine("Datei gespeichert unter");
                stringBuilder.Append(modifiedFile.FullName);

                this.UnsavedChanges = false;
                MessageBox.Show(stringBuilder.ToString(), "Datei gespeichert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                stringBuilder.AppendLine("Es ist ein Fehler beim Schreiben der Datei aufgetreten!");
                stringBuilder.AppendLine("Bitte alle anderen Programme schließen, die diese Datei verwenden könnten (z.B. EXCEL)");
                stringBuilder.AppendLine("Detail:");
                stringBuilder.Append(ex.Message);

                MessageBox.Show(stringBuilder.ToString(), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> GetHeaders()
        {
            var headers = new List<string>();

            foreach (DataGridViewColumn column in this.dataGrid.Columns)
            {
                headers.Add(column.Name);
            }

            return headers;
        }

        private List<List<string>> GetContent()
        {
            var dataLines = new List<List<string>>();

            foreach(DataGridViewRow row in this.dataGrid.Rows)
            {
                var dataLine = new List<string>();
                var hasAnyValue = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    object value = cell.Value;
                    if(value == null)
                    {
                        dataLine.Add(string.Empty);
                    } 
                    else
                    {
                        var strValue = value.ToString();
                        dataLine.Add(strValue);

                        if (!string.IsNullOrWhiteSpace(strValue))
                        {
                            hasAnyValue = true;
                        }
                    }
                }

                if (hasAnyValue)
                {
                    dataLines.Add(dataLine);
                }
            }

            return dataLines;
        }

        private void dataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private bool AskUserToContinue()
        {
            if (!this.UnsavedChanges) return true;

            var result = MessageBox.Show("Wurden alle Änderungen gespeichert?", "Alles gespeichert?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return DialogResult.Yes == result;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.AskUserToContinue())
            {
                e.Cancel = true;
            }
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.UnsavedChanges = true;
        }
    }
}
