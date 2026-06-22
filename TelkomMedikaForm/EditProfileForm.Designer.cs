namespace TelkomMedikaForm
{
    partial class EditProfileForm
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
            lblLabel = new Label();
            txtName = new TextBox();
            lblNoTelpLabel = new Label();
            txtNoTelp = new TextBox();
            lblAlamatLabel = new Label();
            txtAlamat = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // lblLabel
            //
            lblLabel.AutoSize = true;
            lblLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLabel.Location = new Point(20, 20);
            lblLabel.Name = "lblLabel";
            lblLabel.Size = new Size(80, 30);
            lblLabel.TabIndex = 0;
            lblLabel.Text = "Nama:";
            //
            // txtName
            //
            txtName.Font = new Font("Segoe UI", 11F);
            txtName.Location = new Point(20, 55);
            txtName.Name = "txtName";
            txtName.Size = new Size(310, 37);
            txtName.TabIndex = 1;
            //
            // lblNoTelpLabel
            //
            // txtNoTelp
            //
            txtNoTelp.TabIndex = 3;
            //
            // lblAlamatLabel
            //
            // txtAlamat
            //
            txtAlamat.TabIndex = 5;
            //
            // 
            // lblNoTelpLabel
            // 
            lblNoTelpLabel.AutoSize = true;
            lblNoTelpLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNoTelpLabel.Location = new Point(20, 110);
            lblNoTelpLabel.Name = "lblNoTelpLabel";
            lblNoTelpLabel.Size = new Size(81, 30);
            lblNoTelpLabel.TabIndex = 2;
            lblNoTelpLabel.Text = "No. Telp:";
            // 
            // txtNoTelp
            // 
            txtNoTelp.Font = new Font("Segoe UI", 11F);
            txtNoTelp.Location = new Point(20, 145);
            txtNoTelp.Name = "txtNoTelp";
            txtNoTelp.Size = new Size(310, 37);
            txtNoTelp.TabIndex = 3;
            // 
            // lblAlamatLabel
            // 
            lblAlamatLabel.AutoSize = true;
            lblAlamatLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAlamatLabel.Location = new Point(20, 200);
            lblAlamatLabel.Name = "lblAlamatLabel";
            lblAlamatLabel.Size = new Size(82, 30);
            lblAlamatLabel.TabIndex = 4;
            lblAlamatLabel.Text = "Alamat:";
            // 
            // txtAlamat
            // 
            txtAlamat.Font = new Font("Segoe UI", 11F);
            txtAlamat.Location = new Point(20, 235);
            txtAlamat.Name = "txtAlamat";
            txtAlamat.Size = new Size(310, 37);
            txtAlamat.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(80, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 35);
            btnSave.TabIndex = 6;
            btnSave.Text = "Simpan";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            //
            // btnCancel
            //
            btnCancel.BackColor = Color.FromArgb(0x9E, 0x9E, 0x9E);
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(180, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 35);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Batal";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            //
            // EditProfileForm
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 360);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtAlamat);
            Controls.Add(lblAlamatLabel);
            Controls.Add(txtNoTelp);
            Controls.Add(lblNoTelpLabel);
            Controls.Add(txtName);
            Controls.Add(lblLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditProfileForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Profil";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblLabel;
        private TextBox txtName;
        private Label lblNoTelpLabel;
        private TextBox txtNoTelp;
        private Label lblAlamatLabel;
        private TextBox txtAlamat;
        private Button btnSave;
        private Button btnCancel;
    }
}
