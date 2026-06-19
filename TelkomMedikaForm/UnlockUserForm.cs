using System.Data;
using TelkomMedika.Services;

namespace TelkomMedikaForm
{
    public partial class UnlockUserForm : Form
    {
        private DataTable _dtLocked;
        private System.Windows.Forms.Timer _refreshTimer;

        public UnlockUserForm()
        {
            InitializeComponent();
            _dtLocked = new DataTable();
            _dtLocked.Columns.Add("Username", typeof(string));
            _dtLocked.Columns.Add("Status", typeof(string));
            _dtLocked.Columns.Add("Sisa Waktu", typeof(string));
            dgvLockedUsers.DataSource = _dtLocked;
        }

        private void UnlockUserForm_Load(object sender, EventArgs e)
        {
            RefreshLockedList();

            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 1000;
            _refreshTimer.Tick += RefreshTimer_Tick;
            _refreshTimer.Start();
        }

        private void RefreshLockedList()
        {
            _dtLocked.Rows.Clear();
            var svc = AuthService.Instance;
            foreach (var user in svc.GetRegisteredUsers())
            {
                var rem = svc.GetRemainingLockTime(user);
                bool isLocked = rem.HasValue;
                string status = isLocked ? "Terkunci" : "Normal";
                string sisa = isLocked
                    ? $"{(int)rem.Value.TotalMinutes} menit {rem.Value.Seconds} detik"
                    : "\u2014";
                _dtLocked.Rows.Add(user, status, sisa);
            }

            dgvLockedUsers.ClearSelection();
            txtUsername.Clear();
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

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            var svc = AuthService.Instance;
            foreach (DataRow row in _dtLocked.Rows)
            {
                if (row["Status"].ToString() == "Terkunci")
                {
                    var rem = svc.GetRemainingLockTime((string)row["Username"]);
                    if (rem.HasValue)
                    {
                        row["Sisa Waktu"] = $"{(int)rem.Value.TotalMinutes} menit {rem.Value.Seconds} detik";
                    }
                    else
                    {
                        row["Status"] = "Normal";
                        row["Sisa Waktu"] = "\u2014";
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
            base.OnFormClosing(e);
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

            var svc = AuthService.Instance;
            if (!svc.IsUserRegistered(username))
            {
                MessageBox.Show($"User '{username}' tidak terdaftar dalam sistem.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!svc.GetRemainingLockTime(username).HasValue)
            {
                MessageBox.Show($"User '{username}' tidak sedang terkunci.",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Yakin ingin membuka kunci user '{username}'?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirm != DialogResult.Yes)
                return;

            svc.UnlockUser(username);
            MessageBox.Show($"User '{username}' telah di-unlock.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            var rows = _dtLocked.Select($"Username = '{username.Replace("'", "''")}'");
            foreach (var row in rows)
            {
                row["Status"] = "Normal";
                row["Sisa Waktu"] = "\u2014";
            }

            txtUsername.Clear();
        }
    }
}
