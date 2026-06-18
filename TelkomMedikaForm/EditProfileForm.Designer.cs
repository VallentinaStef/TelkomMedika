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
            // btnSave
            //
            btnSave.BackColor = Color.Teal;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(80, 110);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 35);
            btnSave.TabIndex = 2;
            btnSave.Text = "Simpan";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            //
            // btnCancel
            //
            btnCancel.BackColor = Color.Gray;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(180, 110);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 35);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Batal";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            //
            // EditProfileForm
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 160);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
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
        private Button btnSave;
        private Button btnCancel;
    }
}
