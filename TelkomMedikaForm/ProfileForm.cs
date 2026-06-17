using TelkomMedika.Services;
using Tubes_KPL_Kelompok_1.src.Models;

namespace TelkomMedikaForm
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            lblUsernameValue.Text = UserSession.Username;
            lblRoleValue.Text = UserSession.Role;
            lblNameValue.Text = UserSession.Name;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fitur edit profil akan segera tersedia.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var authService = TelkomMedika.Services.AuthService.Instance;
            authService.Logout();

            this.Close();

            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
