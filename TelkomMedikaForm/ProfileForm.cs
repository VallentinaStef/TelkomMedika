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
                        lblTelpKantorValue.Text = adminResp.Data.NoTelpKantor;
                    }
                    ShowExtraFields(showNoTelp: false, showAlamat: false, showTelpKantor: true);
                    break;

                case "Pasien":
                    var pasienSvc = new ProfileService<PasienProfile>();
                    var pasienResp = pasienSvc.GetProfile(username);
                    if (pasienResp.Status && pasienResp.Data != null)
                    {
                        lblUsernameValue.Text = pasienResp.Data.Username;
                        lblRoleValue.Text = pasienResp.Data.Role;
                        lblNameValue.Text = pasienResp.Data.Name;
                        lblNoTelpValue.Text = pasienResp.Data.NoTelp;
                        lblAlamatValue.Text = pasienResp.Data.Alamat;
                    }
                    ShowExtraFields(showNoTelp: true, showAlamat: true, showTelpKantor: false);
                    break;

                default:
                    lblUsernameValue.Text = username;
                    lblRoleValue.Text = role;
                    lblNameValue.Text = UserSession.Name;
                    ShowExtraFields(showNoTelp: false, showAlamat: false, showTelpKantor: false);
                    break;
            }

            lblUsernameValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
            lblRoleValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
            lblNameValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
            lblNoTelpValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
            lblAlamatValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
            lblTelpKantorValue.ForeColor = Color.FromArgb(0x33, 0x33, 0x33);
        }

        private void ShowExtraFields(bool showNoTelp, bool showAlamat, bool showTelpKantor)
        {
            lblNoTelpLabel.Visible = showNoTelp;
            lblNoTelpValue.Visible = showNoTelp;
            lblAlamatLabel.Visible = showAlamat;
            lblAlamatValue.Visible = showAlamat;
            lblTelpKantorLabel.Visible = showTelpKantor;
            lblTelpKantorValue.Visible = showTelpKantor;

            if (showAlamat)
            {
                btnEdit.Location = new Point(210, 560);
                panelCard.Height = 610;
            }
            else if (showTelpKantor)
            {
                btnEdit.Location = new Point(210, 480);
                panelCard.Height = 550;
            }
            else
            {
                btnEdit.Location = new Point(210, 390);
                panelCard.Height = 440;
            }
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
