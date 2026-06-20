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
            string username = UserSession.Username;
            string role = UserSession.Role;

            switch (role)
            {
                case "Admin":
                    var adminSvc = new ProfileService<AdminProfile>();
                    var adminResp = adminSvc.GetProfile(username);
                    if (adminResp.Status && adminResp.Data != null)
                    {
                        lblUsernameValue.Text = adminResp.Data.Username;
                        lblRoleValue.Text = adminResp.Data.Role;
                        lblNameValue.Text = adminResp.Data.Name;
                    }
                    break;

                case "Dokter":
                    var dokterSvc = new ProfileService<DokterProfile>();
                    var dokterResp = dokterSvc.GetProfile(username);
                    if (dokterResp.Status && dokterResp.Data != null)
                    {
                        lblUsernameValue.Text = dokterResp.Data.Username;
                        lblRoleValue.Text = dokterResp.Data.Role;
                        lblNameValue.Text = dokterResp.Data.Name;
                    }
                    break;

                case "Pasien":
                    var pasienSvc = new ProfileService<PasienProfile>();
                    var pasienResp = pasienSvc.GetProfile(username);
                    if (pasienResp.Status && pasienResp.Data != null)
                    {
                        lblUsernameValue.Text = pasienResp.Data.Username;
                        lblRoleValue.Text = pasienResp.Data.Role;
                        lblNameValue.Text = pasienResp.Data.Name;
                    }
                    break;

                default:
                    lblUsernameValue.Text = username;
                    lblRoleValue.Text = role;
                    lblNameValue.Text = UserSession.Name;
                    break;
            }

            lblUsernameValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
            lblRoleValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
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
