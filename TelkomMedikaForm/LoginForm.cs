using TelkomMedika.Services;

namespace TelkomMedikaForm
{
    public partial class LoginForm : Form
    {
        private AuthService authService;

        public LoginForm()
        {
            InitializeComponent();
            authService = TelkomMedika.Services.AuthService.Instance;
            AcceptButton = btnLogin;
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
