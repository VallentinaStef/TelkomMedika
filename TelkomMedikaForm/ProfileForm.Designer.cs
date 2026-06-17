namespace TelkomMedikaForm
{
    partial class ProfileForm
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

        private void InitializeComponent()
        {
            panelCard = new Panel();
            lblProfileTitle = new Label();
            lblUsernameLabel = new Label();
            lblUsernameValue = new Label();
            lblRoleLabel = new Label();
            lblRoleValue = new Label();
            lblNameLabel = new Label();
            lblNameValue = new Label();
            btnEdit = new Button();
            btnLogout = new Button();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(lblProfileTitle);
            panelCard.Controls.Add(lblUsernameLabel);
            panelCard.Controls.Add(lblUsernameValue);
            panelCard.Controls.Add(lblRoleLabel);
            panelCard.Controls.Add(lblRoleValue);
            panelCard.Controls.Add(lblNameLabel);
            panelCard.Controls.Add(lblNameValue);
            panelCard.Controls.Add(btnEdit);
            panelCard.Controls.Add(btnLogout);
            panelCard.Location = new Point(200, 80);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(400, 320);
            panelCard.TabIndex = 0;
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.AutoSize = true;
            lblProfileTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblProfileTitle.ForeColor = Color.Teal;
            lblProfileTitle.Location = new Point(155, 20);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(82, 37);
            lblProfileTitle.TabIndex = 0;
            lblProfileTitle.Text = "Profil";
            // 
            // lblUsernameLabel
            // 
            lblUsernameLabel.AutoSize = true;
            lblUsernameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUsernameLabel.Location = new Point(60, 90);
            lblUsernameLabel.Name = "lblUsernameLabel";
            lblUsernameLabel.Size = new Size(102, 25);
            lblUsernameLabel.TabIndex = 1;
            lblUsernameLabel.Text = "Username:";
            // 
            // lblUsernameValue
            // 
            lblUsernameValue.AutoSize = true;
            lblUsernameValue.Font = new Font("Segoe UI", 11F);
            lblUsernameValue.Location = new Point(60, 120);
            lblUsernameValue.Name = "lblUsernameValue";
            lblUsernameValue.Size = new Size(0, 25);
            lblUsernameValue.TabIndex = 2;
            // 
            // lblRoleLabel
            // 
            lblRoleLabel.AutoSize = true;
            lblRoleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRoleLabel.Location = new Point(60, 160);
            lblRoleLabel.Name = "lblRoleLabel";
            lblRoleLabel.Size = new Size(58, 25);
            lblRoleLabel.TabIndex = 3;
            lblRoleLabel.Text = "Role:";
            // 
            // lblRoleValue
            // 
            lblRoleValue.AutoSize = true;
            lblRoleValue.Font = new Font("Segoe UI", 11F);
            lblRoleValue.Location = new Point(60, 190);
            lblRoleValue.Name = "lblRoleValue";
            lblRoleValue.Size = new Size(0, 25);
            lblRoleValue.TabIndex = 4;
            // 
            // lblNameLabel
            // 
            lblNameLabel.AutoSize = true;
            lblNameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNameLabel.Location = new Point(60, 230);
            lblNameLabel.Name = "lblNameLabel";
            lblNameLabel.Size = new Size(65, 25);
            lblNameLabel.TabIndex = 5;
            lblNameLabel.Text = "Nama:";
            // 
            // lblNameValue
            // 
            lblNameValue.AutoSize = true;
            lblNameValue.Font = new Font("Segoe UI", 11F);
            lblNameValue.Location = new Point(60, 260);
            lblNameValue.Name = "lblNameValue";
            lblNameValue.Size = new Size(0, 25);
            lblNameValue.TabIndex = 6;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.DodgerBlue;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(120, 320);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(240, 320);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 35);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(800, 480);
            Controls.Add(panelCard);
            Name = "ProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelkomMedika - Profil";
            Load += ProfileForm_Load;
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelCard;
        private Label lblProfileTitle;
        private Label lblUsernameLabel;
        private Label lblUsernameValue;
        private Label lblRoleLabel;
        private Label lblRoleValue;
        private Label lblNameLabel;
        private Label lblNameValue;
        private Button btnEdit;
        private Button btnLogout;
    }
}
