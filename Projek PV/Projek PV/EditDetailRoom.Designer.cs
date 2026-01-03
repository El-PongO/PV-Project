namespace Projek_PV
{
    partial class EditDetailRoom
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDetailKamar = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPerbaikan = new System.Windows.Forms.Button();
            this.btnTersedia = new System.Windows.Forms.Button();
            this.btnTerisi = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelHarga = new System.Windows.Forms.Label();
            this.labelTipeKamar = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.labelNomorKamar = new System.Windows.Forms.Label();
            this.comboBoxTipeKamar = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.labelDetailKamar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 59);
            this.panel1.TabIndex = 0;
            // 
            // labelDetailKamar
            // 
            this.labelDetailKamar.AutoSize = true;
            this.labelDetailKamar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetailKamar.ForeColor = System.Drawing.SystemColors.Control;
            this.labelDetailKamar.Location = new System.Drawing.Point(22, 17);
            this.labelDetailKamar.Name = "labelDetailKamar";
            this.labelDetailKamar.Size = new System.Drawing.Size(215, 26);
            this.labelDetailKamar.TabIndex = 0;
            this.labelDetailKamar.Text = "Edit Detail Kamar ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxTipeKamar);
            this.panel2.Controls.Add(this.numPrice);
            this.panel2.Controls.Add(this.btnSaveChanges);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnPerbaikan);
            this.panel2.Controls.Add(this.btnTersedia);
            this.panel2.Controls.Add(this.btnTerisi);
            this.panel2.Controls.Add(this.labelStatus);
            this.panel2.Controls.Add(this.labelHarga);
            this.panel2.Controls.Add(this.labelTipeKamar);
            this.panel2.Controls.Add(this.txtRoomNumber);
            this.panel2.Controls.Add(this.labelNomorKamar);
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 456);
            this.panel2.TabIndex = 1;
            // 
            // numPrice
            // 
            this.numPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrice.Increment = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numPrice.Location = new System.Drawing.Point(27, 217);
            this.numPrice.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(449, 24);
            this.numPrice.TabIndex = 13;
            this.numPrice.ThousandsSeparator = true;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSaveChanges.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSaveChanges.Location = new System.Drawing.Point(251, 360);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(225, 44);
            this.btnSaveChanges.TabIndex = 12;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Location = new System.Drawing.Point(27, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(218, 44);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPerbaikan
            // 
            this.btnPerbaikan.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerbaikan.Location = new System.Drawing.Point(330, 290);
            this.btnPerbaikan.Name = "btnPerbaikan";
            this.btnPerbaikan.Size = new System.Drawing.Size(146, 44);
            this.btnPerbaikan.TabIndex = 10;
            this.btnPerbaikan.Text = "Perbaikan";
            this.btnPerbaikan.UseVisualStyleBackColor = true;
            this.btnPerbaikan.Click += new System.EventHandler(this.btnPerbaikan_Click);
            // 
            // btnTersedia
            // 
            this.btnTersedia.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTersedia.Location = new System.Drawing.Point(178, 290);
            this.btnTersedia.Name = "btnTersedia";
            this.btnTersedia.Size = new System.Drawing.Size(146, 44);
            this.btnTersedia.TabIndex = 9;
            this.btnTersedia.Text = "Tersedia";
            this.btnTersedia.UseVisualStyleBackColor = true;
            this.btnTersedia.Click += new System.EventHandler(this.btnTersedia_Click);
            // 
            // btnTerisi
            // 
            this.btnTerisi.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerisi.Location = new System.Drawing.Point(26, 290);
            this.btnTerisi.Name = "btnTerisi";
            this.btnTerisi.Size = new System.Drawing.Size(146, 44);
            this.btnTerisi.TabIndex = 8;
            this.btnTerisi.Text = "Terisi";
            this.btnTerisi.UseVisualStyleBackColor = true;
            this.btnTerisi.Click += new System.EventHandler(this.btnTerisi_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelStatus.Location = new System.Drawing.Point(23, 255);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(72, 22);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Status";
            // 
            // labelHarga
            // 
            this.labelHarga.AutoSize = true;
            this.labelHarga.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHarga.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelHarga.Location = new System.Drawing.Point(22, 177);
            this.labelHarga.Name = "labelHarga";
            this.labelHarga.Size = new System.Drawing.Size(215, 22);
            this.labelHarga.TabIndex = 5;
            this.labelHarga.Text = "Harga per Bulan (Rp)";
            // 
            // labelTipeKamar
            // 
            this.labelTipeKamar.AutoSize = true;
            this.labelTipeKamar.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipeKamar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelTipeKamar.Location = new System.Drawing.Point(22, 101);
            this.labelTipeKamar.Name = "labelTipeKamar";
            this.labelTipeKamar.Size = new System.Drawing.Size(118, 22);
            this.labelTipeKamar.TabIndex = 3;
            this.labelTipeKamar.Text = "Tipe Kamar";
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNumber.Location = new System.Drawing.Point(26, 59);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.ReadOnly = true;
            this.txtRoomNumber.Size = new System.Drawing.Size(450, 24);
            this.txtRoomNumber.TabIndex = 2;
            // 
            // labelNomorKamar
            // 
            this.labelNomorKamar.AutoSize = true;
            this.labelNomorKamar.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomorKamar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelNomorKamar.Location = new System.Drawing.Point(22, 32);
            this.labelNomorKamar.Name = "labelNomorKamar";
            this.labelNomorKamar.Size = new System.Drawing.Size(140, 22);
            this.labelNomorKamar.TabIndex = 1;
            this.labelNomorKamar.Text = "Nomor Kamar";
            // 
            // comboBoxTipeKamar
            // 
            this.comboBoxTipeKamar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipeKamar.Location = new System.Drawing.Point(27, 137);
            this.comboBoxTipeKamar.Name = "comboBoxTipeKamar";
            this.comboBoxTipeKamar.Size = new System.Drawing.Size(449, 26);
            this.comboBoxTipeKamar.TabIndex = 0;
            // 
            // EditDetailRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 522);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EditDetailRoom";
            this.Text = "EditDetailRoom";
            this.Load += new System.EventHandler(this.EditDetailRoom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDetailKamar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPerbaikan;
        private System.Windows.Forms.Button btnTersedia;
        private System.Windows.Forms.Button btnTerisi;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelHarga;
        private System.Windows.Forms.Label labelTipeKamar;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label labelNomorKamar;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.ComboBox comboBoxTipeKamar;
    }
}