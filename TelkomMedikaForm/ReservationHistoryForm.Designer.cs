namespace TelkomMedikaForm
{
    partial class ReservationHistoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvReservations;
        private Button btnDetail;
        private Button btnBatal;
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
            dgvReservations = new DataGridView();
            btnDetail = new Button();
            btnBatal = new Button();
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
            lblTitle.Size = new Size(238, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Riwayat Reservasi";
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
            dgvReservations.Location = new Point(24, 76);
            dgvReservations.MultiSelect = false;
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(836, 340);
            dgvReservations.TabIndex = 1;
            dgvReservations.CellClick += dgvReservations_CellClick;
            // 
            // btnDetail
            // 
            btnDetail.BackColor = Color.White;
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDetail.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnDetail.Location = new Point(392, 438);
            btnDetail.Name = "btnDetail";
            btnDetail.Size = new Size(110, 36);
            btnDetail.TabIndex = 2;
            btnDetail.Text = "detail";
            btnDetail.UseVisualStyleBackColor = false;
            btnDetail.Click += btnDetail_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.White;
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBatal.ForeColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnBatal.Location = new Point(508, 438);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(110, 36);
            btnBatal.TabIndex = 3;
            btnBatal.Text = "batalkan";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(626, 438);
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
            btnKembali.Location = new Point(750, 438);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(110, 36);
            btnKembali.TabIndex = 5;
            btnKembali.Text = "kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // ReservationHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(884, 496);
            Controls.Add(btnKembali);
            Controls.Add(btnRefresh);
            Controls.Add(btnBatal);
            Controls.Add(btnDetail);
            Controls.Add(dgvReservations);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReservationHistoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Riwayat Reservasi";
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
