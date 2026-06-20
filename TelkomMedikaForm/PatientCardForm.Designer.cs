namespace TelkomMedikaForm
{
    partial class PatientCardForm
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
            pnlCard = new Panel();
            lblCardAddress = new Label();
            lblAddressCaption = new Label();
            lblCardBirthDate = new Label();
            lblBirthDateCaption = new Label();
            lblCardGender = new Label();
            lblGenderCaption = new Label();
            lblCardName = new Label();
            lblNameCaption = new Label();
            lblCardPatientId = new Label();
            lblIdCaption = new Label();
            lblCardBadge = new Label();
            lblCardTitle = new Label();
            lblStatus = new Label();
            btnBack = new Button();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlCard.SuspendLayout();
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
            pnlHeader.Size = new Size(784, 93);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(27, 54);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(281, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Akses identitas pasien secara digital";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(366, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kartu Pasien Digital";
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
            pnlFilter.Size = new Size(736, 70);
            pnlFilter.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = Color.FromArgb(0, 112, 192);
            btnRefresh.Location = new Point(588, 19);
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
            btnSearch.Location = new Point(453, 19);
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
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(90, 23);
            lblPatientId.TabIndex = 0;
            lblPatientId.Text = "Patient ID";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblCardAddress);
            pnlCard.Controls.Add(lblAddressCaption);
            pnlCard.Controls.Add(lblCardBirthDate);
            pnlCard.Controls.Add(lblBirthDateCaption);
            pnlCard.Controls.Add(lblCardGender);
            pnlCard.Controls.Add(lblGenderCaption);
            pnlCard.Controls.Add(lblCardName);
            pnlCard.Controls.Add(lblNameCaption);
            pnlCard.Controls.Add(lblCardPatientId);
            pnlCard.Controls.Add(lblIdCaption);
            pnlCard.Controls.Add(lblCardBadge);
            pnlCard.Controls.Add(lblCardTitle);
            pnlCard.Location = new Point(154, 214);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(476, 232);
            pnlCard.TabIndex = 2;
            // 
            // lblCardAddress
            // 
            lblCardAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardAddress.ForeColor = Color.FromArgb(45, 45, 45);
            lblCardAddress.Location = new Point(166, 174);
            lblCardAddress.Name = "lblCardAddress";
            lblCardAddress.Size = new Size(284, 45);
            lblCardAddress.TabIndex = 11;
            lblCardAddress.Text = "-";
            // 
            // lblAddressCaption
            // 
            lblAddressCaption.AutoSize = true;
            lblAddressCaption.Font = new Font("Segoe UI", 9F);
            lblAddressCaption.ForeColor = Color.FromArgb(90, 90, 90);
            lblAddressCaption.Location = new Point(26, 174);
            lblAddressCaption.Name = "lblAddressCaption";
            lblAddressCaption.Size = new Size(57, 20);
            lblAddressCaption.TabIndex = 10;
            lblAddressCaption.Text = "Alamat";
            // 
            // lblCardBirthDate
            // 
            lblCardBirthDate.AutoSize = true;
            lblCardBirthDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardBirthDate.ForeColor = Color.FromArgb(45, 45, 45);
            lblCardBirthDate.Location = new Point(166, 144);
            lblCardBirthDate.Name = "lblCardBirthDate";
            lblCardBirthDate.Size = new Size(15, 20);
            lblCardBirthDate.TabIndex = 9;
            lblCardBirthDate.Text = "-";
            // 
            // lblBirthDateCaption
            // 
            lblBirthDateCaption.AutoSize = true;
            lblBirthDateCaption.Font = new Font("Segoe UI", 9F);
            lblBirthDateCaption.ForeColor = Color.FromArgb(90, 90, 90);
            lblBirthDateCaption.Location = new Point(26, 144);
            lblBirthDateCaption.Name = "lblBirthDateCaption";
            lblBirthDateCaption.Size = new Size(97, 20);
            lblBirthDateCaption.TabIndex = 8;
            lblBirthDateCaption.Text = "Tanggal Lahir";
            // 
            // lblCardGender
            // 
            lblCardGender.AutoSize = true;
            lblCardGender.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardGender.ForeColor = Color.FromArgb(45, 45, 45);
            lblCardGender.Location = new Point(166, 114);
            lblCardGender.Name = "lblCardGender";
            lblCardGender.Size = new Size(15, 20);
            lblCardGender.TabIndex = 7;
            lblCardGender.Text = "-";
            // 
            // lblGenderCaption
            // 
            lblGenderCaption.AutoSize = true;
            lblGenderCaption.Font = new Font("Segoe UI", 9F);
            lblGenderCaption.ForeColor = Color.FromArgb(90, 90, 90);
            lblGenderCaption.Location = new Point(26, 114);
            lblGenderCaption.Name = "lblGenderCaption";
            lblGenderCaption.Size = new Size(98, 20);
            lblGenderCaption.TabIndex = 6;
            lblGenderCaption.Text = "Jenis Kelamin";
            // 
            // lblCardName
            // 
            lblCardName.AutoSize = true;
            lblCardName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardName.ForeColor = Color.FromArgb(45, 45, 45);
            lblCardName.Location = new Point(166, 84);
            lblCardName.Name = "lblCardName";
            lblCardName.Size = new Size(15, 20);
            lblCardName.TabIndex = 5;
            lblCardName.Text = "-";
            // 
            // lblNameCaption
            // 
            lblNameCaption.AutoSize = true;
            lblNameCaption.Font = new Font("Segoe UI", 9F);
            lblNameCaption.ForeColor = Color.FromArgb(90, 90, 90);
            lblNameCaption.Location = new Point(26, 84);
            lblNameCaption.Name = "lblNameCaption";
            lblNameCaption.Size = new Size(94, 20);
            lblNameCaption.TabIndex = 4;
            lblNameCaption.Text = "Nama Pasien";
            // 
            // lblCardPatientId
            // 
            lblCardPatientId.AutoSize = true;
            lblCardPatientId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardPatientId.ForeColor = Color.FromArgb(45, 45, 45);
            lblCardPatientId.Location = new Point(166, 54);
            lblCardPatientId.Name = "lblCardPatientId";
            lblCardPatientId.Size = new Size(15, 20);
            lblCardPatientId.TabIndex = 3;
            lblCardPatientId.Text = "-";
            // 
            // lblIdCaption
            // 
            lblIdCaption.AutoSize = true;
            lblIdCaption.Font = new Font("Segoe UI", 9F);
            lblIdCaption.ForeColor = Color.FromArgb(90, 90, 90);
            lblIdCaption.Location = new Point(26, 54);
            lblIdCaption.Name = "lblIdCaption";
            lblIdCaption.Size = new Size(73, 20);
            lblIdCaption.TabIndex = 2;
            lblIdCaption.Text = "Patient ID";
            // 
            // lblCardBadge
            // 
            lblCardBadge.AutoSize = true;
            lblCardBadge.BackColor = Color.FromArgb(232, 244, 255);
            lblCardBadge.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCardBadge.ForeColor = Color.FromArgb(0, 112, 192);
            lblCardBadge.Location = new Point(356, 16);
            lblCardBadge.Name = "lblCardBadge";
            lblCardBadge.Size = new Size(104, 19);
            lblCardBadge.TabIndex = 1;
            lblCardBadge.Text = "TELKOMEDIKA";
            // 
            // lblCardTitle
            // 
            lblCardTitle.AutoSize = true;
            lblCardTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCardTitle.ForeColor = Color.FromArgb(0, 112, 192);
            lblCardTitle.Location = new Point(22, 16);
            lblCardTitle.Name = "lblCardTitle";
            lblCardTitle.Size = new Size(185, 28);
            lblCardTitle.TabIndex = 0;
            lblCardTitle.Text = "Kartu Pasien Aktif";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(90, 90, 90);
            lblStatus.Location = new Point(24, 472);
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
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(120, 34);
            btnBack.TabIndex = 4;
            btnBack.Text = "Kembali";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // PatientCardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 252);
            ClientSize = new Size(784, 520);
            Controls.Add(btnBack);
            Controls.Add(lblStatus);
            Controls.Add(pnlCard);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Name = "PatientCardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelkomMedika";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
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
        private Panel pnlCard;
        private Label lblCardAddress;
        private Label lblAddressCaption;
        private Label lblCardBirthDate;
        private Label lblBirthDateCaption;
        private Label lblCardGender;
        private Label lblGenderCaption;
        private Label lblCardName;
        private Label lblNameCaption;
        private Label lblCardPatientId;
        private Label lblIdCaption;
        private Label lblCardBadge;
        private Label lblCardTitle;
        private Label lblStatus;
        private Button btnBack;
    }
}
