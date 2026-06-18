using System.Data;
using TelkomMedika.Services;

namespace TelkomMedikaForm
{
    public partial class UnlockUserForm : Form
    {
        private DataTable _dtLocked;

        public UnlockUserForm()
        {
            InitializeComponent();
            _dtLocked = new DataTable();
            _dtLocked.Columns.Add("Username", typeof(string));
            _dtLocked.Columns.Add("Sisa Waktu", typeof(string));
            dgvLockedUsers.DataSource = _dtLocked;
        }

        private void UnlockUserForm_Load(object sender, EventArgs e)
        {
            RefreshLockedList();
        }

        private void RefreshLockedList()
        {
            _dtLocked.Rows.Clear();
            var svc = AuthService.Instance;
            foreach (var user in svc.GetLockedUsers())
            {
                var rem = svc.GetRemainingLockTime(user);
                string sisa = rem.HasValue
                    ? $"{(int)rem.Value.TotalMinutes} menit {rem.Value.Seconds} detik"
                    : "\u2014";
                _dtLocked.Rows.Add(user, sisa);
            }
        }

        private void dgvLockedUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLockedUsers.SelectedRows.Count > 0)
            {
                var row = dgvLockedUsers.SelectedRows[0];
                if (row.Cells["Username"].Value is string user)
                    txtUsername.Text = user;
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Pilih user dari daftar atau masukkan username manual.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool removed = AuthService.Instance.UnlockUser(username);
            if (removed)
            {
                MessageBox.Show($"User '{username}' telah di-unlock.", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                var rowsToDelete = _dtLocked.Select($"Username = '{username.Replace("'", "''")}'");
                foreach (var row in rowsToDelete)
                    _dtLocked.Rows.Remove(row);

                txtUsername.Clear();
            }
            else
            {
                MessageBox.Show($"User '{username}' tidak ditemukan atau tidak sedang terkunci.",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
