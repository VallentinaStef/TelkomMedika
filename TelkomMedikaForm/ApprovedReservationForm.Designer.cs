namespace TelkomMedikaForm
{
    partial class ApprovedReservationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblDokter;
        private ComboBox cmbDokter;
        private DataGridView dgvReservations;
        private Button btnRefresh;
        private Button btnKembali;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblDokter = new Label();
            cmbDokter = new ComboBox();
            dgvReservations = new DataGridView();
            btnRefresh = new Button();
            btnKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(263, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reservasi Disetujui";
            // 
            // lblDokter
            // 
            lblDokter.AutoSize = true;
            lblDokter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDokter.Location = new Point(24, 76);
            lblDokter.Name = "lblDokter";
            lblDokter.Size = new Size(104, 23);
            lblDokter.TabIndex = 1;
            lblDokter.Text = "filter dokter";
            // 
            // cmbDokter
            // 
            cmbDokter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDokter.Font = new Font("Segoe UI", 10F);
            cmbDokter.FormattingEnabled = true;
            cmbDokter.Location = new Point(140, 73);
            cmbDokter.Name = "cmbDokter";
            cmbDokter.Size = new Size(260, 31);
            cmbDokter.TabIndex = 2;
            cmbDokter.SelectedIndexChanged += cmbDokter_SelectedIndexChanged;
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.BackgroundColor = Color.White;
            dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvReservations.EnableHeadersVisualStyles = false;
            dgvReservations.Location = new Point(24, 124);
            dgvReservations.MultiSelect = false;
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(936, 312);
            dgvReservations.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(726, 456);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 36);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.White;
            btnKembali.FlatStyle = FlatStyle.Flat;
            btnKembali.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKembali.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnKembali.Location = new Point(850, 456);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(110, 36);
            btnKembali.TabIndex = 5;
            btnKembali.Text = "kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // ApprovedReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 516);
            Controls.Add(btnKembali);
            Controls.Add(btnRefresh);
            Controls.Add(dgvReservations);
            Controls.Add(cmbDokter);
            Controls.Add(lblDokter);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ApprovedReservationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reservasi Disetujui";
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
