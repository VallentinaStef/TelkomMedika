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
            dtpTanggal.Value = DateTime.Today;
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
                .Where(reservation => !chkTanggal.Checked || reservation.AppointmentDate.Date == dtpTanggal.Value.Date)
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
                    Jam = reservation.AppointmentTime,
                    reservation.Keluhan,
                    Status = "Disetujui"
                })
                .ToList();

            btnSelesai.Enabled = _approvedReservations.Count > 0;
        }

        private void cmbDokter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadReservations();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadReservations();
        }

        private void FilterChanged(object? sender, EventArgs e)
        {
            LoadReservations();
        }

        private void btnHariIni_Click(object? sender, EventArgs e)
        {
            chkTanggal.Checked = true;
            dtpTanggal.Value = DateTime.Today;
            LoadReservations();
        }

        private void btnSelesai_Click(object? sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih reservasi terlebih dahulu.", "Reservasi Disetujui", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvReservations.SelectedRows[0].Index;
            if (index < 0 || index >= _approvedReservations.Count)
                return;

            string result = _reservationService.UpdateReservationStatus(_approvedReservations[index].Id, ReservationStatus.Completed);
            MessageBox.Show(result, "Reservasi Disetujui", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadReservations();
        }

        private void dgvReservations_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvReservations.Rows[e.RowIndex].Selected = true;
        }

        private void btnKembali_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
