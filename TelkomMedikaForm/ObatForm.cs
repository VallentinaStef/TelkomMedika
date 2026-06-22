using Tubes_KPL_Kelompok_1.Modules;
using Tubes_KPL_Kelompok_1.Config;

namespace TelkomMedikaForm
{
    public partial class ObatForm : Form
    {
        private readonly ObatModule _module;
        private readonly BindingSource _bindingSource;

        public ObatForm()
        {
            InitializeComponent();
            _module = new ObatModule();
            _bindingSource = new BindingSource();
            MuatJadwal();
        }

        private void MuatJadwal()
        {
            _bindingSource.DataSource = _module.DaftarJadwal;
            dgvJadwal.DataSource = _bindingSource;
        }

        private void btnTambah_Click(object? sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string waktu = txtWaktu.Text.Trim();
            string dosis = txtDosis.Text.Trim();

            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(waktu) || string.IsNullOrEmpty(dosis))
            {
                MessageBox.Show("Semua field harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TimeSpan.TryParse(waktu, out _))
            {
                MessageBox.Show("Format waktu tidak valid! Gunakan HH:mm", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _module.TambahJadwal(nama, waktu, dosis);
            _bindingSource.ResetBindings(false);

            txtNama.Clear();
            txtWaktu.Clear();
            txtDosis.Clear();
            txtNama.Focus();
        }

        private void btnHapus_Click(object? sender, EventArgs e)
        {
            if (dgvJadwal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris yang akan dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = dgvJadwal.SelectedRows[0].Index;
            var obat = _module.DaftarJadwal[index];

            var confirm = MessageBox.Show($"Hapus \"{obat.Nama}\" dari jadwal?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _module.HapusJadwal(index);
                _bindingSource.ResetBindings(false);
            }
        }

        private void dgvJadwal_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvJadwal.Rows[e.RowIndex].Selected = true;
        }

        private void btnCekReminder_Click(object? sender, EventArgs e)
        {
            string jam = txtCekJam.Text.Trim();

            if (string.IsNullOrEmpty(jam))
            {
                MessageBox.Show("Masukkan jam terlebih dahulu!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hasil = _module.CekReminder(jam);
            rtbOutput.Text = string.Join("\n", hasil);
        }

        private void btnConfig_Click(object? sender, EventArgs e)
        {
            string current = AppConfig.ReminderMessage;

            using Form prompt = new Form
            {
                Width = 450,
                Height = 180,
                Text = "Konfigurasi Reminder",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label { Left = 15, Top = 20, Text = "Pesan pengingat:", Width = 400 };
            TextBox txt = new TextBox { Left = 15, Top = 50, Text = current, Width = 400 };
            Button ok = new Button { Left = 270, Top = 90, Text = "OK", Width = 70, DialogResult = DialogResult.OK };
            Button cancel = new Button { Left = 350, Top = 90, Text = "Batal", Width = 70, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(lbl);
            prompt.Controls.Add(txt);
            prompt.Controls.Add(ok);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = ok;
            prompt.CancelButton = cancel;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string input = txt.Text.Trim();
                if (!string.IsNullOrEmpty(input) && input != current)
                {
                    AppConfig.ReminderMessage = input;
                    MessageBox.Show("Pesan reminder berhasil diperbarui!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnKembali_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
