namespace TelkomMedikaForm
{
    partial class NotifikasiForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblJudul;
        private Panel pnlInfo;
        private Label lblInfo;
        private GroupBox gbKirimNotifikasi;
        private Label lblUserIdTujuan;
        private TextBox txtUserIdTujuan;
        private Label lblJudul2;
        private TextBox txtJudul;
        private Label lblPesan;
        private TextBox txtPesan;
        private Label lblTipe;
        private ComboBox cmbTipe;
        private Button btnKirimNotifikasi;
        private DataGridView dgvNotifikasi;
        private Button btnRefreshNotifikasi;
        private Button btnTandaiBaca;
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
            gbKirimNotifikasi = new GroupBox();
            lblUserIdTujuan = new Label();
            txtUserIdTujuan = new TextBox();
            lblJudul2 = new Label();
            txtJudul = new TextBox();
            lblPesan = new Label();
            txtPesan = new TextBox();
            lblTipe = new Label();
            cmbTipe = new ComboBox();
            btnKirimNotifikasi = new Button();
            dgvNotifikasi = new DataGridView();
            btnRefreshNotifikasi = new Button();
            btnTandaiBaca = new Button();
            btnKembali = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvNotifikasi).BeginInit();
            pnlHeader.SuspendLayout();
            pnlInfo.SuspendLayout();
            gbKirimNotifikasi.SuspendLayout();
            SuspendLayout();

            
            pnlHeader.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Size = new Size(764, 60);
            pnlHeader.Controls.Add(lblJudul);

            lblJudul.Text = "Notifikasi";
            lblJudul.ForeColor = Color.White;
            lblJudul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblJudul.Location = new Point(20, 12);
            lblJudul.Size = new Size(400, 36);
            lblJudul.BackColor = Color.Transparent;

            
            pnlInfo.BackColor = Color.FromArgb(0xFC, 0xEB, 0xEB);
            pnlInfo.Location = new Point(12, 72);
            pnlInfo.Size = new Size(740, 36);
            pnlInfo.Controls.Add(lblInfo);

            lblInfo.Text = "Notifikasi layanan, jadwal, dan pengingat dari Telkomedika.";
            lblInfo.ForeColor = Color.FromArgb(0x79, 0x1F, 0x1F);
            lblInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblInfo.Location = new Point(10, 9);
            lblInfo.Size = new Size(720, 20);
            lblInfo.BackColor = Color.Transparent;

           
            gbKirimNotifikasi.Text = "Kirim Notifikasi";
            gbKirimNotifikasi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbKirimNotifikasi.Location = new Point(12, 120);
            gbKirimNotifikasi.Size = new Size(740, 185);
            gbKirimNotifikasi.Controls.Add(lblUserIdTujuan);
            gbKirimNotifikasi.Controls.Add(txtUserIdTujuan);
            gbKirimNotifikasi.Controls.Add(lblJudul2);
            gbKirimNotifikasi.Controls.Add(txtJudul);
            gbKirimNotifikasi.Controls.Add(lblPesan);
            gbKirimNotifikasi.Controls.Add(txtPesan);
            gbKirimNotifikasi.Controls.Add(lblTipe);
            gbKirimNotifikasi.Controls.Add(cmbTipe);
            gbKirimNotifikasi.Controls.Add(btnKirimNotifikasi);

            lblUserIdTujuan.Text = "Kirim Ke (User ID)";
            lblUserIdTujuan.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblUserIdTujuan.Location = new Point(15, 30);
            lblUserIdTujuan.Size = new Size(110, 23);

            txtUserIdTujuan.Location = new Point(130, 27);
            txtUserIdTujuan.Size = new Size(270, 23);

            lblJudul2.Text = "Judul";
            lblJudul2.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblJudul2.Location = new Point(15, 65);
            lblJudul2.Size = new Size(80, 23);

            txtJudul.Location = new Point(130, 62);
            txtJudul.Size = new Size(270, 23);

            lblPesan.Text = "Pesan";
            lblPesan.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblPesan.Location = new Point(15, 100);
            lblPesan.Size = new Size(80, 23);

            txtPesan.Location = new Point(130, 97);
            txtPesan.Size = new Size(270, 23);

            lblTipe.Text = "Tipe";
            lblTipe.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblTipe.Location = new Point(15, 135);
            lblTipe.Size = new Size(80, 23);

            cmbTipe.Location = new Point(130, 132);
            cmbTipe.Size = new Size(200, 23);
            cmbTipe.DropDownStyle = ComboBoxStyle.DropDownList;

            btnKirimNotifikasi.Text = "Kirim";
            btnKirimNotifikasi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKirimNotifikasi.Location = new Point(420, 130);
            btnKirimNotifikasi.Size = new Size(100, 30);
            btnKirimNotifikasi.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnKirimNotifikasi.ForeColor = Color.White;
            btnKirimNotifikasi.FlatStyle = FlatStyle.Flat;
            btnKirimNotifikasi.FlatAppearance.BorderSize = 0;
            btnKirimNotifikasi.Click += btnKirimNotifikasi_Click;

           
            dgvNotifikasi.Location = new Point(12, 315);
            dgvNotifikasi.Size = new Size(740, 195);
            dgvNotifikasi.ReadOnly = true;
            dgvNotifikasi.AllowUserToAddRows = false;
            dgvNotifikasi.AllowUserToDeleteRows = false;
            dgvNotifikasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotifikasi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotifikasi.BackgroundColor = Color.White;
            dgvNotifikasi.BorderStyle = BorderStyle.FixedSingle;
            dgvNotifikasi.GridColor = Color.FromArgb(0xE0, 0xE0, 0xE0);
            dgvNotifikasi.RowHeadersVisible = false;
            dgvNotifikasi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNotifikasi.ColumnHeadersHeight = 36;
            dgvNotifikasi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            dgvNotifikasi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNotifikasi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvNotifikasi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvNotifikasi.EnableHeadersVisualStyles = false;
            dgvNotifikasi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            dgvNotifikasi.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvNotifikasi.RowTemplate.Height = 30;

            btnRefreshNotifikasi.Text = "Refresh";
            btnRefreshNotifikasi.FlatStyle = FlatStyle.Flat;
            btnRefreshNotifikasi.Location = new Point(12, 522);
            btnRefreshNotifikasi.Size = new Size(120, 32);
            btnRefreshNotifikasi.Click += btnRefreshNotifikasi_Click;

            btnTandaiBaca.Text = "Tandai Dibaca";
            btnTandaiBaca.FlatStyle = FlatStyle.Flat;
            btnTandaiBaca.Location = new Point(142, 522);
            btnTandaiBaca.Size = new Size(140, 32);
            btnTandaiBaca.Click += btnTandaiBaca_Click;

            
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
            Controls.Add(gbKirimNotifikasi);
            Controls.Add(dgvNotifikasi);
            Controls.Add(btnRefreshNotifikasi);
            Controls.Add(btnTandaiBaca);
            Controls.Add(btnKembali);
            Name = "NotifikasiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Notifikasi";

            ((System.ComponentModel.ISupportInitialize)dgvNotifikasi).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            gbKirimNotifikasi.ResumeLayout(false);
            gbKirimNotifikasi.PerformLayout();
            ResumeLayout(false);
        }
    }
}