using TelkomMedika.Services;

namespace TelkomMedikaForm
{
    public partial class LoginForm : Form
    {
        private AuthService authService;

        public LoginForm()
        {
            InitializeComponent();
            authService = new AuthService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtusn.Text;
            string password = txtpw.Text;

            var result = authService.Login(username, password);

            MessageBox.Show(result.Message);

            if (result.Status)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();

                this.Hide();
            }
        }
    }
}