using TelkomMedika.Services;
using Tubes_KPL_Kelompok_1.src.Models;

namespace TelkomMedikaForm
{
    public partial class EditProfileForm : Form
    {
        public EditProfileForm()
        {
            InitializeComponent();
            txtName.Text = UserSession.Name;
            txtName.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nama tidak boleh kosong.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = UserSession.Username;
            string newName = txtName.Text.Trim();
            string role = UserSession.Role;

            bool updated = false;

            switch (role)
            {
                case "Admin":
                    var adminResp = new ProfileService<AdminProfile>().GetProfile(username);
                    if (adminResp.Status && adminResp.Data != null)
                    {
                        adminResp.Data.Name = newName;
                        updated = new ProfileService<AdminProfile>().UpdateProfile(username, adminResp.Data).Status;
                    }
                    break;

                case "Dokter":
                    var dokterResp = new ProfileService<DokterProfile>().GetProfile(username);
                    if (dokterResp.Status && dokterResp.Data != null)
                    {
                        dokterResp.Data.Name = newName;
                        updated = new ProfileService<DokterProfile>().UpdateProfile(username, dokterResp.Data).Status;
                    }
                    break;

                case "Pasien":
                    var pasienResp = new ProfileService<PasienProfile>().GetProfile(username);
                    if (pasienResp.Status && pasienResp.Data != null)
                    {
                        pasienResp.Data.Name = newName;
                        updated = new ProfileService<PasienProfile>().UpdateProfile(username, pasienResp.Data).Status;
                    }
                    break;

                default:
                    updated = false;
                    break;
            }

            if (updated)
            {
                UserSession.Name = newName;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Gagal memperbarui profil.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
