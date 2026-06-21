using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class DoctorScheduleForm : Form
    {
        private readonly ReservationService _reservationService;

        public DoctorScheduleForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService(new ReservationApiClient());
            LoadSchedules();
        }

        private void LoadSchedules()
        {
            var operational = _reservationService.GetOperationalSchedules().FirstOrDefault();
            lblOperational.Text = operational == null
                ? "Operasional Telkomedika: Senin - Minggu, 24 Jam"
                : $"Operasional Telkomedika: {operational.Day}, {operational.OpenTime}";

            dgvSchedules.DataSource = _reservationService.GetDoctorSchedules()
                .Select(schedule => new
                {
                    Poli = schedule.Poli,
                    Dokter = schedule.DoctorName,
                    Hari = schedule.Day,
                    Jam = schedule.Time,
                    Kuota = schedule.AvailableQuota
                })
                .ToList();
        }

        private void btnKembali_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
