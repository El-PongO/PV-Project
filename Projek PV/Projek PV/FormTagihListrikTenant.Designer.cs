namespace Projek_PV
{
    partial class FormTagihListrikTenant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTagihListrikTenant));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPilihTenant = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.roundedPanel1 = new RoundedPanel();
            this.labelTarif = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelkWh = new System.Windows.Forms.Label();
            this.labelEstimasi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxTenant = new System.Windows.Forms.TextBox();
            this.numKwh = new System.Windows.Forms.NumericUpDown();
            this.numTarif = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKwh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTarif)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 65);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(38, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tagihan Listrik Tenant";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "⚡";
            // 
            // labelPilihTenant
            // 
            this.labelPilihTenant.AutoSize = true;
            this.labelPilihTenant.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPilihTenant.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPilihTenant.Location = new System.Drawing.Point(16, 93);
            this.labelPilihTenant.Name = "labelPilihTenant";
            this.labelPilihTenant.Size = new System.Drawing.Size(98, 19);
            this.labelPilihTenant.TabIndex = 1;
            this.labelPilihTenant.Text = "Pilih Tenant";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(16, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jumlah Pemakaian (kWh)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(225, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tarif per kWh (Rp)";
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedPanel1.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.roundedPanel1.Controls.Add(this.labelTarif);
            this.roundedPanel1.Controls.Add(this.label8);
            this.roundedPanel1.Controls.Add(this.labelkWh);
            this.roundedPanel1.Controls.Add(this.labelEstimasi);
            this.roundedPanel1.Controls.Add(this.label5);
            this.roundedPanel1.Controls.Add(this.pictureBox1);
            this.roundedPanel1.FillColor = System.Drawing.Color.White;
            this.roundedPanel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.roundedPanel1.Location = new System.Drawing.Point(20, 230);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(397, 93);
            this.roundedPanel1.TabIndex = 7;
            // 
            // labelTarif
            // 
            this.labelTarif.AutoSize = true;
            this.labelTarif.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTarif.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelTarif.Location = new System.Drawing.Point(106, 55);
            this.labelTarif.Name = "labelTarif";
            this.labelTarif.Size = new System.Drawing.Size(53, 19);
            this.labelTarif.TabIndex = 8;
            this.labelTarif.Text = "1500";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(44, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "kWh x ";
            // 
            // labelkWh
            // 
            this.labelkWh.AutoSize = true;
            this.labelkWh.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelkWh.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelkWh.Location = new System.Drawing.Point(19, 55);
            this.labelkWh.Name = "labelkWh";
            this.labelkWh.Size = new System.Drawing.Size(26, 19);
            this.labelkWh.TabIndex = 6;
            this.labelkWh.Text = "0 ";
            // 
            // labelEstimasi
            // 
            this.labelEstimasi.AutoSize = true;
            this.labelEstimasi.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstimasi.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelEstimasi.Location = new System.Drawing.Point(267, 48);
            this.labelEstimasi.Name = "labelEstimasi";
            this.labelEstimasi.Size = new System.Drawing.Size(48, 26);
            this.labelEstimasi.TabIndex = 5;
            this.labelEstimasi.Text = "Rp ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Estimasi Tagihan";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(20, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(158)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(218, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 39);
            this.button2.TabIndex = 9;
            this.button2.Text = "Buat Tagihan";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBoxTenant
            // 
            this.textBoxTenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTenant.Location = new System.Drawing.Point(20, 116);
            this.textBoxTenant.Name = "textBoxTenant";
            this.textBoxTenant.ReadOnly = true;
            this.textBoxTenant.Size = new System.Drawing.Size(397, 24);
            this.textBoxTenant.TabIndex = 10;
            // 
            // numKwh
            // 
            this.numKwh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numKwh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numKwh.Location = new System.Drawing.Point(20, 183);
            this.numKwh.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numKwh.Name = "numKwh";
            this.numKwh.Size = new System.Drawing.Size(188, 20);
            this.numKwh.TabIndex = 11;
            // 
            // numTarif
            // 
            this.numTarif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numTarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTarif.Location = new System.Drawing.Point(229, 183);
            this.numTarif.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numTarif.Name = "numTarif";
            this.numTarif.Size = new System.Drawing.Size(188, 20);
            this.numTarif.TabIndex = 12;
            // 
            // FormTagihListrikTenant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.numTarif);
            this.Controls.Add(this.numKwh);
            this.Controls.Add(this.textBoxTenant);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelPilihTenant);
            this.Controls.Add(this.panel1);
            this.Name = "FormTagihListrikTenant";
            this.Text = "FormTagihListrikTenant";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKwh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTarif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPilihTenant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelkWh;
        private System.Windows.Forms.Label labelEstimasi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxTenant;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTarif;
        private System.Windows.Forms.NumericUpDown numKwh;
        private System.Windows.Forms.NumericUpDown numTarif;
    }
}