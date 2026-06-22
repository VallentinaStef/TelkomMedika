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
            btnBack = new Button();
            lblProfileTitle = new Label();
            lblUsernameLabel = new Label();
            lblUsernameValue = new Label();
            lblRoleLabel = new Label();
            lblRoleValue = new Label();
            lblNameLabel = new Label();
            lblNameValue = new Label();
            lblNoTelpLabel = new Label();
            lblNoTelpValue = new Label();
            lblAlamatLabel = new Label();
            lblAlamatValue = new Label();
            btnEdit = new Button();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(btnBack);
            panelCard.Controls.Add(lblProfileTitle);
            panelCard.Controls.Add(lblUsernameLabel);
            panelCard.Controls.Add(lblUsernameValue);
            panelCard.Controls.Add(lblRoleLabel);
            panelCard.Controls.Add(lblRoleValue);
            panelCard.Controls.Add(lblNameLabel);
            panelCard.Controls.Add(lblNameValue);
            panelCard.Controls.Add(lblNoTelpLabel);
            panelCard.Controls.Add(lblNoTelpValue);
            panelCard.Controls.Add(lblAlamatLabel);
            panelCard.Controls.Add(lblAlamatValue);
            panelCard.Controls.Add(btnEdit);
            panelCard.Location = new Point(250, 100);
            panelCard.Margin = new Padding(4);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(500, 610);
            panelCard.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.FromArgb(51, 51, 51);
            btnBack.Location = new Point(20, 15);
            btnBack.Margin = new Padding(4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(55, 40);
            btnBack.TabIndex = 7;
            btnBack.Text = "<-- Kembali";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.AutoSize = true;
            lblProfileTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblProfileTitle.ForeColor = Color.FromArgb(198, 40, 40);
            lblProfileTitle.Location = new Point(194, 25);
            lblProfileTitle.Margin = new Padding(4, 0, 4, 0);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(103, 45);
            lblProfileTitle.TabIndex = 0;
            lblProfileTitle.Text = "Profil";
            // 
            // lblUsernameLabel
            // 
            lblUsernameLabel.AutoSize = true;
            lblUsernameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUsernameLabel.Location = new Point(75, 112);
            lblUsernameLabel.Margin = new Padding(4, 0, 4, 0);
            lblUsernameLabel.Name = "lblUsernameLabel";
            lblUsernameLabel.Size = new Size(123, 30);
            lblUsernameLabel.TabIndex = 1;
            lblUsernameLabel.Text = "Username:";
            // 
            // lblUsernameValue
            // 
            lblUsernameValue.AutoSize = true;
            lblUsernameValue.Font = new Font("Segoe UI", 11F);
            lblUsernameValue.Location = new Point(75, 150);
            lblUsernameValue.Margin = new Padding(4, 0, 4, 0);
            lblUsernameValue.Name = "lblUsernameValue";
            lblUsernameValue.Size = new Size(0, 30);
            lblUsernameValue.TabIndex = 2;
            // 
            // lblRoleLabel
            // 
            lblRoleLabel.AutoSize = true;
            lblRoleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRoleLabel.Location = new Point(75, 200);
            lblRoleLabel.Margin = new Padding(4, 0, 4, 0);
            lblRoleLabel.Name = "lblRoleLabel";
            lblRoleLabel.Size = new Size(63, 30);
            lblRoleLabel.TabIndex = 3;
            lblRoleLabel.Text = "Role:";
            // 
            // lblRoleValue
            // 
            lblRoleValue.AutoSize = true;
            lblRoleValue.Font = new Font("Segoe UI", 11F);
            lblRoleValue.Location = new Point(75, 238);
            lblRoleValue.Margin = new Padding(4, 0, 4, 0);
            lblRoleValue.Name = "lblRoleValue";
            lblRoleValue.Size = new Size(0, 30);
            lblRoleValue.TabIndex = 4;
            // 
            // lblNameLabel
            // 
            lblNameLabel.AutoSize = true;
            lblNameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNameLabel.Location = new Point(75, 288);
            lblNameLabel.Margin = new Padding(4, 0, 4, 0);
            lblNameLabel.Name = "lblNameLabel";
            lblNameLabel.Size = new Size(80, 30);
            lblNameLabel.TabIndex = 5;
            lblNameLabel.Text = "Nama:";
            // 
            // lblNameValue
            // 
            lblNameValue.AutoSize = true;
            lblNameValue.Font = new Font("Segoe UI", 11F);
            lblNameValue.Location = new Point(75, 325);
            lblNameValue.Margin = new Padding(4, 0, 4, 0);
            lblNameValue.Name = "lblNameValue";
            lblNameValue.Size = new Size(0, 30);
            lblNameValue.TabIndex = 6;
            // 
            // lblNoTelpLabel
            // 
            lblNoTelpLabel.AutoSize = true;
            lblNoTelpLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNoTelpLabel.Location = new Point(75, 376);
            lblNoTelpLabel.Margin = new Padding(4, 0, 4, 0);
            lblNoTelpLabel.Name = "lblNoTelpLabel";
            lblNoTelpLabel.Size = new Size(104, 30);
            lblNoTelpLabel.TabIndex = 9;
            lblNoTelpLabel.Text = "No. Telp:";
            // 
            // lblNoTelpValue
            // 
            lblNoTelpValue.AutoSize = true;
            lblNoTelpValue.Font = new Font("Segoe UI", 11F);
            lblNoTelpValue.Location = new Point(75, 414);
            lblNoTelpValue.Margin = new Padding(4, 0, 4, 0);
            lblNoTelpValue.Name = "lblNoTelpValue";
            lblNoTelpValue.Size = new Size(0, 30);
            lblNoTelpValue.TabIndex = 10;
            // 
            // lblAlamatLabel
            // 
            lblAlamatLabel.AutoSize = true;
            lblAlamatLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAlamatLabel.Location = new Point(75, 464);
            lblAlamatLabel.Margin = new Padding(4, 0, 4, 0);
            lblAlamatLabel.Name = "lblAlamatLabel";
            lblAlamatLabel.Size = new Size(93, 30);
            lblAlamatLabel.TabIndex = 11;
            lblAlamatLabel.Text = "Alamat:";
            // 
            // lblAlamatValue
            // 
            lblAlamatValue.AutoSize = true;
            lblAlamatValue.Font = new Font("Segoe UI", 11F);
            lblAlamatValue.Location = new Point(75, 502);
            lblAlamatValue.Margin = new Padding(4, 0, 4, 0);
            lblAlamatValue.Name = "lblAlamatValue";
            lblAlamatValue.Size = new Size(0, 30);
            lblAlamatValue.TabIndex = 12;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(198, 40, 40);
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(210, 560);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(102, 39);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 236, 236);
            ClientSize = new Size(1000, 691);
            Controls.Add(panelCard);
            Margin = new Padding(4);
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
        private Button btnBack;
        private Label lblNoTelpLabel;
        private Label lblNoTelpValue;
        private Label lblAlamatLabel;
        private Label lblAlamatValue;
        private Button btnEdit;
    }
}
