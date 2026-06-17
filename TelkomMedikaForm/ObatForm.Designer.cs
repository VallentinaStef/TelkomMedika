namespace TelkomMedikaForm
{
    partial class ObatForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvJadwal;
        private TextBox txtNama;
        private TextBox txtWaktu;
        private TextBox txtDosis;
        private Button btnTambah;
        private TextBox txtCekJam;
        private Button btnCekReminder;
        private RichTextBox rtbOutput;
        private Button btnConfig;
        private Button btnKembali;
        private GroupBox gbTambah;
        private GroupBox gbPengingat;
        private Label lblNama;
        private Label lblWaktu;
        private Label lblDosis;
        private Label lblJam;
        private Button btnHapus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvJadwal = new DataGridView();
            txtNama = new TextBox();
            txtWaktu = new TextBox();
            txtDosis = new TextBox();
            btnTambah = new Button();
            txtCekJam = new TextBox();
            btnCekReminder = new Button();
            rtbOutput = new RichTextBox();
            btnConfig = new Button();
            btnKembali = new Button();
            gbTambah = new GroupBox();
            lblNama = new Label();
            lblWaktu = new Label();
            lblDosis = new Label();
            gbPengingat = new GroupBox();
            lblJam = new Label();
            btnHapus = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvJadwal).BeginInit();
            gbTambah.SuspendLayout();
            gbPengingat.SuspendLayout();
            SuspendLayout();
            // 
            // dgvJadwal
            // 
            dgvJadwal.AllowUserToAddRows = false;
            dgvJadwal.AllowUserToDeleteRows = false;
            dgvJadwal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvJadwal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJadwal.Location = new Point(12, 12);
            dgvJadwal.MultiSelect = false;
            dgvJadwal.Name = "dgvJadwal";
            dgvJadwal.ReadOnly = true;
            dgvJadwal.RowHeadersVisible = false;
            dgvJadwal.RowHeadersWidth = 51;
            dgvJadwal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJadwal.Size = new Size(660, 200);
            dgvJadwal.TabIndex = 0;
            dgvJadwal.CellClick += dgvJadwal_CellClick;
            // 
            // txtNama
            // 
            txtNama.Location = new Point(70, 27);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(140, 27);
            txtNama.TabIndex = 1;
            // 
            // txtWaktu
            // 
            txtWaktu.Location = new Point(280, 27);
            txtWaktu.Name = "txtWaktu";
            txtWaktu.PlaceholderText = "HH:mm";
            txtWaktu.Size = new Size(80, 27);
            txtWaktu.TabIndex = 3;
            // 
            // txtDosis
            // 
            txtDosis.Location = new Point(420, 27);
            txtDosis.Name = "txtDosis";
            txtDosis.Size = new Size(120, 27);
            txtDosis.TabIndex = 5;
            // 
            // btnTambah
            // 
            btnTambah.Location = new Point(555, 25);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(90, 30);
            btnTambah.TabIndex = 6;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // txtCekJam
            // 
            txtCekJam.Location = new Point(119, 27);
            txtCekJam.Name = "txtCekJam";
            txtCekJam.PlaceholderText = "08:00";
            txtCekJam.Size = new Size(90, 27);
            txtCekJam.TabIndex = 1;
            txtCekJam.TextChanged += txtCekJam_TextChanged;
            // 
            // btnCekReminder
            // 
            btnCekReminder.Location = new Point(217, 25);
            btnCekReminder.Name = "btnCekReminder";
            btnCekReminder.Size = new Size(120, 30);
            btnCekReminder.TabIndex = 2;
            btnCekReminder.Text = "Cek Reminder";
            btnCekReminder.UseVisualStyleBackColor = true;
            btnCekReminder.Click += btnCekReminder_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.BackColor = SystemColors.Window;
            rtbOutput.Location = new Point(10, 60);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.ReadOnly = true;
            rtbOutput.Size = new Size(640, 80);
            rtbOutput.TabIndex = 3;
            rtbOutput.Text = "";
            // 
            // btnConfig
            // 
            btnConfig.Location = new Point(12, 480);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(180, 34);
            btnConfig.TabIndex = 3;
            btnConfig.Text = "Konfigurasi Reminder";
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(592, 480);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(80, 34);
            btnKembali.TabIndex = 4;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // gbTambah
            // 
            gbTambah.Controls.Add(lblNama);
            gbTambah.Controls.Add(lblWaktu);
            gbTambah.Controls.Add(lblDosis);
            gbTambah.Controls.Add(txtNama);
            gbTambah.Controls.Add(txtWaktu);
            gbTambah.Controls.Add(txtDosis);
            gbTambah.Controls.Add(btnTambah);
            gbTambah.Location = new Point(12, 218);
            gbTambah.Name = "gbTambah";
            gbTambah.Size = new Size(660, 100);
            gbTambah.TabIndex = 1;
            gbTambah.TabStop = false;
            gbTambah.Text = "Tambah Jadwal Baru";
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(10, 30);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(52, 20);
            lblNama.TabIndex = 0;
            lblNama.Text = "Nama:";
            // 
            // lblWaktu
            // 
            lblWaktu.AutoSize = true;
            lblWaktu.Location = new Point(220, 30);
            lblWaktu.Name = "lblWaktu";
            lblWaktu.Size = new Size(53, 20);
            lblWaktu.TabIndex = 2;
            lblWaktu.Text = "Waktu:";
            // 
            // lblDosis
            // 
            lblDosis.AutoSize = true;
            lblDosis.Location = new Point(370, 30);
            lblDosis.Name = "lblDosis";
            lblDosis.Size = new Size(48, 20);
            lblDosis.TabIndex = 4;
            lblDosis.Text = "Dosis:";
            // 
            // gbPengingat
            // 
            gbPengingat.Controls.Add(lblJam);
            gbPengingat.Controls.Add(txtCekJam);
            gbPengingat.Controls.Add(btnCekReminder);
            gbPengingat.Controls.Add(rtbOutput);
            gbPengingat.Location = new Point(12, 324);
            gbPengingat.Name = "gbPengingat";
            gbPengingat.Size = new Size(660, 150);
            gbPengingat.TabIndex = 2;
            gbPengingat.TabStop = false;
            gbPengingat.Text = "Pengingat Obat";
            // 
            // lblJam
            // 
            lblJam.AutoSize = true;
            lblJam.Location = new Point(10, 30);
            lblJam.Name = "lblJam";
            lblJam.Size = new Size(103, 20);
            lblJam.TabIndex = 0;
            lblJam.Text = "Jam (HH:mm):";
            // 
            // btnHapus
            // 
            btnHapus.Location = new Point(567, 170);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(90, 30);
            btnHapus.TabIndex = 7;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = true;
            btnHapus.Click += btnHapus_Click;
            // 
            // ObatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 526);
            Controls.Add(btnHapus);
            Controls.Add(btnKembali);
            Controls.Add(btnConfig);
            Controls.Add(gbPengingat);
            Controls.Add(gbTambah);
            Controls.Add(dgvJadwal);
            Name = "ObatForm";
            Text = "Obat & Pengingat";
            ((System.ComponentModel.ISupportInitialize)dgvJadwal).EndInit();
            gbTambah.ResumeLayout(false);
            gbTambah.PerformLayout();
            gbPengingat.ResumeLayout(false);
            gbPengingat.PerformLayout();
            ResumeLayout(false);
        }
    }
}
