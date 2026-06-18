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

            UserSession.Name = txtName.Text.Trim();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
