using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class MedicalHistoryForm : Form
    {
        private readonly MedicalServices medicalServices;

        public MedicalHistoryForm()
        {
            InitializeComponent();

            medicalServices = new MedicalServices(new MedicalApiClient());
            SeedDemoData();
            LoadHistory(1);
        }

        private void SeedDemoData()
        {
            medicalServices.AddMedicalHistory(new MedicalHistory
            {
                PatientId = 1,
                ServiceName = "Konsultasi Umum",
                DoctorName = "Dr. Budi",
                Description = "Pemeriksaan keluhan demam dan batuk."
            });

            medicalServices.AddMedicalHistory(new MedicalHistory
            {
                PatientId = 1,
                ServiceName = "Pemeriksaan Laboratorium",
                DoctorName = "Dr. Sari",
                Description = "Cek darah lengkap dan evaluasi hasil lab."
            });

            medicalServices.AddMedicalHistory(new MedicalHistory
            {
                PatientId = 2,
                ServiceName = "Kontrol Kesehatan",
                DoctorName = "Dr. Andika",
                Description = "Kontrol tekanan darah dan konsultasi obat."
            });
        }

        private void LoadHistory(int patientId)
        {
            var response = medicalServices.GetHistory(patientId);

            if (!response.Status)
            {
                lblStatus.Text = response.Message;
                dgvMedicalHistory.DataSource = null;
                return;
            }

            dgvMedicalHistory.DataSource = response.Data
                .Select(history => new
                {
                    history.Id,
                    history.PatientId,
                    NamaLayanan = history.ServiceName,
                    Dokter = history.DoctorName,
                    TanggalLayanan = history.ServiceDate.ToString("dd MMM yyyy HH:mm"),
                    Deskripsi = history.Description
                })
                .ToList();

            lblStatus.Text = response.Data.Count == 0
                ? "Belum ada riwayat layanan untuk pasien ini."
                : $"Menampilkan {response.Data.Count} riwayat layanan.";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPatientId.Text, out int patientId) || patientId <= 0)
            {
                lblStatus.Text = "Patient ID harus berupa angka lebih dari 0.";
                dgvMedicalHistory.DataSource = null;
                return;
            }

            LoadHistory(patientId);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPatientId.Text, out int patientId) && patientId > 0)
            {
                LoadHistory(patientId);
                return;
            }

            txtPatientId.Text = "1";
            LoadHistory(1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            Hide();
        }
    }
}
