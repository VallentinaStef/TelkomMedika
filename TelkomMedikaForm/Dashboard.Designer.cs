namespace TelkomMedikaForm
{
    partial class Dashboard
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
            panelSidebar = new Panel();
            panelContent = new Panel();
            lblWelcome = new Label();
            lblRoleDisplay = new Label();
            lblAppTitle = new Label();
            panelHeader = new Panel();
            panelContent.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.Teal;
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(220, 500);
            panelSidebar.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(lblWelcome);
            panelContent.Controls.Add(lblRoleDisplay);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(220, 60);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(580, 440);
            panelContent.TabIndex = 1;
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(20, 15);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(147, 32);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "Telkomedika";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.DarkSlateGray;
            panelHeader.Controls.Add(lblAppTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 60);
            panelHeader.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Teal;
            lblWelcome.Location = new Point(150, 160);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 37);
            lblWelcome.TabIndex = 0;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoleDisplay
            // 
            lblRoleDisplay.AutoSize = true;
            lblRoleDisplay.Font = new Font("Segoe UI", 12F);
            lblRoleDisplay.ForeColor = Color.DimGray;
            lblRoleDisplay.Location = new Point(150, 210);
            lblRoleDisplay.Name = "lblRoleDisplay";
            lblRoleDisplay.Size = new Size(0, 28);
            lblRoleDisplay.TabIndex = 1;
            lblRoleDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelkomMedika - Dashboard";
            FormClosed += Dashboard_FormClosed;
            Load += Dashboard_Load;
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelSidebar;
        private Panel panelContent;
        private Panel panelHeader;
        private Label lblAppTitle;
        private Label lblWelcome;
        private Label lblRoleDisplay;
    }
}
