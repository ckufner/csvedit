namespace CSVEdit
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.lblReadEncoding = new System.Windows.Forms.Label();
            this.cmbReadEncoding = new System.Windows.Forms.ComboBox();
            this.lblWriteEncoding = new System.Windows.Forms.Label();
            this.cmbWriteEncoding = new System.Windows.Forms.ComboBox();
            this.cbAllowAddRemoveRows = new System.Windows.Forms.CheckBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.dataGridPreview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(593, 303);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 19);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblReadEncoding
            // 
            this.lblReadEncoding.AutoSize = true;
            this.lblReadEncoding.Location = new System.Drawing.Point(27, 7);
            this.lblReadEncoding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReadEncoding.Name = "lblReadEncoding";
            this.lblReadEncoding.Size = new System.Drawing.Size(78, 13);
            this.lblReadEncoding.TabIndex = 1;
            this.lblReadEncoding.Text = "Lese-Encoding";
            // 
            // cmbReadEncoding
            // 
            this.cmbReadEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReadEncoding.FormattingEnabled = true;
            this.cmbReadEncoding.Location = new System.Drawing.Point(105, 5);
            this.cmbReadEncoding.Margin = new System.Windows.Forms.Padding(2);
            this.cmbReadEncoding.Name = "cmbReadEncoding";
            this.cmbReadEncoding.Size = new System.Drawing.Size(545, 21);
            this.cmbReadEncoding.Sorted = true;
            this.cmbReadEncoding.TabIndex = 2;
            this.cmbReadEncoding.SelectedIndexChanged += new System.EventHandler(this.cmbReadEncoding_SelectedIndexChanged);
            // 
            // lblWriteEncoding
            // 
            this.lblWriteEncoding.AutoSize = true;
            this.lblWriteEncoding.Location = new System.Drawing.Point(9, 37);
            this.lblWriteEncoding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWriteEncoding.Name = "lblWriteEncoding";
            this.lblWriteEncoding.Size = new System.Drawing.Size(97, 13);
            this.lblWriteEncoding.TabIndex = 3;
            this.lblWriteEncoding.Text = "Schreibe-Encoding";
            // 
            // cmbWriteEncoding
            // 
            this.cmbWriteEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWriteEncoding.FormattingEnabled = true;
            this.cmbWriteEncoding.Location = new System.Drawing.Point(105, 34);
            this.cmbWriteEncoding.Margin = new System.Windows.Forms.Padding(2);
            this.cmbWriteEncoding.Name = "cmbWriteEncoding";
            this.cmbWriteEncoding.Size = new System.Drawing.Size(545, 21);
            this.cmbWriteEncoding.Sorted = true;
            this.cmbWriteEncoding.TabIndex = 4;
            // 
            // cbAllowAddRemoveRows
            // 
            this.cbAllowAddRemoveRows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllowAddRemoveRows.AutoSize = true;
            this.cbAllowAddRemoveRows.Location = new System.Drawing.Point(12, 305);
            this.cbAllowAddRemoveRows.Margin = new System.Windows.Forms.Padding(2);
            this.cbAllowAddRemoveRows.Name = "cbAllowAddRemoveRows";
            this.cbAllowAddRemoveRows.Size = new System.Drawing.Size(254, 17);
            this.cbAllowAddRemoveRows.TabIndex = 6;
            this.cbAllowAddRemoveRows.Text = "Zeilen können hinzugefügt und gelöscht werden";
            this.cbAllowAddRemoveRows.UseVisualStyleBackColor = true;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(9, 63);
            this.lblPreview.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(52, 13);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "Vorschau";
            // 
            // dataGridPreview
            // 
            this.dataGridPreview.AllowUserToAddRows = false;
            this.dataGridPreview.AllowUserToDeleteRows = false;
            this.dataGridPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPreview.Enabled = false;
            this.dataGridPreview.Location = new System.Drawing.Point(11, 78);
            this.dataGridPreview.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridPreview.Name = "dataGridPreview";
            this.dataGridPreview.RowHeadersWidth = 51;
            this.dataGridPreview.RowTemplate.Height = 24;
            this.dataGridPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPreview.Size = new System.Drawing.Size(637, 220);
            this.dataGridPreview.TabIndex = 7;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 332);
            this.Controls.Add(this.dataGridPreview);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.cbAllowAddRemoveRows);
            this.Controls.Add(this.cmbWriteEncoding);
            this.Controls.Add(this.lblWriteEncoding);
            this.Controls.Add(this.cmbReadEncoding);
            this.Controls.Add(this.lblReadEncoding);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EncodingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblReadEncoding;
        private System.Windows.Forms.ComboBox cmbReadEncoding;
        private System.Windows.Forms.Label lblWriteEncoding;
        private System.Windows.Forms.ComboBox cmbWriteEncoding;
        private System.Windows.Forms.CheckBox cbAllowAddRemoveRows;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.DataGridView dataGridPreview;
    }
}