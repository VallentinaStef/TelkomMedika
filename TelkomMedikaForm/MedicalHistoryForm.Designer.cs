namespace TelkomMedikaForm
{
    partial class MedicalHistoryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlFilter = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtPatientId = new TextBox();
            lblPatientId = new Label();
            dgvMedicalHistory = new DataGridView();
            lblStatus = new Label();
            btnBack = new Button();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicalHistory).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(784, 93);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(27, 54);
            lblSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(274, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Lihat riwayat layanan medis pasien";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 13);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(314, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Riwayat Layanan";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.White;
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(txtPatientId);
            pnlFilter.Controls.Add(lblPatientId);
            pnlFilter.Location = new Point(24, 116);
            pnlFilter.Margin = new Padding(2);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(736, 70);
            pnlFilter.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnRefresh.Location = new Point(588, 19);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 32);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(453, 19);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 32);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Cari";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtPatientId
            // 
            txtPatientId.Font = new Font("Segoe UI", 10F);
            txtPatientId.Location = new Point(116, 21);
            txtPatientId.Margin = new Padding(2);
            txtPatientId.Name = "txtPatientId";
            txtPatientId.Size = new Size(311, 30);
            txtPatientId.TabIndex = 1;
            txtPatientId.Text = "1";
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPatientId.ForeColor = Color.FromArgb(45, 45, 45);
            lblPatientId.Location = new Point(20, 23);
            lblPatientId.Margin = new Padding(2, 0, 2, 0);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(90, 23);
            lblPatientId.TabIndex = 0;
            lblPatientId.Text = "Patient ID";
            // 
            // dgvMedicalHistory
            // 
            dgvMedicalHistory.AllowUserToAddRows = false;
            dgvMedicalHistory.AllowUserToDeleteRows = false;
            dgvMedicalHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicalHistory.BackgroundColor = Color.White;
            dgvMedicalHistory.BorderStyle = BorderStyle.None;
            dgvMedicalHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicalHistory.Location = new Point(24, 208);
            dgvMedicalHistory.Margin = new Padding(2);
            dgvMedicalHistory.MultiSelect = false;
            dgvMedicalHistory.Name = "dgvMedicalHistory";
            dgvMedicalHistory.ReadOnly = true;
            dgvMedicalHistory.RowHeadersVisible = false;
            dgvMedicalHistory.RowHeadersWidth = 62;
            dgvMedicalHistory.RowTemplate.Height = 33;
            dgvMedicalHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicalHistory.Size = new Size(736, 252);
            dgvMedicalHistory.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(90, 90, 90);
            lblStatus.Location = new Point(24, 472);
            lblStatus.Margin = new Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 3;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(64, 64, 64);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(640, 468);
            btnBack.Margin = new Padding(2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(120, 34);
            btnBack.TabIndex = 4;
            btnBack.Text = "Kembali";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // MedicalHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 252);
            ClientSize = new Size(784, 520);
            Controls.Add(btnBack);
            Controls.Add(lblStatus);
            Controls.Add(dgvMedicalHistory);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Margin = new Padding(2);
            Name = "MedicalHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelkomMedika";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicalHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblSubtitle;
        private Label lblTitle;
        private Panel pnlFilter;
        private Button btnRefresh;
        private Button btnSearch;
        private TextBox txtPatientId;
        private Label lblPatientId;
        private DataGridView dgvMedicalHistory;
        private Label lblStatus;
        private Button btnBack;
    }
}
