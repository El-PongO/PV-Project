namespace Projek_PV
{
    partial class formCreateKamar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCreateKamar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelPilihTenant = new System.Windows.Forms.Label();
            this.textBoxNomorKamar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownHarga = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonTerisi = new System.Windows.Forms.Button();
            this.buttonTersedia = new System.Windows.Forms.Button();
            this.buttonPerbaikan = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSimpanKamar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHarga)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 61);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(43, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tambah Kamar Baru";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labelPilihTenant
            // 
            this.labelPilihTenant.AutoSize = true;
            this.labelPilihTenant.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPilihTenant.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPilihTenant.Location = new System.Drawing.Point(23, 79);
            this.labelPilihTenant.Name = "labelPilihTenant";
            this.labelPilihTenant.Size = new System.Drawing.Size(131, 24);
            this.labelPilihTenant.TabIndex = 6;
            this.labelPilihTenant.Text = "Nomor Kamar";
            // 
            // textBoxNomorKamar
            // 
            this.textBoxNomorKamar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomorKamar.Location = new System.Drawing.Point(27, 109);
            this.textBoxNomorKamar.Name = "textBoxNomorKamar";
            this.textBoxNomorKamar.Size = new System.Drawing.Size(327, 24);
            this.textBoxNomorKamar.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(23, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tipe Kamar";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(27, 182);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(327, 26);
            this.comboBoxType.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(23, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Harga per Bulan (Rp)";
            // 
            // numericUpDownHarga
            // 
            this.numericUpDownHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownHarga.Increment = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDownHarga.Location = new System.Drawing.Point(27, 265);
            this.numericUpDownHarga.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownHarga.Name = "numericUpDownHarga";
            this.numericUpDownHarga.Size = new System.Drawing.Size(327, 24);
            this.numericUpDownHarga.TabIndex = 11;
            this.numericUpDownHarga.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(23, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Status Awal";
            // 
            // buttonTerisi
            // 
            this.buttonTerisi.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTerisi.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonTerisi.Location = new System.Drawing.Point(27, 343);
            this.buttonTerisi.Name = "buttonTerisi";
            this.buttonTerisi.Size = new System.Drawing.Size(106, 45);
            this.buttonTerisi.TabIndex = 13;
            this.buttonTerisi.Text = "Terisi";
            this.buttonTerisi.UseVisualStyleBackColor = true;
            this.buttonTerisi.Click += new System.EventHandler(this.buttonTerisi_Click);
            this.buttonTerisi.MouseLeave += new System.EventHandler(this.buttonStatus_MouseLeave);
            this.buttonTerisi.MouseHover += new System.EventHandler(this.buttonStatus_MouseHover);
            // 
            // buttonTersedia
            // 
            this.buttonTersedia.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTersedia.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonTersedia.Location = new System.Drawing.Point(137, 343);
            this.buttonTersedia.Name = "buttonTersedia";
            this.buttonTersedia.Size = new System.Drawing.Size(106, 45);
            this.buttonTersedia.TabIndex = 14;
            this.buttonTersedia.Text = "Tersedia";
            this.buttonTersedia.UseVisualStyleBackColor = true;
            this.buttonTersedia.Click += new System.EventHandler(this.buttonTersedia_Click);
            this.buttonTersedia.MouseLeave += new System.EventHandler(this.buttonStatus_MouseLeave);
            this.buttonTersedia.MouseHover += new System.EventHandler(this.buttonStatus_MouseHover);
            // 
            // buttonPerbaikan
            // 
            this.buttonPerbaikan.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPerbaikan.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonPerbaikan.Location = new System.Drawing.Point(248, 343);
            this.buttonPerbaikan.Name = "buttonPerbaikan";
            this.buttonPerbaikan.Size = new System.Drawing.Size(106, 45);
            this.buttonPerbaikan.TabIndex = 15;
            this.buttonPerbaikan.Text = "Perbaikan";
            this.buttonPerbaikan.UseVisualStyleBackColor = true;
            this.buttonPerbaikan.Click += new System.EventHandler(this.buttonPerbaikan_Click);
            this.buttonPerbaikan.MouseLeave += new System.EventHandler(this.buttonStatus_MouseLeave);
            this.buttonPerbaikan.MouseHover += new System.EventHandler(this.buttonStatus_MouseHover);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonCancel.Location = new System.Drawing.Point(27, 416);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(159, 47);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.MouseLeave += new System.EventHandler(this.buttonCancel_MouseLeave);
            this.buttonCancel.MouseHover += new System.EventHandler(this.buttonCancel_MouseHover);
            // 
            // buttonSimpanKamar
            // 
            this.buttonSimpanKamar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonSimpanKamar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpanKamar.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSimpanKamar.Location = new System.Drawing.Point(192, 416);
            this.buttonSimpanKamar.Name = "buttonSimpanKamar";
            this.buttonSimpanKamar.Size = new System.Drawing.Size(162, 47);
            this.buttonSimpanKamar.TabIndex = 17;
            this.buttonSimpanKamar.Text = "Simpan Kamar";
            this.buttonSimpanKamar.UseVisualStyleBackColor = false;
            this.buttonSimpanKamar.Click += new System.EventHandler(this.buttonSimpanKamar_Click);
            // 
            // formCreateKamar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 483);
            this.Controls.Add(this.buttonSimpanKamar);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPerbaikan);
            this.Controls.Add(this.buttonTersedia);
            this.Controls.Add(this.buttonTerisi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownHarga);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNomorKamar);
            this.Controls.Add(this.labelPilihTenant);
            this.Controls.Add(this.panel1);
            this.Name = "formCreateKamar";
            this.Text = "formCreateKamar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPilihTenant;
        private System.Windows.Forms.TextBox textBoxNomorKamar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownHarga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonTerisi;
        private System.Windows.Forms.Button buttonTersedia;
        private System.Windows.Forms.Button buttonPerbaikan;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSimpanKamar;
    }
}