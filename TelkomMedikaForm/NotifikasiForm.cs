using Tubes_KPL_Kelompok_1.Models;
using Tubes_KPL_Kelompok_1.Services;
using Tubes_KPL_Kelompok_1.src.Models;

namespace TelkomMedikaForm
{
    public partial class NotifikasiForm : Form
    {
        private readonly NotifikasiService _notifikasiService;
        private readonly string _currentUser;
        private readonly bool _isAdmin;

        public NotifikasiForm()
        {
            InitializeComponent();

            _currentUser = string.IsNullOrWhiteSpace(UserSession.Name) ? UserSession.Username : UserSession.Name;
            _isAdmin = UserSession.Role == "Admin";

            _notifikasiService = NotifikasiService.Instance;

            cmbTipe.Items.AddRange(new object[]
            {
                TipeNotifikasi.LayananJadwal,
                TipeNotifikasi.AntreanRealTime,
                TipeNotifikasi.Reminder
            });
            cmbTipe.SelectedIndex = 0;

            ToggleAksesSesuaiRole();
            MuatNotifikasi();
        }

        private void ToggleAksesSesuaiRole()
        {
            gbKirimNotifikasi.Visible = _isAdmin;
            btnTandaiBaca.Visible = !_isAdmin;

            if (!_isAdmin)
            {
                dgvNotifikasi.Location = new Point(dgvNotifikasi.Location.X, gbKirimNotifikasi.Location.Y);
                dgvNotifikasi.Size = new Size(dgvNotifikasi.Size.Width, dgvNotifikasi.Size.Height + gbKirimNotifikasi.Size.Height + 15);
            }
            else
            {
                btnKembali.Location = btnTandaiBaca.Location;
            }
        }

        private void MuatNotifikasi()
        {
            if (_isAdmin)
            {
                var hasilSemua = _notifikasiService.GetSemuaNotifikasi();
                var dataSemua = (hasilSemua.Data ?? new List<Notifikasi>())
                    .Select(n => new
                    {
                        n.Id,
                        n.UserId,
                        n.Judul,
                        n.Pesan,
                        Tipe = n.Tipe.ToString(),
                        Waktu = n.WaktuKirim.ToString("dd/MM/yyyy HH:mm"),
                        Status = n.SudahDibaca ? "Dibaca" : "Baru"
                    })
                    .ToList();

                dgvNotifikasi.DataSource = dataSemua;
                return;
            }

            var hasil = _notifikasiService.GetNotifikasi(_currentUser);
            var data = (hasil.Data ?? new List<Notifikasi>())
                .Select(n => new
                {
                    n.Id,
                    n.Judul,
                    n.Pesan,
                    Tipe = n.Tipe.ToString(),
                    Waktu = n.WaktuKirim.ToString("dd/MM/yyyy HH:mm"),
                    Status = n.SudahDibaca ? "Dibaca" : "Baru"
                })
                .ToList();

            dgvNotifikasi.DataSource = data;
        }

        private void btnKirimNotifikasi_Click(object? sender, EventArgs e)
        {
            string userTujuan = txtUserIdTujuan.Text.Trim();
            string judul = txtJudul.Text.Trim();
            string pesan = txtPesan.Text.Trim();

            if (string.IsNullOrEmpty(userTujuan) || string.IsNullOrEmpty(judul) || string.IsNullOrEmpty(pesan))
            {
                MessageBox.Show("User tujuan, judul, dan pesan harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tipe = (TipeNotifikasi)cmbTipe.SelectedItem!;
            var hasil = _notifikasiService.KirimNotifikasi(userTujuan, judul, pesan, tipe);

            if (!hasil.Status)
            {
                MessageBox.Show(hasil.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtUserIdTujuan.Clear();
            txtJudul.Clear();
            txtPesan.Clear();
            txtUserIdTujuan.Focus();
            MuatNotifikasi();
        }

        private void btnRefreshNotifikasi_Click(object? sender, EventArgs e)
        {
            MuatNotifikasi();
        }

        private void btnTandaiBaca_Click(object? sender, EventArgs e)
        {
            if (dgvNotifikasi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih notifikasi yang akan ditandai dibaca.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvNotifikasi.SelectedRows[0].Cells["Id"].Value);
            var hasil = _notifikasiService.TandaiBaca(id);

            if (!hasil.Status)
                MessageBox.Show(hasil.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);

            MuatNotifikasi();
        }

        private void btnKembali_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}