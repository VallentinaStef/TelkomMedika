using TelkomMedika.Services;
using Tubes_KPL_Kelompok_1.src.Models;

namespace TelkomMedikaForm
{
    public partial class EditProfileForm : Form
    {
        public EditProfileForm()
        {
            InitializeComponent();
            string role = UserSession.Role;

            if (role == "Pasien")
            {
                var pasienSvc = new ProfileService<PasienProfile>();
                var resp = pasienSvc.GetProfile(UserSession.Username);
                if (resp.Status && resp.Data != null)
                {
                    txtName.Text = resp.Data.Name;
                    txtNoTelp.Text = resp.Data.NoTelp;
                    txtAlamat.Text = resp.Data.Alamat;
                }
                ShowPasienFields(true);
                ClientSize = new Size(350, 360);
                btnSave.Location = new Point(80, 300);
                btnCancel.Location = new Point(180, 300);
            }
            else if (role == "Admin")
            {
                var adminSvc = new ProfileService<AdminProfile>();
                var resp = adminSvc.GetProfile(UserSession.Username);
                if (resp.Status && resp.Data != null)
                {
                    txtName.Text = resp.Data.Name;
                    txtTelpKantor.Text = resp.Data.NoTelpKantor;
                }
                ShowPasienFields(false);
                ShowAdminFields(true);
                ClientSize = new Size(350, 270);
                btnSave.Location = new Point(80, 210);
                btnCancel.Location = new Point(180, 210);
            }
            else
            {
                txtName.Text = UserSession.Name;
                ShowPasienFields(false);
                ClientSize = new Size(350, 200);
                btnSave.Location = new Point(80, 140);
                btnCancel.Location = new Point(180, 140);
            }

            txtName.SelectAll();
        }

        private void ShowPasienFields(bool show)
        {
            lblNoTelpLabel.Visible = show;
            txtNoTelp.Visible = show;
            lblAlamatLabel.Visible = show;
            txtAlamat.Visible = show;
        }

        private void ShowAdminFields(bool show)
        {
            lblTelpKantorLabel.Visible = show;
            txtTelpKantor.Visible = show;
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
                        adminResp.Data.NoTelpKantor = txtTelpKantor.Text.Trim();
                        updated = new ProfileService<AdminProfile>().UpdateProfile(username, adminResp.Data).Status;
                    }
                    break;

                case "Pasien":
                    var pasienResp = new ProfileService<PasienProfile>().GetProfile(username);
                    if (pasienResp.Status && pasienResp.Data != null)
                    {
                        pasienResp.Data.Name = newName;
                        pasienResp.Data.NoTelp = txtNoTelp.Text.Trim();
                        pasienResp.Data.Alamat = txtAlamat.Text.Trim();
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
                MessageBox.Show("Profil berhasil disimpan.", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
