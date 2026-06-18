namespace TelkomMedikaForm
{
    partial class UnlockUserForm
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
            this.lblDaftar = new System.Windows.Forms.Label();
            this.dgvLockedUsers = new System.Windows.Forms.DataGridView();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnUnlock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLockedUsers)).BeginInit();
            this.SuspendLayout();
            //
            // lblDaftar
            //
            this.lblDaftar.AutoSize = true;
            this.lblDaftar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDaftar.Location = new System.Drawing.Point(12, 12);
            this.lblDaftar.Name = "lblDaftar";
            this.lblDaftar.Size = new System.Drawing.Size(156, 20);
            this.lblDaftar.TabIndex = 0;
            this.lblDaftar.Text = "Daftar User Terkunci:";
            //
            // dgvLockedUsers
            //
            this.dgvLockedUsers.AllowUserToAddRows = false;
            this.dgvLockedUsers.AllowUserToDeleteRows = false;
            this.dgvLockedUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLockedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLockedUsers.Location = new System.Drawing.Point(12, 38);
            this.dgvLockedUsers.MultiSelect = false;
            this.dgvLockedUsers.Name = "dgvLockedUsers";
            this.dgvLockedUsers.ReadOnly = true;
            this.dgvLockedUsers.RowHeadersVisible = false;
            this.dgvLockedUsers.RowHeadersWidth = 51;
            this.dgvLockedUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLockedUsers.Size = new System.Drawing.Size(376, 150);
            this.dgvLockedUsers.TabIndex = 1;
            this.dgvLockedUsers.SelectionChanged += new System.EventHandler(this.dgvLockedUsers_SelectionChanged);
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 201);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(116, 20);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username manual:";
            //
            // txtUsername
            //
            this.txtUsername.Location = new System.Drawing.Point(12, 224);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(290, 27);
            this.txtUsername.TabIndex = 3;
            //
            // btnUnlock
            //
            this.btnUnlock.BackColor = System.Drawing.Color.FromArgb(0xC6, 0x28, 0x28);
            this.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlock.FlatAppearance.BorderSize = 0;
            this.btnUnlock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUnlock.ForeColor = System.Drawing.Color.White;
            this.btnUnlock.Location = new System.Drawing.Point(313, 224);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(75, 27);
            this.btnUnlock.TabIndex = 4;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            //
            // UnlockUserForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 263);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.dgvLockedUsers);
            this.Controls.Add(this.lblDaftar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnlockUserForm";
            this.Text = "Unlock User";
            this.Load += new System.EventHandler(this.UnlockUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLockedUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblDaftar;
        private System.Windows.Forms.DataGridView dgvLockedUsers;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnUnlock;
    }
}
