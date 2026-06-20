namespace TelkomMedikaForm
{
    partial class MedicalRecordForm
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
            dgvMedicalRecords = new DataGridView();
            pnlDetail = new Panel();
            txtMedicine = new TextBox();
            lblMedicineCaption = new Label();
            txtDiagnosis = new TextBox();
            lblDiagnosisCaption = new Label();
            txtComplaint = new TextBox();
            lblComplaintCaption = new Label();
            lblDetailDate = new Label();
            lblDateCaption = new Label();
            lblDetailDoctor = new Label();
            lblDoctorCaption = new Label();
            lblDetailPatient = new Label();
            lblPatientCaption = new Label();
            lblDetailId = new Label();
            lblIdCaption = new Label();
            lblDetailTitle = new Label();
            lblStatus = new Label();
            btnBack = new Button();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicalRecords).BeginInit();
            pnlDetail.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 112, 192);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(980, 93);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(27, 54);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(242, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Lihat data rekam medis pasien";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(382, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Rekam Medis Digital";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.White;
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(txtPatientId);
            pnlFilter.Controls.Add(lblPatientId);
            pnlFilter.Location = new Point(24, 116);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(932, 70);
            pnlFilter.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = Color.FromArgb(0, 112, 192);
            btnRefresh.Location = new Point(784, 19);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 32);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 112, 192);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(649, 19);
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
            txtPatientId.Name = "txtPatientId";
            txtPatientId.Size = new Size(505, 30);
            txtPatientId.TabIndex = 1;
            txtPatientId.Text = "1";
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPatientId.ForeColor = Color.FromArgb(45, 45, 45);
            lblPatientId.Location = new Point(20, 23);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(90, 23);
            lblPatientId.TabIndex = 0;
            lblPatientId.Text = "Patient ID";
            // 
            // dgvMedicalRecords
            // 
            dgvMedicalRecords.AllowUserToAddRows = false;
            dgvMedicalRecords.AllowUserToDeleteRows = false;
            dgvMedicalRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicalRecords.BackgroundColor = Color.White;
            dgvMedicalRecords.BorderStyle = BorderStyle.None;
            dgvMedicalRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicalRecords.Location = new Point(24, 208);
            dgvMedicalRecords.MultiSelect = false;
            dgvMedicalRecords.Name = "dgvMedicalRecords";
            dgvMedicalRecords.ReadOnly = true;
            dgvMedicalRecords.RowHeadersWidth = 51;
            dgvMedicalRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicalRecords.Size = new Size(932, 190);
            dgvMedicalRecords.TabIndex = 2;
            dgvMedicalRecords.SelectionChanged += dgvMedicalRecords_SelectionChanged;
            // 
            // pnlDetail
            // 
            pnlDetail.BackColor = Color.White;
            pnlDetail.Controls.Add(txtMedicine);
            pnlDetail.Controls.Add(lblMedicineCaption);
            pnlDetail.Controls.Add(txtDiagnosis);
            pnlDetail.Controls.Add(lblDiagnosisCaption);
            pnlDetail.Controls.Add(txtComplaint);
            pnlDetail.Controls.Add(lblComplaintCaption);
            pnlDetail.Controls.Add(lblDetailDate);
            pnlDetail.Controls.Add(lblDateCaption);
            pnlDetail.Controls.Add(lblDetailDoctor);
            pnlDetail.Controls.Add(lblDoctorCaption);
            pnlDetail.Controls.Add(lblDetailPatient);
            pnlDetail.Controls.Add(lblPatientCaption);
            pnlDetail.Controls.Add(lblDetailId);
            pnlDetail.Controls.Add(lblIdCaption);
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Location = new Point(24, 417);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(932, 260);
            pnlDetail.TabIndex = 3;
            // 
            // txtMedicine
            // 
            txtMedicine.BackColor = Color.FromArgb(245, 248, 252);
            txtMedicine.BorderStyle = BorderStyle.None;
            txtMedicine.Font = new Font("Segoe UI", 9F);
            txtMedicine.Location = new Point(638, 144);
            txtMedicine.Multiline = true;
            txtMedicine.Name = "txtMedicine";
            txtMedicine.ReadOnly = true;
            txtMedicine.Size = new Size(266, 88);
            txtMedicine.TabIndex = 14;
            // 
            // lblMedicineCaption
            // 
            lblMedicineCaption.AutoSize = true;
            lblMedicineCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMedicineCaption.ForeColor = Color.FromArgb(0, 112, 192);
            lblMedicineCaption.Location = new Point(638, 115);
            lblMedicineCaption.Name = "lblMedicineCaption";
            lblMedicineCaption.Size = new Size(43, 20);
            lblMedicineCaption.TabIndex = 13;
            lblMedicineCaption.Text = "Obat";
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.BackColor = Color.FromArgb(245, 248, 252);
            txtDiagnosis.BorderStyle = BorderStyle.None;
            txtDiagnosis.Font = new Font("Segoe UI", 9F);
            txtDiagnosis.Location = new Point(332, 144);
            txtDiagnosis.Multiline = true;
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.ReadOnly = true;
            txtDiagnosis.Size = new Size(266, 88);
            txtDiagnosis.TabIndex = 12;
            // 
            // lblDiagnosisCaption
            // 
            lblDiagnosisCaption.AutoSize = true;
            lblDiagnosisCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDiagnosisCaption.ForeColor = Color.FromArgb(0, 112, 192);
            lblDiagnosisCaption.Location = new Point(332, 115);
            lblDiagnosisCaption.Name = "lblDiagnosisCaption";
            lblDiagnosisCaption.Size = new Size(77, 20);
            lblDiagnosisCaption.TabIndex = 11;
            lblDiagnosisCaption.Text = "Diagnosis";
            // 
            // txtComplaint
            // 
            txtComplaint.BackColor = Color.FromArgb(245, 248, 252);
            txtComplaint.BorderStyle = BorderStyle.None;
            txtComplaint.Font = new Font("Segoe UI", 9F);
            txtComplaint.Location = new Point(26, 144);
            txtComplaint.Multiline = true;
            txtComplaint.Name = "txtComplaint";
            txtComplaint.ReadOnly = true;
            txtComplaint.Size = new Size(266, 88);
            txtComplaint.TabIndex = 10;
            // 
            // lblComplaintCaption
            // 
            lblComplaintCaption.AutoSize = true;
            lblComplaintCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblComplaintCaption.ForeColor = Color.FromArgb(0, 112, 192);
            lblComplaintCaption.Location = new Point(26, 115);
            lblComplaintCaption.Name = "lblComplaintCaption";
            lblComplaintCaption.Size = new Size(66, 20);
            lblComplaintCaption.TabIndex = 9;
            lblComplaintCaption.Text = "Keluhan";
            // 
            // lblDetailDate
            // 
            lblDetailDate.AutoSize = true;
            lblDetailDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailDate.ForeColor = Color.FromArgb(45, 45, 45);
            lblDetailDate.Location = new Point(638, 75);
            lblDetailDate.Name = "lblDetailDate";
            lblDetailDate.Size = new Size(15, 20);
            lblDetailDate.TabIndex = 8;
            lblDetailDate.Text = "-";
            // 
            // lblDateCaption
            // 
            lblDateCaption.AutoSize = true;
            lblDateCaption.Font = new Font("Segoe UI", 9F);
            lblDateCaption.ForeColor = Color.FromArgb(90, 90, 90);
            lblDateCaption.Location = new Point(638, 50);
            lblDateCaption.Name = "lblDateCaption";
            lblDateCaption.Size = new Size(118, 20);
            lblDateCaption.TabIndex = 7;
            lblDateCaption.Text = "Tanggal Berobat";
            // 
            // lblDetailDoctor
            // 
            lblDetailDoctor.AutoSize = true;
            lblDetailDoctor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailDoctor.ForeColor = Color.FromArgb(45, 45, 45);
            lblDetailDoctor.Location = new Point(434, 75);
            lblDetailDoctor.Name = "lblDetailDoctor";
            lblDetailDoctor.Size = new Size(15, 20);
            lblDetailDoctor.TabIndex = 6;
            lblDetailDoctor.Text = "-";
            // 
            // lblDoctorCaption
            // 
            lblDoctorCaption.AutoSize = true;
            lblDoctorCaption.Font = new Font("Segoe UI", 9F);
            lblDoctorCaption.ForeColor = Color.FromArgb(90, 90, 90);
            lblDoctorCaption.Location = new Point(434, 50);
            lblDoctorCaption.Name = "lblDoctorCaption";
            lblDoctorCaption.Size = new Size(54, 20);
            lblDoctorCaption.TabIndex = 5;
            lblDoctorCaption.Text = "Dokter";
            // 
            // lblDetailPatient
            // 
            lblDetailPatient.AutoSize = true;
            lblDetailPatient.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailPatient.ForeColor = Color.FromArgb(45, 45, 45);
            lblDetailPatient.Location = new Point(130, 75);
            lblDetailPatient.Name = "lblDetailPatient";
            lblDetailPatient.Size = new Size(15, 20);
            lblDetailPatient.TabIndex = 4;
            lblDetailPatient.Text = "-";
            // 
            // lblPatientCaption
            // 
            lblPatientCaption.AutoSize = true;
            lblPatientCaption.Font = new Font("Segoe UI", 9F);
            lblPatientCaption.ForeColor = Color.FromArgb(90, 90, 90);
            lblPatientCaption.Location = new Point(130, 50);
            lblPatientCaption.Name = "lblPatientCaption";
            lblPatientCaption.Size = new Size(50, 20);
            lblPatientCaption.TabIndex = 3;
            lblPatientCaption.Text = "Pasien";
            // 
            // lblDetailId
            // 
            lblDetailId.AutoSize = true;
            lblDetailId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailId.ForeColor = Color.FromArgb(45, 45, 45);
            lblDetailId.Location = new Point(26, 75);
            lblDetailId.Name = "lblDetailId";
            lblDetailId.Size = new Size(15, 20);
            lblDetailId.TabIndex = 2;
            lblDetailId.Text = "-";
            // 
            // lblIdCaption
            // 
            lblIdCaption.AutoSize = true;
            lblIdCaption.Font = new Font("Segoe UI", 9F);
            lblIdCaption.ForeColor = Color.FromArgb(90, 90, 90);
            lblIdCaption.Location = new Point(26, 50);
            lblIdCaption.Name = "lblIdCaption";
            lblIdCaption.Size = new Size(75, 20);
            lblIdCaption.TabIndex = 1;
            lblIdCaption.Text = "Record ID";
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(0, 112, 192);
            lblDetailTitle.Location = new Point(22, 16);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(118, 28);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "Detail EMR";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(90, 90, 90);
            lblStatus.Location = new Point(24, 695);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 4;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(64, 64, 64);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(836, 690);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(120, 34);
            btnBack.TabIndex = 5;
            btnBack.Text = "Kembali";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // MedicalRecordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 252);
            ClientSize = new Size(980, 742);
            Controls.Add(btnBack);
            Controls.Add(lblStatus);
            Controls.Add(pnlDetail);
            Controls.Add(dgvMedicalRecords);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Name = "MedicalRecordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelkomMedika";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicalRecords).EndInit();
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
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
        private DataGridView dgvMedicalRecords;
        private Panel pnlDetail;
        private TextBox txtMedicine;
        private Label lblMedicineCaption;
        private TextBox txtDiagnosis;
        private Label lblDiagnosisCaption;
        private TextBox txtComplaint;
        private Label lblComplaintCaption;
        private Label lblDetailDate;
        private Label lblDateCaption;
        private Label lblDetailDoctor;
        private Label lblDoctorCaption;
        private Label lblDetailPatient;
        private Label lblPatientCaption;
        private Label lblDetailId;
        private Label lblIdCaption;
        private Label lblDetailTitle;
        private Label lblStatus;
        private Button btnBack;
    }
}
