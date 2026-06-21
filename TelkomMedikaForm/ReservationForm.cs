using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class ReservationForm : Form
    {
        private readonly ReservationService _reservationService;
        private List<DoctorSchedule> _doctorSchedules = new();

        public ReservationForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService(new ReservationApiClient());
            dtpTanggal.MinDate = DateTime.Today;
            dtpTanggal.Value = DateTime.Today;
            LoadSchedules();
            cmbPoli.SelectedIndex = 0;
        }

        private void LoadSchedules()
        {
            var operational = _reservationService.GetOperationalSchedules().FirstOrDefault();
            lblOperational.Text = operational == null
                ? "Operasional Telkomedika: Senin - Minggu, 24 Jam"
                : $"Operasional Telkomedika: {operational.Day}, {operational.OpenTime}";

            _doctorSchedules = _reservationService.GetDoctorSchedules();
        }

        private void cmbPoli_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string poli = cmbPoli.SelectedItem?.ToString() ?? string.Empty;
            var doctors = _doctorSchedules
                .Where(schedule => schedule.Poli.Equals(poli, StringComparison.OrdinalIgnoreCase))
                .Select(schedule => schedule.DoctorName)
                .Distinct()
                .ToArray();

            cmbDokter.Items.Clear();
            cmbJadwal.Items.Clear();
            cmbDokter.Items.AddRange(doctors);

            if (cmbDokter.Items.Count > 0)
                cmbDokter.SelectedIndex = 0;
        }

        private void cmbDokter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadDoctorSchedulesForSelectedDate();
        }

        private void dtpTanggal_ValueChanged(object? sender, EventArgs e)
        {
            LoadDoctorSchedulesForSelectedDate();
        }

        private void LoadDoctorSchedulesForSelectedDate()
        {
            string dokter = cmbDokter.SelectedItem?.ToString() ?? string.Empty;
            string selectedDay = GetIndonesianDayName(dtpTanggal.Value.DayOfWeek);
            var schedules = _doctorSchedules
                .Where(schedule => schedule.DoctorName == dokter && IsScheduleAvailableOnDay(schedule.Day, selectedDay))
                .Select(schedule => new ScheduleItem(schedule))
                .ToArray();

            cmbJadwal.Items.Clear();
            cmbJamReservasi.Items.Clear();
            cmbJadwal.Items.AddRange(schedules);

            if (cmbJadwal.Items.Count > 0)
                cmbJadwal.SelectedIndex = 0;
        }

        private void cmbJadwal_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadReservationHours();
        }

        private void LoadReservationHours()
        {
            cmbJamReservasi.Items.Clear();

            if (cmbJadwal.SelectedItem is not ScheduleItem scheduleItem)
                return;

            cmbJamReservasi.Items.AddRange(BuildHourlySlots(scheduleItem.Schedule.Time));

            if (cmbJamReservasi.Items.Count > 0)
                cmbJamReservasi.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            string poli = cmbPoli.SelectedItem?.ToString() ?? string.Empty;
            string dokter = cmbDokter.SelectedItem?.ToString() ?? string.Empty;
            var scheduleItem = cmbJadwal.SelectedItem as ScheduleItem;
            string jamReservasi = cmbJamReservasi.SelectedItem?.ToString() ?? string.Empty;
            string keluhan = txtKeluhan.Text.Trim();

            if (string.IsNullOrWhiteSpace(poli))
            {
                MessageBox.Show("Pilih poli terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(dokter) || scheduleItem == null)
            {
                MessageBox.Show("Dokter yang dipilih tidak memiliki jadwal praktik pada tanggal tersebut.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(jamReservasi))
            {
                MessageBox.Show("Pilih jam reservasi terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(keluhan))
            {
                MessageBox.Show("Keluhan harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var reservation = new Reservation
            {
                PatientName = string.IsNullOrWhiteSpace(UserSession.Name) ? "Pasien" : UserSession.Name,
                PatientId = UserSession.PatientId,
                PatientUsername = UserSession.Username,
                DoctorName = dokter,
                Poli = poli,
                Day = $"{dtpTanggal.Value:dddd, dd MMMM yyyy} ({scheduleItem.Schedule.Day})",
                AppointmentDate = dtpTanggal.Value.Date,
                Time = scheduleItem.Schedule.Time,
                AppointmentTime = jamReservasi,
                Keluhan = keluhan,
                Status = UserSession.Role == "Admin"
                    ? ReservationStatus.Approved.ToString()
                    : ReservationStatus.Pending.ToString()
            };

            string result = _reservationService.AddReservation(reservation);
            MessageBox.Show(result, "Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result.Contains("berhasil", StringComparison.OrdinalIgnoreCase))
            {
                string message = UserSession.Role == "Admin"
                    ? "Reservasi berhasil dibuat dan langsung disetujui."
                    : "Reservasi masuk dengan status Pending. Silakan cek Riwayat Reservasi untuk melihat persetujuan admin.";

                MessageBox.Show(message, "Reservasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnKembali_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private static bool IsScheduleAvailableOnDay(string scheduleDay, string selectedDay)
        {
            if (scheduleDay.Equals("Senin - Minggu", StringComparison.OrdinalIgnoreCase))
                return true;

            return scheduleDay
                .Replace("&", ",")
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Any(day => day.Equals(selectedDay, StringComparison.OrdinalIgnoreCase));
        }

        private static string GetIndonesianDayName(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Monday => "Senin",
                DayOfWeek.Tuesday => "Selasa",
                DayOfWeek.Wednesday => "Rabu",
                DayOfWeek.Thursday => "Kamis",
                DayOfWeek.Friday => "Jumat",
                DayOfWeek.Saturday => "Sabtu",
                _ => "Minggu"
            };
        }

        private static object[] BuildHourlySlots(string scheduleTime)
        {
            string cleanTime = scheduleTime.Replace("WIB", string.Empty, StringComparison.OrdinalIgnoreCase).Trim();
            string[] parts = cleanTime.Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (parts.Length != 2 || !TryParseHour(parts[0], out int startHour) || !TryParseHour(parts[1], out int endHour))
                return Array.Empty<object>();

            int totalHours = endHour > startHour ? endHour - startHour : 24 - startHour + endHour;
            if (totalHours == 0)
                totalHours = 24;

            return Enumerable.Range(0, totalHours)
                .Select(offset => $"{(startHour + offset) % 24:00}.00")
                .Cast<object>()
                .ToArray();
        }

        private static bool TryParseHour(string time, out int hour)
        {
            hour = 0;
            string hourText = time.Trim().Split('.', ':')[0];
            return int.TryParse(hourText, out hour) && hour >= 0 && hour <= 23;
        }

        private sealed class ScheduleItem
        {
            public ScheduleItem(DoctorSchedule schedule)
            {
                Schedule = schedule;
            }

            public DoctorSchedule Schedule { get; }

            public override string ToString()
            {
                return $"{Schedule.Day}: {Schedule.Time}";
            }
        }
    }
}
