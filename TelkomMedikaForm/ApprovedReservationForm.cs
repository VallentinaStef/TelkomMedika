using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class ApprovedReservationForm : Form
    {
        private readonly ReservationService _reservationService;
        private List<Reservation> _approvedReservations = new();

        public ApprovedReservationForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService(new ReservationApiClient());
            LoadDoctorFilter();
            LoadReservations();
        }

        private void LoadDoctorFilter()
        {
            cmbDokter.Items.Clear();
            cmbDokter.Items.Add("Semua");

            var doctors = _reservationService.GetDoctorSchedules()
                .Select(schedule => schedule.DoctorName)
                .Distinct()
                .OrderBy(name => name)
                .ToArray();

            cmbDokter.Items.AddRange(doctors);
            cmbDokter.SelectedIndex = 0;
        }

        private void LoadReservations()
        {
            string selectedDoctor = cmbDokter.SelectedItem?.ToString() ?? "Semua";
            _approvedReservations = _reservationService.GetReservations()
                .Where(reservation => reservation.Status == ReservationStatus.Approved.ToString())
                .Where(reservation => selectedDoctor == "Semua" || reservation.DoctorName == selectedDoctor)
                .ToList();

            dgvReservations.DataSource = _approvedReservations
                .Select(reservation => new
                {
                    reservation.BookingNumber,
                    Pasien = reservation.PatientName,
                    reservation.Poli,
                    Dokter = reservation.DoctorName,
                    Tanggal = reservation.AppointmentDate == DateTime.MinValue
                        ? reservation.Day
                        : reservation.AppointmentDate.ToString("dddd, dd MMMM yyyy"),
                    Jadwal = reservation.Time,
                    reservation.Keluhan,
                    Status = "Disetujui"
                })
                .ToList();
        }

        private void cmbDokter_SelectedIndexChanged(object? sender, EventArgs e)
        {
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
    }
}
