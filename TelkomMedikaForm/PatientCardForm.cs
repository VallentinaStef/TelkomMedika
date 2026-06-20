using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class PatientCardForm : Form
    {
        private readonly MedicalServices medicalServices;

        public PatientCardForm()
        {
            InitializeComponent();

            medicalServices = new MedicalServices(new MedicalApiClient());
            SeedDemoData();
            LoadPatientCard(1);
        }

        private void SeedDemoData()
        {
            medicalServices.AddPatientCard(new PatientCard
            {
                PatientId = 1,
                PatientName = "Andi Pratama",
                Gender = "Laki-laki",
                BirthDate = new DateTime(1998, 5, 12),
                Address = "Jl. Merdeka No. 10, Bandung"
            });

            medicalServices.AddPatientCard(new PatientCard
            {
                PatientId = 2,
                PatientName = "Siti Rahma",
                Gender = "Perempuan",
                BirthDate = new DateTime(2000, 8, 24),
                Address = "Jl. Telekomunikasi No. 5, Bandung"
            });
        }

        private void LoadPatientCard(int patientId)
        {
            var response = medicalServices.GetPatientCard(patientId);

            if (!response.Status || response.Data == null)
            {
                ClearCard();
                lblStatus.Text = response.Message;
                return;
            }

            PatientCard card = response.Data;
            lblCardPatientId.Text = card.PatientId.ToString();
            lblCardName.Text = card.PatientName;
            lblCardGender.Text = card.Gender;
            lblCardBirthDate.Text = card.BirthDate.ToString("dd MMMM yyyy");
            lblCardAddress.Text = card.Address;
            lblStatus.Text = "Kartu pasien digital berhasil ditampilkan.";
        }

        private void ClearCard()
        {
            lblCardPatientId.Text = "-";
            lblCardName.Text = "-";
            lblCardGender.Text = "-";
            lblCardBirthDate.Text = "-";
            lblCardAddress.Text = "-";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPatientId.Text, out int patientId) || patientId <= 0)
            {
                ClearCard();
                lblStatus.Text = "Patient ID harus berupa angka lebih dari 0.";
                return;
            }

            LoadPatientCard(patientId);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPatientId.Text, out int patientId) && patientId > 0)
            {
                LoadPatientCard(patientId);
                return;
            }

            txtPatientId.Text = "1";
            LoadPatientCard(1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            Hide();
        }
    }
}
