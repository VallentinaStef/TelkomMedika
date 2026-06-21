using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class ReservationHistoryForm : Form
    {
        private readonly ReservationService _reservationService;
        private List<Reservation> _reservations = new();

        public ReservationHistoryForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService(new ReservationApiClient());
            LoadReservations();
        }

        private void LoadReservations()
        {
            string patientName = UserSession.Name ?? string.Empty;
            _reservations = _reservationService.GetReservations()
                .Where(reservation => (reservation.PatientUsername ?? string.Empty).Equals(UserSession.Username, StringComparison.OrdinalIgnoreCase)
                    || reservation.PatientName.Equals(patientName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            dgvReservations.DataSource = _reservations
                .Select(reservation => new
                {
                    reservation.BookingNumber,
                    reservation.Poli,
                    Dokter = reservation.DoctorName,
                    Tanggal = reservation.AppointmentDate == DateTime.MinValue
                        ? reservation.Day
                        : reservation.AppointmentDate.ToString("dddd, dd MMMM yyyy"),
                    Jadwal = reservation.Time,
                    Jam = reservation.AppointmentTime,
                    reservation.Keluhan,
                    Status = ToDisplayStatus(reservation.Status),
                    Alasan = reservation.RejectionReason
                })
                .ToList();

            btnDetail.Enabled = _reservations.Count > 0;
            btnBatal.Enabled = _reservations.Any(reservation => reservation.Status == ReservationStatus.Pending.ToString());
        }

        private void dgvReservations_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvReservations.Rows[e.RowIndex].Selected = true;
        }

        private void btnDetail_Click(object? sender, EventArgs e)
        {
            var reservation = GetSelectedReservation();
            if (reservation == null)
                return;

            MessageBox.Show(BuildReservationDetail(reservation), "Detail Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBatal_Click(object? sender, EventArgs e)
        {
            var reservation = GetSelectedReservation();
            if (reservation == null)
                return;

            if (reservation.Status != ReservationStatus.Pending.ToString())
            {
                MessageBox.Show("Hanya reservasi dengan status Pending yang bisa dibatalkan.", "Riwayat Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Batalkan reservasi ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            string result = _reservationService.CancelReservation(reservation.Id);
            MessageBox.Show(result, "Riwayat Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadReservations();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
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

        private Reservation? GetSelectedReservation()
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih reservasi terlebih dahulu.", "Riwayat Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            int index = dgvReservations.SelectedRows[0].Index;
            return index >= 0 && index < _reservations.Count ? _reservations[index] : null;
        }

        private static string BuildReservationDetail(Reservation reservation)
        {
            string reason = string.IsNullOrWhiteSpace(reservation.RejectionReason)
                ? "-"
                : reservation.RejectionReason;

            return $"Booking: {reservation.BookingNumber}\n" +
                $"Poli: {reservation.Poli}\n" +
                $"Dokter: {reservation.DoctorName}\n" +
                $"Tanggal: {(reservation.AppointmentDate == DateTime.MinValue ? reservation.Day : reservation.AppointmentDate.ToString("dddd, dd MMMM yyyy"))}\n" +
                $"Jadwal: {reservation.Time}\n" +
                $"Jam reservasi: {reservation.AppointmentTime}\n" +
                $"Keluhan: {reservation.Keluhan}\n" +
                $"Status: {ToDisplayStatus(reservation.Status)}\n" +
                $"Alasan penolakan: {reason}";
        }
    }
}
