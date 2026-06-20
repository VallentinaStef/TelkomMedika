using TelkomMedika.Services;

namespace TelkomMedikaForm
{
    public partial class LoginForm : Form
    {
        private AuthService authService;
        private System.Windows.Forms.Timer _lockTimer;

        public LoginForm()
        {
            InitializeComponent();
            authService = TelkomMedika.Services.AuthService.Instance;
            AcceptButton = btnLogin;

            _lockTimer = new System.Windows.Forms.Timer();
            _lockTimer.Interval = 1000;
            _lockTimer.Tick += LockTimer_Tick;
            _lockTimer.Start();
        }

        private void LockTimer_Tick(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                lblLockRemaining.Text = "";
                return;
            }
            var rem = authService.GetRemainingLockTime(username);
            if (rem.HasValue)
                lblLockRemaining.Text = $"Akun terkunci. Sisa: {(int)rem.Value.TotalMinutes} menit {rem.Value.Seconds} detik";
            else
                lblLockRemaining.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var result = authService.Login(username, password);

            lblStatus.ForeColor = result.Status ? Color.Green : Color.Red;
            lblStatus.Text = result.Message;

            if (result.Status)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
