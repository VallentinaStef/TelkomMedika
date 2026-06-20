namespace TelkomMedikaForm
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnLogout = new Button();
            btnMedicalHistory = new Button();
            btnPatientCard = new Button();
            btnMedicalRecord = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 114);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // btnLogout
            // 
            btnLogout.AllowDrop = true;
            btnLogout.AutoEllipsis = true;
            btnLogout.Location = new Point(467, 273);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(90, 27);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMedicalHistory
            // 
            btnMedicalHistory.BackColor = Color.FromArgb(0, 112, 192);
            btnMedicalHistory.FlatStyle = FlatStyle.Flat;
            btnMedicalHistory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMedicalHistory.ForeColor = Color.White;
            btnMedicalHistory.Location = new Point(237, 171);
            btnMedicalHistory.Margin = new Padding(2);
            btnMedicalHistory.Name = "btnMedicalHistory";
            btnMedicalHistory.Size = new Size(166, 35);
            btnMedicalHistory.TabIndex = 2;
            btnMedicalHistory.Text = "Riwayat Layanan";
            btnMedicalHistory.UseVisualStyleBackColor = false;
            btnMedicalHistory.Click += btnMedicalHistory_Click;
            // 
            // btnPatientCard
            // 
            btnPatientCard.BackColor = Color.FromArgb(0, 112, 192);
            btnPatientCard.FlatStyle = FlatStyle.Flat;
            btnPatientCard.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPatientCard.ForeColor = Color.White;
            btnPatientCard.Location = new Point(237, 222);
            btnPatientCard.Margin = new Padding(2);
            btnPatientCard.Name = "btnPatientCard";
            btnPatientCard.Size = new Size(166, 35);
            btnPatientCard.TabIndex = 3;
            btnPatientCard.Text = "Kartu Pasien Digital";
            btnPatientCard.UseVisualStyleBackColor = false;
            btnPatientCard.Click += btnPatientCard_Click;
            // 
            // btnMedicalRecord
            // 
            btnMedicalRecord.BackColor = Color.FromArgb(0, 112, 192);
            btnMedicalRecord.FlatStyle = FlatStyle.Flat;
            btnMedicalRecord.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMedicalRecord.ForeColor = Color.White;
            btnMedicalRecord.Location = new Point(237, 273);
            btnMedicalRecord.Margin = new Padding(2);
            btnMedicalRecord.Name = "btnMedicalRecord";
            btnMedicalRecord.Size = new Size(166, 35);
            btnMedicalRecord.TabIndex = 4;
            btnMedicalRecord.Text = "Rekam Medis Digital";
            btnMedicalRecord.UseVisualStyleBackColor = false;
            btnMedicalRecord.Click += btnMedicalRecord_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(btnMedicalRecord);
            Controls.Add(btnPatientCard);
            Controls.Add(btnMedicalHistory);
            Controls.Add(btnLogout);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "Dashboard";
            Text = "TelkomMedika";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnLogout;
        private Button btnMedicalHistory;
        private Button btnPatientCard;
        private Button btnMedicalRecord;
    }
}
