using Tubes_KPL_Kelompok_1.Models;
using Tubes_KPL_Kelompok_1.Services;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Utils;

namespace TelkomMedikaForm
{
    public partial class KonsultasiForm : Form
    {
        private readonly NotifikasiService _notifikasiService;
        private readonly ReminderService _reminderService;
        private readonly KonsultasiService _konsultasiService;
        private readonly string _currentUser;

        public KonsultasiForm()
        {
            InitializeComponent();

            _currentUser = string.IsNullOrWhiteSpace(UserSession.Name) ? UserSession.Username : UserSession.Name;

            _notifikasiService = NotifikasiService.Instance;
            _reminderService = new ReminderService(_notifikasiService);
            _konsultasiService = new KonsultasiService(_notifikasiService, _reminderService);

            dtpWaktuKonsultasi.Value = DateTime.Now.AddMinutes(30);

            SetupAksesPerRole();
            MuatKonsultasi();
        }

        private void SetupAksesPerRole()
        {
            if (UserSession.Role != "Pasien")
                return;

            btnMulaiKonsultasi.Visible = false;
            btnSelesaikanKonsultasi.Visible = false;

            btnBatalkanKonsultasi.Location = btnMulaiKonsultasi.Location;
            btnKembali.Location = new Point(btnBatalkanKonsultasi.Left + btnBatalkanKonsultasi.Width + 18, btnKembali.Top);
        }

        private void MuatKonsultasi()
        {
            var hasil = _konsultasiService.GetDaftarKonsultasi();
            var data = (hasil.Data ?? new List<Konsultasi>())
                .Select(k => new
                {
                    k.Id,
                    k.NamaPasien,
                    k.NamaDokter,
                    k.Keluhan,
                    Waktu = k.WaktuMulai.ToString("dd/MM/yyyy HH:mm"),
                    Status = k.Status.ToString()
                })
                .ToList();

            dgvKonsultasi.DataSource = data;
        }

        private void btnBuatKonsultasi_Click(object? sender, EventArgs e)
        {
            string dokter = cmbDokter.SelectedItem?.ToString() ?? string.Empty;
            string keluhan = txtKeluhan.Text.Trim();

            if (string.IsNullOrEmpty(dokter) || string.IsNullOrEmpty(keluhan))
            {
                MessageBox.Show("Nama dokter dan keluhan harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hasil = _konsultasiService.BuatKonsultasi(_currentUser, dokter, keluhan, dtpWaktuKonsultasi.Value);

            if (!hasil.Status)
            {
                MessageBox.Show(hasil.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmbDokter.SelectedIndex = -1;
            txtKeluhan.Clear();
            cmbDokter.Focus();

            MuatKonsultasi();
        }

        private void btnRefreshKonsultasi_Click(object? sender, EventArgs e)
        {
            MuatKonsultasi();
        }

        private int? GetSelectedKonsultasiId()
        {
            if (dgvKonsultasi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih konsultasi terlebih dahulu.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return Convert.ToInt32(dgvKonsultasi.SelectedRows[0].Cells["Id"].Value);
        }

        private void TampilkanHasil(Response<Konsultasi> hasil)
        {
            if (!hasil.Status)
                MessageBox.Show(hasil.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);

            MuatKonsultasi();
        }

        private void btnMulaiKonsultasi_Click(object? sender, EventArgs e)
        {
            var id = GetSelectedKonsultasiId();
            if (id == null) return;
            TampilkanHasil(_konsultasiService.MulaiKonsultasi(id.Value));
        }

        private void btnSelesaikanKonsultasi_Click(object? sender, EventArgs e)
        {
            var id = GetSelectedKonsultasiId();
            if (id == null) return;

            using var dialog = new Form
            {
                Text = "Catatan Dokter",
                Size = new Size(400, 180),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            var txt = new TextBox { Location = new Point(15, 15), Size = new Size(355, 23) };
            var btnOk = new Button { Text = "OK", DialogResult = DialogResult.OK, Location = new Point(195, 90), Size = new Size(80, 30) };
            var btnCancel = new Button { Text = "Batal", DialogResult = DialogResult.Cancel, Location = new Point(285, 90), Size = new Size(80, 30) };
            dialog.Controls.Add(txt);
            dialog.Controls.Add(btnOk);
            dialog.Controls.Add(btnCancel);
            dialog.AcceptButton = btnOk;
            dialog.CancelButton = btnCancel;

            if (dialog.ShowDialog(this) != DialogResult.OK || string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show("Catatan dokter harus diisi untuk menyelesaikan konsultasi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TampilkanHasil(_konsultasiService.SelesaikanKonsultasi(id.Value, txt.Text.Trim()));
        }

        private void btnBatalkanKonsultasi_Click(object? sender, EventArgs e)
        {
            var id = GetSelectedKonsultasiId();
            if (id == null) return;
            TampilkanHasil(_konsultasiService.BatalkanKonsultasi(id.Value));
        }

        private void btnKembali_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}