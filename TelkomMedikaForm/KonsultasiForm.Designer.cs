namespace TelkomMedikaForm
{
    partial class KonsultasiForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblJudul;
        private Panel pnlInfo;
        private Label lblInfo;
        private GroupBox gbBuatKonsultasi;
        private Label lblDokter;
        private ComboBox cmbDokter;
        private Label lblKeluhan;
        private TextBox txtKeluhan;
        private Label lblWaktuKonsultasi;
        private DateTimePicker dtpWaktuKonsultasi;
        private Button btnBuatKonsultasi;
        private DataGridView dgvKonsultasi;
        private Button btnRefreshKonsultasi;
        private Button btnMulaiKonsultasi;
        private Button btnSelesaikanKonsultasi;
        private Button btnBatalkanKonsultasi;
        private Button btnKembali;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblJudul = new Label();
            pnlInfo = new Panel();
            lblInfo = new Label();
            gbBuatKonsultasi = new GroupBox();
            lblDokter = new Label();
            cmbDokter = new ComboBox();
            lblKeluhan = new Label();
            txtKeluhan = new TextBox();
            lblWaktuKonsultasi = new Label();
            dtpWaktuKonsultasi = new DateTimePicker();
            btnBuatKonsultasi = new Button();
            dgvKonsultasi = new DataGridView();
            btnRefreshKonsultasi = new Button();
            btnMulaiKonsultasi = new Button();
            btnSelesaikanKonsultasi = new Button();
            btnBatalkanKonsultasi = new Button();
            btnKembali = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvKonsultasi).BeginInit();
            pnlHeader.SuspendLayout();
            pnlInfo.SuspendLayout();
            gbBuatKonsultasi.SuspendLayout();
            SuspendLayout();

            
            pnlHeader.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Size = new Size(764, 60);
            pnlHeader.Controls.Add(lblJudul);

            lblJudul.Text = "Konsultasi";
            lblJudul.ForeColor = Color.White;
            lblJudul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblJudul.Location = new Point(20, 12);
            lblJudul.Size = new Size(400, 36);
            lblJudul.BackColor = Color.Transparent;

           
            pnlInfo.BackColor = Color.FromArgb(0xFC, 0xEB, 0xEB);
            pnlInfo.Location = new Point(12, 72);
            pnlInfo.Size = new Size(740, 36);
            pnlInfo.Controls.Add(lblInfo);

            lblInfo.Text = "Konsultasi online tersedia sesuai jadwal dan ketersediaan dokter.";
            lblInfo.ForeColor = Color.FromArgb(0x79, 0x1F, 0x1F);
            lblInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblInfo.Location = new Point(10, 9);
            lblInfo.Size = new Size(720, 20);
            lblInfo.BackColor = Color.Transparent;

            
            gbBuatKonsultasi.Text = "Buat Konsultasi Baru";
            gbBuatKonsultasi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbBuatKonsultasi.Location = new Point(12, 120);
            gbBuatKonsultasi.Size = new Size(740, 150);
            gbBuatKonsultasi.Controls.Add(lblDokter);
            gbBuatKonsultasi.Controls.Add(cmbDokter);
            gbBuatKonsultasi.Controls.Add(lblKeluhan);
            gbBuatKonsultasi.Controls.Add(txtKeluhan);
            gbBuatKonsultasi.Controls.Add(lblWaktuKonsultasi);
            gbBuatKonsultasi.Controls.Add(dtpWaktuKonsultasi);
            gbBuatKonsultasi.Controls.Add(btnBuatKonsultasi);

            lblDokter.Text = "Nama Dokter";
            lblDokter.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblDokter.Location = new Point(15, 30);
            lblDokter.Size = new Size(90, 23);

            cmbDokter.Location = new Point(110, 27);
            cmbDokter.Size = new Size(300, 23);
            cmbDokter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDokter.Items.AddRange(new object[]
            {
                "dr. Adiah Desti",
                "dr. Rizky Regia",
                "dr. Achmad N",
                "dr. Faizah",
                "dr. Nandila Larasati",
                "drg. Siti Aulia",
                "drg. Budi Santoso",
                "drg. Citra Maharani",
                "drg. Dimas Pratama",
                "drg. Eka Putri"
            });

            lblKeluhan.Text = "Keluhan";
            lblKeluhan.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblKeluhan.Location = new Point(15, 65);
            lblKeluhan.Size = new Size(90, 23);

            txtKeluhan.Location = new Point(110, 62);
            txtKeluhan.Size = new Size(300, 23);

            lblWaktuKonsultasi.Text = "Waktu";
            lblWaktuKonsultasi.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblWaktuKonsultasi.Location = new Point(15, 100);
            lblWaktuKonsultasi.Size = new Size(90, 23);

            dtpWaktuKonsultasi.Location = new Point(110, 97);
            dtpWaktuKonsultasi.Size = new Size(200, 23);
            dtpWaktuKonsultasi.Format = DateTimePickerFormat.Custom;
            dtpWaktuKonsultasi.CustomFormat = "dd/MM/yyyy HH:mm";

            btnBuatKonsultasi.Text = "Buat";
            btnBuatKonsultasi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuatKonsultasi.Location = new Point(420, 95);
            btnBuatKonsultasi.Size = new Size(100, 30);
            btnBuatKonsultasi.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnBuatKonsultasi.ForeColor = Color.White;
            btnBuatKonsultasi.FlatStyle = FlatStyle.Flat;
            btnBuatKonsultasi.FlatAppearance.BorderSize = 0;
            btnBuatKonsultasi.Click += btnBuatKonsultasi_Click;

            
            dgvKonsultasi.Location = new Point(12, 280);
            dgvKonsultasi.Size = new Size(740, 230);
            dgvKonsultasi.ReadOnly = true;
            dgvKonsultasi.AllowUserToAddRows = false;
            dgvKonsultasi.AllowUserToDeleteRows = false;
            dgvKonsultasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKonsultasi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKonsultasi.BackgroundColor = Color.White;
            dgvKonsultasi.BorderStyle = BorderStyle.FixedSingle;
            dgvKonsultasi.GridColor = Color.FromArgb(0xE0, 0xE0, 0xE0);
            dgvKonsultasi.RowHeadersVisible = false;
            dgvKonsultasi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvKonsultasi.ColumnHeadersHeight = 36;
            dgvKonsultasi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            dgvKonsultasi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKonsultasi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvKonsultasi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvKonsultasi.EnableHeadersVisualStyles = false;
            dgvKonsultasi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            dgvKonsultasi.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvKonsultasi.RowTemplate.Height = 30;

            btnRefreshKonsultasi.Text = "Refresh";
            btnRefreshKonsultasi.FlatStyle = FlatStyle.Flat;
            btnRefreshKonsultasi.Location = new Point(12, 522);
            btnRefreshKonsultasi.Size = new Size(110, 32);
            btnRefreshKonsultasi.Click += btnRefreshKonsultasi_Click;

            btnMulaiKonsultasi.Text = "Mulai";
            btnMulaiKonsultasi.FlatStyle = FlatStyle.Flat;
            btnMulaiKonsultasi.Location = new Point(130, 522);
            btnMulaiKonsultasi.Size = new Size(110, 32);
            btnMulaiKonsultasi.Click += btnMulaiKonsultasi_Click;

            btnSelesaikanKonsultasi.Text = "Selesaikan";
            btnSelesaikanKonsultasi.FlatStyle = FlatStyle.Flat;
            btnSelesaikanKonsultasi.Location = new Point(248, 522);
            btnSelesaikanKonsultasi.Size = new Size(110, 32);
            btnSelesaikanKonsultasi.Click += btnSelesaikanKonsultasi_Click;

            btnBatalkanKonsultasi.Text = "Batalkan";
            btnBatalkanKonsultasi.FlatStyle = FlatStyle.Flat;
            btnBatalkanKonsultasi.Location = new Point(366, 522);
            btnBatalkanKonsultasi.Size = new Size(110, 32);
            btnBatalkanKonsultasi.Click += btnBatalkanKonsultasi_Click;

           
            btnKembali.Text = "Kembali";
            btnKembali.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKembali.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnKembali.ForeColor = Color.White;
            btnKembali.FlatStyle = FlatStyle.Flat;
            btnKembali.FlatAppearance.BorderSize = 0;
            btnKembali.Location = new Point(632, 522);
            btnKembali.Size = new Size(120, 32);
            btnKembali.Click += btnKembali_Click;

            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 566);
            Controls.Add(pnlHeader);
            Controls.Add(pnlInfo);
            Controls.Add(gbBuatKonsultasi);
            Controls.Add(dgvKonsultasi);
            Controls.Add(btnRefreshKonsultasi);
            Controls.Add(btnMulaiKonsultasi);
            Controls.Add(btnSelesaikanKonsultasi);
            Controls.Add(btnBatalkanKonsultasi);
            Controls.Add(btnKembali);
            Name = "KonsultasiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Konsultasi";

            ((System.ComponentModel.ISupportInitialize)dgvKonsultasi).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            gbBuatKonsultasi.ResumeLayout(false);
            gbBuatKonsultasi.PerformLayout();
            ResumeLayout(false);
        }
    }
}