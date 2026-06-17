using TelkomMedika.Services;

namespace TelkomMedikaForm
{
    public partial class UnlockUserForm : Form
    {
        public UnlockUserForm()
        {
            InitializeComponent();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Masukkan username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AuthService.Instance.UnlockUser(username);
            MessageBox.Show($"User '{username}' telah di-unlock.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
