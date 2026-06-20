using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class MedicalRecordForm : Form
    {
        private readonly MedicalServices medicalServices;
        private List<MedicalRecord> currentRecords = new List<MedicalRecord>();

        public MedicalRecordForm()
        {
            InitializeComponent();

            medicalServices = new MedicalServices(new MedicalApiClient());
            SeedDemoData();
            LoadMedicalRecords(1);
        }

        private void SeedDemoData()
        {
            medicalServices.AddMedicalRecord(new MedicalRecord
            {
                PatientId = 1,
                PatientName = "Andi Pratama",
                DoctorName = "Dr. Budi",
                Complaint = "Demam, batuk, dan nyeri tenggorokan sejak 2 hari.",
                Diagnosis = "Infeksi saluran pernapasan atas ringan.",
                Medicine = "Paracetamol 500mg, vitamin C, dan istirahat cukup."
            });

            medicalServices.AddMedicalRecord(new MedicalRecord
            {
                PatientId = 1,
                PatientName = "Andi Pratama",
                DoctorName = "Dr. Sari",
                Complaint = "Kontrol setelah pengobatan demam.",
                Diagnosis = "Kondisi membaik, tidak ditemukan tanda infeksi lanjut.",
                Medicine = "Lanjutkan vitamin dan perbanyak cairan."
            });

            medicalServices.AddMedicalRecord(new MedicalRecord
            {
                PatientId = 2,
                PatientName = "Siti Rahma",
                DoctorName = "Dr. Andika",
                Complaint = "Pusing dan tekanan darah meningkat.",
                Diagnosis = "Hipertensi ringan perlu pemantauan berkala.",
                Medicine = "Amlodipine 5mg sesuai anjuran dokter."
            });
        }

        private void LoadMedicalRecords(int patientId)
        {
            var response = medicalServices.GetMedicalRecords(patientId);

            if (!response.Status)
            {
                currentRecords = new List<MedicalRecord>();
                dgvMedicalRecords.DataSource = null;
                ClearDetail();
                lblStatus.Text = response.Message;
                return;
            }

            currentRecords = response.Data;
            dgvMedicalRecords.DataSource = currentRecords
                .Select(record => new
                {
                    record.Id,
                    record.PatientId,
                    NamaPasien = record.PatientName,
                    Dokter = record.DoctorName,
                    TanggalRekam = record.RecordDate.ToString("dd MMM yyyy HH:mm"),
                    Diagnosis = record.Diagnosis
                })
                .ToList();

            if (currentRecords.Count > 0)
            {
                ShowDetail(currentRecords[0]);
            }
            else
            {
                ClearDetail();
            }

            lblStatus.Text = currentRecords.Count == 0
                ? "Belum ada rekam medis digital untuk pasien ini."
                : $"Menampilkan {currentRecords.Count} rekam medis digital.";
        }

        private void ShowDetail(MedicalRecord record)
        {
            lblDetailId.Text = record.Id.ToString();
            lblDetailPatient.Text = $"{record.PatientName} (ID {record.PatientId})";
            lblDetailDoctor.Text = record.DoctorName;
            lblDetailDate.Text = record.RecordDate.ToString("dd MMMM yyyy HH:mm");
            txtComplaint.Text = record.Complaint;
            txtDiagnosis.Text = record.Diagnosis;
            txtMedicine.Text = record.Medicine;
        }

        private void ClearDetail()
        {
            lblDetailId.Text = "-";
            lblDetailPatient.Text = "-";
            lblDetailDoctor.Text = "-";
            lblDetailDate.Text = "-";
            txtComplaint.Text = string.Empty;
            txtDiagnosis.Text = string.Empty;
            txtMedicine.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPatientId.Text, out int patientId) || patientId <= 0)
            {
                currentRecords = new List<MedicalRecord>();
                dgvMedicalRecords.DataSource = null;
                ClearDetail();
                lblStatus.Text = "Patient ID harus berupa angka lebih dari 0.";
                return;
            }

            LoadMedicalRecords(patientId);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPatientId.Text, out int patientId) && patientId > 0)
            {
                LoadMedicalRecords(patientId);
                return;
            }

            txtPatientId.Text = "1";
            LoadMedicalRecords(1);
        }

        private void dgvMedicalRecords_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMedicalRecords.CurrentRow == null || dgvMedicalRecords.CurrentRow.Index < 0)
            {
                return;
            }

            int selectedIndex = dgvMedicalRecords.CurrentRow.Index;
            if (selectedIndex < currentRecords.Count)
            {
                ShowDetail(currentRecords[selectedIndex]);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            Hide();
        }
    }
}
