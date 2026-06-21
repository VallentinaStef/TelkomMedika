namespace TelkomMedikaForm
{
    partial class DoctorScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblOperational;
        private DataGridView dgvSchedules;
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
            lblOperational = new Label();
            dgvSchedules = new DataGridView();
            btnKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(193, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Jadwal Dokter";
            // 
            // lblOperational
            // 
            lblOperational.BackColor = Color.FromArgb(255, 245, 245);
            lblOperational.BorderStyle = BorderStyle.FixedSingle;
            lblOperational.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOperational.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            lblOperational.Location = new Point(24, 72);
            lblOperational.Name = "lblOperational";
            lblOperational.Padding = new Padding(10, 0, 0, 0);
            lblOperational.Size = new Size(736, 42);
            lblOperational.TabIndex = 1;
            lblOperational.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvSchedules
            // 
            dgvSchedules.AllowUserToAddRows = false;
            dgvSchedules.AllowUserToDeleteRows = false;
            dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedules.BackgroundColor = Color.White;
            dgvSchedules.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            dgvSchedules.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSchedules.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvSchedules.EnableHeadersVisualStyles = false;
            dgvSchedules.Location = new Point(24, 132);
            dgvSchedules.MultiSelect = false;
            dgvSchedules.Name = "dgvSchedules";
            dgvSchedules.ReadOnly = true;
            dgvSchedules.RowHeadersVisible = false;
            dgvSchedules.RowHeadersWidth = 51;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.Size = new Size(736, 338);
            dgvSchedules.TabIndex = 2;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnKembali.FlatStyle = FlatStyle.Flat;
            btnKembali.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKembali.ForeColor = Color.White;
            btnKembali.Location = new Point(660, 488);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(100, 36);
            btnKembali.TabIndex = 3;
            btnKembali.Text = "kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // DoctorScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 546);
            Controls.Add(btnKembali);
            Controls.Add(dgvSchedules);
            Controls.Add(lblOperational);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DoctorScheduleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Jadwal Dokter";
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
