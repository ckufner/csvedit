using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CSVEdit
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(string fileName)
        {
            InitializeComponent();

            this.fileName = fileName;

            this.txtDelimiter.MaxLength = 1;
            this.txtDelimiter.Text = ";";
        }

        private readonly string fileName;

        public EncodingInfo SelectedReadEncoding
        {
            get
            {
                var selectedIndex = this.cmbReadEncoding.SelectedIndex;
                if (selectedIndex == -1) return null;

                return this.cmbReadEncoding.Items[selectedIndex] as EncodingInfo;
            }
        }

        public String SelectedDelimiter
        {
            get
            {
                return this.txtDelimiter.Text;
            }
        }

        public EncodingInfo SelectedWriteEncoding
        {
            get
            {
                var selectedIndex = this.cmbWriteEncoding.SelectedIndex;
                if (selectedIndex == -1) return null;

                return this.cmbWriteEncoding.Items[selectedIndex] as EncodingInfo;
            }
        }

        public bool AllowAddRemoveRows
        {
            get
            {
                return this.cbAllowAddRemoveRows.Checked;
            }
        }

        private void EncodingForm_Load(object sender, EventArgs e)
        {
            var encodings = new List<EncodingInfo>();

            var defaultEncoding = Encoding.Default;
            EncodingInfo defaultEncodingInfo = null;

            foreach(var encodingInfo in Encoding.GetEncodings())
            {
                encodings.Add(encodingInfo);

                if (encodingInfo.CodePage.Equals(defaultEncoding.CodePage))
                {
                    defaultEncodingInfo = encodingInfo;
                }
            }

            this.cmbReadEncoding.DataSource = new List<EncodingInfo>(encodings);
            this.cmbReadEncoding.DisplayMember = "Name";

            this.cmbWriteEncoding.DataSource = new List<EncodingInfo>(encodings);
            this.cmbWriteEncoding.DisplayMember = "Name";

            if (defaultEncodingInfo != null)
            {
                this.cmbReadEncoding.SelectedIndex = this.cmbReadEncoding.Items.IndexOf(defaultEncodingInfo);
                this.cmbWriteEncoding.SelectedIndex = this.cmbWriteEncoding.Items.IndexOf(defaultEncodingInfo);
            }
        }

        private void LoadPreview()
        {
            if (this.SelectedReadEncoding == null) return;
            if (!this.IsDelimiterValid()) return;
            


            try
            {
                var fileContent = FileIOHelper.ReadCSV(this.fileName, SelectedReadEncoding, this.SelectedDelimiter, true);

                this.dataGridPreview.DataSource = DataGridHelper.CreateDataTable(fileContent);
                foreach (DataGridViewColumn column in this.dataGridPreview.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Es ist ein Fehler beim Lesen der Datei aufgetreten!");
                sb.AppendLine("Bitte alle anderen Programme schließen, die diese Datei verwenden könnten (z.B. EXCEL)");
                sb.AppendLine("Detail:");
                sb.AppendLine(ex.Message);

                MessageBox.Show(sb.ToString(), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsDelimiterValid()
        {
            if (this.txtDelimiter.Text.Length != 1)
            {
                MessageBox.Show("Es muss ein Trennzeichen eingegeben werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDelimiter.Focus();

                return false;
            }

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!this.IsDelimiterValid()) return;

            this.DialogResult = DialogResult.OK;
        }

        private void cmbReadEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadPreview();
        }

        private void txtDelimiter_TextChanged(object sender, EventArgs e)
        {
            this.LoadPreview();
        }
    }
}
