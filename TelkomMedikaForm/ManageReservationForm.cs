using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class ManageReservationForm : Form
    {
        private readonly ReservationService _reservationService;
        private List<Reservation> _reservations = new();

        public ManageReservationForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService(new ReservationApiClient());
            cmbStatus.Items.AddRange(new object[] { "Pending", "Disetujui", "Ditolak" });
            cmbStatus.SelectedIndex = 0;
            cmbFilterStatus.Items.AddRange(new object[] { "Semua", "Pending", "Disetujui", "Ditolak" });
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterPoli.Items.AddRange(new object[] { "Semua", "umum", "gigi" });
            cmbFilterPoli.SelectedIndex = 0;
            cmbFilterDokter.Items.Add("Semua");
            cmbFilterDokter.Items.AddRange(_reservationService.GetDoctorSchedules()
                .Select(schedule => schedule.DoctorName)
                .Distinct()
                .OrderBy(name => name)
                .ToArray());
            cmbFilterDokter.SelectedIndex = 0;
            dtpFilterTanggal.Value = DateTime.Today;
            LoadReservations();
        }

        private void LoadReservations()
        {
            _reservations = ApplyFilters(_reservationService.GetReservations());
            dgvReservations.DataSource = _reservations
                .Select(reservation => new
                {
                    reservation.Id,
                    reservation.BookingNumber,
                    Pasien = reservation.PatientName,
                    reservation.Poli,
                    Dokter = reservation.DoctorName,
                    Tanggal = reservation.AppointmentDate == DateTime.MinValue
                        ? reservation.Day
                        : reservation.AppointmentDate.ToString("dddd, dd MMMM yyyy"),
                    Jadwal = reservation.Time,
                    Jam = reservation.AppointmentTime,
                    reservation.Keluhan,
                    Status = ToDisplayStatus(reservation.Status),
                    KuotaTersisa = GetRemainingQuota(reservation),
                    Alasan = reservation.RejectionReason
                })
                .ToList();

            btnUpdate.Enabled = _reservations.Count > 0;
            btnDetail.Enabled = _reservations.Count > 0;
            btnExport.Enabled = _reservations.Count > 0;
        }

        private void dgvReservations_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _reservations.Count)
                return;

            dgvReservations.Rows[e.RowIndex].Selected = true;
            string status = ToDisplayStatus(_reservations[e.RowIndex].Status);
            cmbStatus.SelectedItem = cmbStatus.Items.Contains(status) ? status : "Pending";
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih reservasi terlebih dahulu.", "Kelola Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvReservations.SelectedRows[0].Index;
            if (index < 0 || index >= _reservations.Count)
                return;

            string selectedStatus = cmbStatus.SelectedItem?.ToString() ?? "Pending";
            var status = ToReservationStatus(selectedStatus);
            string reason = string.Empty;

            if (status == ReservationStatus.Rejected)
            {
                reason = PromptRejectionReason();
                if (string.IsNullOrWhiteSpace(reason))
                    return;
            }

            string result = _reservationService.UpdateReservationStatus(_reservations[index].Id, status, reason);

            MessageBox.Show(result, "Kelola Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadReservations();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadReservations();
        }

        private void btnDetail_Click(object? sender, EventArgs e)
        {
            var reservation = GetSelectedReservation();
            if (reservation == null)
                return;

            MessageBox.Show(BuildReservationDetail(reservation), "Detail Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExport_Click(object? sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = "reservasi.csv"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var lines = new List<string>
            {
                "Booking,Pasien,Poli,Dokter,Tanggal,Jadwal,JamReservasi,Keluhan,Status,Alasan"
            };

            lines.AddRange(_reservations.Select(reservation => string.Join(",", new[]
            {
                EscapeCsv(reservation.BookingNumber),
                EscapeCsv(reservation.PatientName),
                EscapeCsv(reservation.Poli),
                EscapeCsv(reservation.DoctorName),
                EscapeCsv(reservation.AppointmentDate == DateTime.MinValue ? reservation.Day : reservation.AppointmentDate.ToString("yyyy-MM-dd")),
                EscapeCsv(reservation.Time),
                EscapeCsv(reservation.AppointmentTime),
                EscapeCsv(reservation.Keluhan),
                EscapeCsv(ToDisplayStatus(reservation.Status)),
                EscapeCsv(reservation.RejectionReason)
            })));

            File.WriteAllLines(dialog.FileName, lines);
            MessageBox.Show("Data reservasi berhasil diexport.", "Kelola Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FilterChanged(object? sender, EventArgs e)
        {
            LoadReservations();
        }

        private void btnKembali_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private static string ToDisplayStatus(string status)
        {
            return status switch
            {
                "Approved" => "Disetujui",
                "Rejected" => "Ditolak",
                "Completed" => "Selesai",
                "Cancelled" => "Dibatalkan",
                _ => "Pending"
            };
        }

        private static ReservationStatus ToReservationStatus(string status)
        {
            return status switch
            {
                "Disetujui" => ReservationStatus.Approved,
                "Ditolak" => ReservationStatus.Rejected,
                _ => ReservationStatus.Pending
            };
        }

        private List<Reservation> ApplyFilters(List<Reservation> reservations)
        {
            string statusFilter = cmbFilterStatus.SelectedItem?.ToString() ?? "Semua";
            string poliFilter = cmbFilterPoli.SelectedItem?.ToString() ?? "Semua";
            string dokterFilter = cmbFilterDokter.SelectedItem?.ToString() ?? "Semua";

            return reservations
                .Where(reservation => statusFilter == "Semua" || ToDisplayStatus(reservation.Status) == statusFilter)
                .Where(reservation => poliFilter == "Semua" || reservation.Poli.Equals(poliFilter, StringComparison.OrdinalIgnoreCase))
                .Where(reservation => dokterFilter == "Semua" || reservation.DoctorName == dokterFilter)
                .Where(reservation => !chkFilterTanggal.Checked || reservation.AppointmentDate.Date == dtpFilterTanggal.Value.Date)
                .ToList();
        }

        private Reservation? GetSelectedReservation()
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih reservasi terlebih dahulu.", "Kelola Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            int index = dgvReservations.SelectedRows[0].Index;
            return index >= 0 && index < _reservations.Count ? _reservations[index] : null;
        }

        private int GetRemainingQuota(Reservation reservation)
        {
            var schedule = _reservationService.GetDoctorSchedules().FirstOrDefault(schedule =>
                schedule.DoctorName == reservation.DoctorName && schedule.Time == reservation.Time);

            if (schedule == null)
                return 0;

            int used = _reservationService.GetReservations().Count(existing =>
                existing.DoctorName == reservation.DoctorName &&
                existing.AppointmentDate.Date == reservation.AppointmentDate.Date &&
                existing.Time == reservation.Time &&
                existing.AppointmentTime == reservation.AppointmentTime &&
                existing.Status != ReservationStatus.Rejected.ToString() &&
                existing.Status != ReservationStatus.Cancelled.ToString());

            return Math.Max(0, schedule.AvailableQuota - used);
        }

        private static string PromptRejectionReason()
        {
            using Form prompt = new Form
            {
                Width = 450,
                Height = 210,
                Text = "Alasan Penolakan",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label { Left = 15, Top = 15, Text = "Masukkan alasan penolakan:", Width = 400 };
            TextBox txt = new TextBox { Left = 15, Top = 45, Width = 400, Height = 60, Multiline = true };
            Button ok = new Button { Left = 255, Top = 120, Text = "OK", Width = 75, DialogResult = DialogResult.OK };
            Button cancel = new Button { Left = 340, Top = 120, Text = "Batal", Width = 75, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(lbl);
            prompt.Controls.Add(txt);
            prompt.Controls.Add(ok);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = ok;
            prompt.CancelButton = cancel;

            if (prompt.ShowDialog() != DialogResult.OK)
                return string.Empty;

            string reason = txt.Text.Trim();
            if (string.IsNullOrWhiteSpace(reason))
                MessageBox.Show("Alasan penolakan wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return reason;
        }

        private static string BuildReservationDetail(Reservation reservation)
        {
            string reason = string.IsNullOrWhiteSpace(reservation.RejectionReason) ? "-" : reservation.RejectionReason;
            return $"Booking: {reservation.BookingNumber}\n" +
                $"Pasien: {reservation.PatientName}\n" +
                $"Poli: {reservation.Poli}\n" +
                $"Dokter: {reservation.DoctorName}\n" +
                $"Tanggal: {(reservation.AppointmentDate == DateTime.MinValue ? reservation.Day : reservation.AppointmentDate.ToString("dddd, dd MMMM yyyy"))}\n" +
                $"Jadwal: {reservation.Time}\n" +
                $"Jam reservasi: {reservation.AppointmentTime}\n" +
                $"Keluhan: {reservation.Keluhan}\n" +
                $"Status: {ToDisplayStatus(reservation.Status)}\n" +
                $"Alasan penolakan: {reason}";
        }

        private static string EscapeCsv(string? value)
        {
            string safeValue = value ?? string.Empty;
            return $"\"{safeValue.Replace("\"", "\"\"")}\"";
        }
    }
}
