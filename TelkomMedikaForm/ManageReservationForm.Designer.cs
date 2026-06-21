namespace TelkomMedikaForm
{
    partial class ManageReservationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblFilterStatus;
        private ComboBox cmbFilterStatus;
        private Label lblFilterPoli;
        private ComboBox cmbFilterPoli;
        private CheckBox chkFilterTanggal;
        private DateTimePicker dtpFilterTanggal;
        private DataGridView dgvReservations;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnUpdate;
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
            lblFilterStatus = new Label();
            cmbFilterStatus = new ComboBox();
            lblFilterPoli = new Label();
            cmbFilterPoli = new ComboBox();
            chkFilterTanggal = new CheckBox();
            dtpFilterTanggal = new DateTimePicker();
            dgvReservations = new DataGridView();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnUpdate = new Button();
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
            lblTitle.Size = new Size(239, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kelola Reservasi";
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFilterStatus.Location = new Point(24, 72);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new Size(52, 20);
            lblFilterStatus.TabIndex = 1;
            lblFilterStatus.Text = "status";
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Location = new Point(82, 69);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(140, 28);
            cmbFilterStatus.TabIndex = 2;
            cmbFilterStatus.SelectedIndexChanged += FilterChanged;
            // 
            // lblFilterPoli
            // 
            lblFilterPoli.AutoSize = true;
            lblFilterPoli.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFilterPoli.Location = new Point(240, 72);
            lblFilterPoli.Name = "lblFilterPoli";
            lblFilterPoli.Size = new Size(35, 20);
            lblFilterPoli.TabIndex = 3;
            lblFilterPoli.Text = "poli";
            // 
            // cmbFilterPoli
            // 
            cmbFilterPoli.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterPoli.FormattingEnabled = true;
            cmbFilterPoli.Location = new Point(281, 69);
            cmbFilterPoli.Name = "cmbFilterPoli";
            cmbFilterPoli.Size = new Size(120, 28);
            cmbFilterPoli.TabIndex = 4;
            cmbFilterPoli.SelectedIndexChanged += FilterChanged;
            // 
            // chkFilterTanggal
            // 
            chkFilterTanggal.AutoSize = true;
            chkFilterTanggal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkFilterTanggal.Location = new Point(420, 71);
            chkFilterTanggal.Name = "chkFilterTanggal";
            chkFilterTanggal.Size = new Size(85, 24);
            chkFilterTanggal.TabIndex = 5;
            chkFilterTanggal.Text = "tanggal";
            chkFilterTanggal.UseVisualStyleBackColor = true;
            chkFilterTanggal.CheckedChanged += FilterChanged;
            // 
            // dtpFilterTanggal
            // 
            dtpFilterTanggal.Format = DateTimePickerFormat.Short;
            dtpFilterTanggal.Location = new Point(511, 69);
            dtpFilterTanggal.Name = "dtpFilterTanggal";
            dtpFilterTanggal.Size = new Size(135, 27);
            dtpFilterTanggal.TabIndex = 6;
            dtpFilterTanggal.ValueChanged += FilterChanged;
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
            dgvReservations.Location = new Point(24, 116);
            dgvReservations.MultiSelect = false;
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(936, 320);
            dgvReservations.TabIndex = 7;
            dgvReservations.CellClick += dgvReservations_CellClick;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(24, 462);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(103, 23);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "ubah status";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(135, 459);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(180, 31);
            cmbStatus.TabIndex = 9;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(330, 456);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(130, 36);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnRefresh.Location = new Point(726, 456);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 36);
            btnRefresh.TabIndex = 11;
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
            btnKembali.TabIndex = 12;
            btnKembali.Text = "kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // ManageReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 516);
            Controls.Add(dtpFilterTanggal);
            Controls.Add(chkFilterTanggal);
            Controls.Add(cmbFilterPoli);
            Controls.Add(lblFilterPoli);
            Controls.Add(cmbFilterStatus);
            Controls.Add(lblFilterStatus);
            Controls.Add(btnKembali);
            Controls.Add(btnRefresh);
            Controls.Add(btnUpdate);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(dgvReservations);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ManageReservationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kelola Reservasi";
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
