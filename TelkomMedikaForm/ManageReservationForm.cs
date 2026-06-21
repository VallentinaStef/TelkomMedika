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
                    reservation.Keluhan,
                    Status = ToDisplayStatus(reservation.Status)
                })
                .ToList();

            btnUpdate.Enabled = _reservations.Count > 0;
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
            string result = _reservationService.UpdateReservationStatus(_reservations[index].Id, status);

            MessageBox.Show(result, "Kelola Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            return reservations
                .Where(reservation => statusFilter == "Semua" || ToDisplayStatus(reservation.Status) == statusFilter)
                .Where(reservation => poliFilter == "Semua" || reservation.Poli.Equals(poliFilter, StringComparison.OrdinalIgnoreCase))
                .Where(reservation => !chkFilterTanggal.Checked || reservation.AppointmentDate.Date == dtpFilterTanggal.Value.Date)
                .ToList();
        }
    }
}
