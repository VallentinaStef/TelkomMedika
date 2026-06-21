namespace TelkomMedikaForm
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelCard;
        private Label lblTitle;
        private Label lblOperational;
        private Label lblPoli;
        private ComboBox cmbPoli;
        private Label lblDokter;
        private ComboBox cmbDokter;
        private Label lblTanggal;
        private DateTimePicker dtpTanggal;
        private Label lblJadwal;
        private ComboBox cmbJadwal;
        private Label lblKeluhan;
        private TextBox txtKeluhan;
        private Button btnKembali;
        private Button btnSubmit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelCard = new Panel();
            lblTitle = new Label();
            lblOperational = new Label();
            lblPoli = new Label();
            cmbPoli = new ComboBox();
            lblDokter = new Label();
            cmbDokter = new ComboBox();
            lblTanggal = new Label();
            dtpTanggal = new DateTimePicker();
            lblJadwal = new Label();
            cmbJadwal = new ComboBox();
            lblKeluhan = new Label();
            txtKeluhan = new TextBox();
            btnKembali = new Button();
            btnSubmit = new Button();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(lblTitle);
            panelCard.Controls.Add(lblOperational);
            panelCard.Controls.Add(lblPoli);
            panelCard.Controls.Add(cmbPoli);
            panelCard.Controls.Add(lblDokter);
            panelCard.Controls.Add(cmbDokter);
            panelCard.Controls.Add(lblTanggal);
            panelCard.Controls.Add(dtpTanggal);
            panelCard.Controls.Add(lblJadwal);
            panelCard.Controls.Add(cmbJadwal);
            panelCard.Controls.Add(lblKeluhan);
            panelCard.Controls.Add(txtKeluhan);
            panelCard.Controls.Add(btnKembali);
            panelCard.Controls.Add(btnSubmit);
            panelCard.Location = new Point(24, 24);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(20);
            panelCard.Size = new Size(616, 604);
            panelCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(14, 6, 14, 6);
            lblTitle.Size = new Size(113, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "reservasi";
            // 
            // lblOperational
            // 
            lblOperational.BackColor = Color.FromArgb(255, 245, 245);
            lblOperational.BorderStyle = BorderStyle.FixedSingle;
            lblOperational.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOperational.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            lblOperational.Location = new Point(35, 78);
            lblOperational.Name = "lblOperational";
            lblOperational.Padding = new Padding(10, 0, 0, 0);
            lblOperational.Size = new Size(536, 40);
            lblOperational.TabIndex = 1;
            lblOperational.Text = "Operasional Telkomedika: Senin - Minggu, 24 Jam";
            lblOperational.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPoli
            // 
            lblPoli.AutoSize = true;
            lblPoli.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPoli.Location = new Point(35, 140);
            lblPoli.Name = "lblPoli";
            lblPoli.Size = new Size(84, 23);
            lblPoli.TabIndex = 2;
            lblPoli.Text = "pilih poli";
            // 
            // cmbPoli
            // 
            cmbPoli.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPoli.Font = new Font("Segoe UI", 11F);
            cmbPoli.FormattingEnabled = true;
            cmbPoli.Items.AddRange(new object[] { "gigi", "umum" });
            cmbPoli.Location = new Point(35, 167);
            cmbPoli.Name = "cmbPoli";
            cmbPoli.Size = new Size(536, 33);
            cmbPoli.TabIndex = 3;
            cmbPoli.SelectedIndexChanged += cmbPoli_SelectedIndexChanged;
            // 
            // lblDokter
            // 
            lblDokter.AutoSize = true;
            lblDokter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDokter.Location = new Point(35, 222);
            lblDokter.Name = "lblDokter";
            lblDokter.Size = new Size(94, 23);
            lblDokter.TabIndex = 4;
            lblDokter.Text = "pilih dokter";
            // 
            // cmbDokter
            // 
            cmbDokter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDokter.Font = new Font("Segoe UI", 11F);
            cmbDokter.FormattingEnabled = true;
            cmbDokter.Location = new Point(35, 249);
            cmbDokter.Name = "cmbDokter";
            cmbDokter.Size = new Size(536, 33);
            cmbDokter.TabIndex = 5;
            cmbDokter.SelectedIndexChanged += cmbDokter_SelectedIndexChanged;
            // 
            // lblTanggal
            // 
            lblTanggal.AutoSize = true;
            lblTanggal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTanggal.Location = new Point(35, 304);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(105, 23);
            lblTanggal.TabIndex = 6;
            lblTanggal.Text = "pilih tanggal";
            // 
            // dtpTanggal
            // 
            dtpTanggal.Font = new Font("Segoe UI", 11F);
            dtpTanggal.Format = DateTimePickerFormat.Long;
            dtpTanggal.Location = new Point(35, 331);
            dtpTanggal.Name = "dtpTanggal";
            dtpTanggal.Size = new Size(536, 32);
            dtpTanggal.TabIndex = 7;
            dtpTanggal.ValueChanged += dtpTanggal_ValueChanged;
            // 
            // lblJadwal
            // 
            lblJadwal.AutoSize = true;
            lblJadwal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblJadwal.Location = new Point(35, 386);
            lblJadwal.Name = "lblJadwal";
            lblJadwal.Size = new Size(101, 23);
            lblJadwal.TabIndex = 8;
            lblJadwal.Text = "pilih jadwal";
            // 
            // cmbJadwal
            // 
            cmbJadwal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJadwal.Font = new Font("Segoe UI", 11F);
            cmbJadwal.FormattingEnabled = true;
            cmbJadwal.Location = new Point(35, 413);
            cmbJadwal.Name = "cmbJadwal";
            cmbJadwal.Size = new Size(536, 33);
            cmbJadwal.TabIndex = 9;
            // 
            // lblKeluhan
            // 
            lblKeluhan.AutoSize = true;
            lblKeluhan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKeluhan.Location = new Point(35, 469);
            lblKeluhan.Name = "lblKeluhan";
            lblKeluhan.Size = new Size(72, 23);
            lblKeluhan.TabIndex = 10;
            lblKeluhan.Text = "keluhan";
            // 
            // txtKeluhan
            // 
            txtKeluhan.Font = new Font("Segoe UI", 11F);
            txtKeluhan.Location = new Point(35, 496);
            txtKeluhan.Multiline = true;
            txtKeluhan.Name = "txtKeluhan";
            txtKeluhan.ScrollBars = ScrollBars.Vertical;
            txtKeluhan.Size = new Size(536, 55);
            txtKeluhan.TabIndex = 11;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.White;
            btnKembali.FlatStyle = FlatStyle.Flat;
            btnKembali.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKembali.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnKembali.Location = new Point(355, 563);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(100, 36);
            btnKembali.TabIndex = 12;
            btnKembali.Text = "kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(471, 563);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(100, 36);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(664, 652);
            Controls.Add(panelCard);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReservationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reservasi";
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }
    }
}
