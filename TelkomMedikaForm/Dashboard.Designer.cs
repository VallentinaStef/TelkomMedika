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
            btnObat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(343, 143);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // btnLogout
            // 
            btnLogout.AllowDrop = true;
            btnLogout.AutoEllipsis = true;
            btnLogout.Location = new Point(640, 370);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(130, 40);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnObat
            // 
            btnObat.Location = new Point(320, 200);
            btnObat.Name = "btnObat";
            btnObat.Size = new Size(160, 50);
            btnObat.TabIndex = 2;
            btnObat.Text = "Obat & Pengingat";
            btnObat.UseVisualStyleBackColor = true;
            btnObat.Click += btnObat_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnObat);
            Controls.Add(btnLogout);
            Controls.Add(label1);
            Name = "Dashboard";
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnLogout;
        private Button btnObat;
    }
}