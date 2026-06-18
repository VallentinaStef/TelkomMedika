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
            lblUsernameValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
            lblRoleValue.Text = UserSession.Role;
            lblRoleValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
            lblNameValue.Text = UserSession.Name;
            lblNameValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using var editForm = new EditProfileForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserProfile();
            }
        }
    }
}
