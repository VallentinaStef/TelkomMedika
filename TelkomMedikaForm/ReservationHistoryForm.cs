using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class ReservationHistoryForm : Form
    {
        private readonly ReservationService _reservationService;

        public ReservationHistoryForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService(new ReservationApiClient());
            LoadReservations();
        }

        private void LoadReservations()
        {
            string patientName = UserSession.Name ?? string.Empty;
            dgvReservations.DataSource = _reservationService.GetReservations()
                .Where(reservation => (reservation.PatientUsername ?? string.Empty).Equals(UserSession.Username, StringComparison.OrdinalIgnoreCase)
                    || reservation.PatientName.Equals(patientName, StringComparison.OrdinalIgnoreCase))
                .Select(reservation => new
                {
                    reservation.BookingNumber,
                    reservation.Poli,
                    Dokter = reservation.DoctorName,
                    Tanggal = reservation.AppointmentDate == DateTime.MinValue
                        ? reservation.Day
                        : reservation.AppointmentDate.ToString("dddd, dd MMMM yyyy"),
                    Jadwal = reservation.Time,
                    reservation.Keluhan,
                    Status = ToDisplayStatus(reservation.Status)
                })
                .ToList();
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
                _ => "Pending"
            };
        }
    }
}
