using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class MedicalRecordForm : Form
    {
        private static bool demoDataSeeded;
        private readonly MedicalServices medicalServices;
        private List<MedicalRecord> currentRecords = new List<MedicalRecord>();
        private Panel pnlEditor = null!;
        private TextBox txtEditRecordId = null!;
        private TextBox txtEditPatientId = null!;
        private TextBox txtEditPatientName = null!;
        private TextBox txtEditDoctorName = null!;
        private TextBox txtEditComplaint = null!;
        private TextBox txtEditDiagnosis = null!;
        private TextBox txtEditMedicine = null!;
        private Button btnSaveRecord = null!;
        private Button btnDeleteRecord = null!;

        public MedicalRecordForm()
        {
            InitializeComponent();

            medicalServices = new MedicalServices(new MedicalApiClient());
            ConfigurePatientView();
            ConfigureEditor();
            SeedDemoData();
            if (IsAdminRole())
                LoadAllMedicalRecords();
            else
                LoadMedicalRecords(GetDefaultPatientId());
        }

        private void ConfigurePatientView()
        {
            if (!IsPatientRole())
                return;

            txtPatientId.Text = UserSession.PatientId.ToString();
            txtPatientId.Visible = false;
            btnSearch.Visible = false;
            lblPatientId.Text = $"Data pasien: {UserSession.Name} (ID {UserSession.PatientId})";
        }

        private void SeedDemoData()
        {
            if (demoDataSeeded)
                return;

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

            medicalServices.AddMedicalRecord(new MedicalRecord
            {
                PatientId = 3,
                PatientName = "Raka Wijaya",
                DoctorName = "Dr. Faizah",
                Complaint = "Nyeri ulu hati dan mual setelah makan pedas.",
                Diagnosis = "Gastritis ringan.",
                Medicine = "Antasida dan omeprazole sesuai anjuran dokter."
            });

            demoDataSeeded = true;
        }

        private void LoadAllMedicalRecords()
        {
            var response = medicalServices.GetAllMedicalRecords();
            if (!response.Status)
            {
                currentRecords = new List<MedicalRecord>();
                dgvMedicalRecords.DataSource = null;
                ClearDetail();
                lblStatus.Text = response.Message;
                return;
            }

            BindMedicalRecords(response.Data);
            lblStatus.Text = currentRecords.Count == 0
                ? "Belum ada rekam medis digital."
                : $"Menampilkan {currentRecords.Count} rekam medis digital.";
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

            BindMedicalRecords(response.Data);

            lblStatus.Text = currentRecords.Count == 0
                ? "Belum ada rekam medis digital untuk pasien ini."
                : $"Menampilkan {currentRecords.Count} rekam medis digital.";
        }

        private void BindMedicalRecords(List<MedicalRecord> records)
        {
            currentRecords = records;
            dgvMedicalRecords.DataSource = currentRecords
                .Select(record => new
                {
                    record.Id,
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
            FillEditor(record);
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
            ClearEditor();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsPatientRole())
            {
                LoadMedicalRecords(UserSession.PatientId);
                return;
            }

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
            if (IsPatientRole())
            {
                LoadMedicalRecords(UserSession.PatientId);
                return;
            }

            if (int.TryParse(txtPatientId.Text, out int patientId) && patientId > 0)
            {
                LoadMedicalRecords(patientId);
                return;
            }

            if (IsAdminRole() && string.IsNullOrWhiteSpace(txtPatientId.Text))
            {
                LoadAllMedicalRecords();
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

        private int GetDefaultPatientId()
        {
            return IsPatientRole() && UserSession.PatientId > 0 ? UserSession.PatientId : 1;
        }

        private static bool IsPatientRole()
        {
            return UserSession.Role.Equals("Pasien", StringComparison.OrdinalIgnoreCase);
        }

        private void ConfigureEditor()
        {
            if (!IsDoctorRole() && !IsAdminRole())
                return;

            ClientSize = new Size(ClientSize.Width, 920);
            MinimumSize = new Size(1020, 960);
            lblStatus.Location = new Point(24, 858);
            btnBack.Location = new Point(836, 852);

            pnlEditor = new Panel
            {
                BackColor = Color.White,
                Location = new Point(24, 690),
                Size = new Size(932, 150)
            };

            var lblEditorTitle = new Label
            {
                Text = IsDoctorRole() ? "Tambah Rekam Medis Pasien" : "Kelola Rekam Medis",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0xC6, 0x28, 0x28),
                Location = new Point(16, 10),
                AutoSize = true
            };

            AddFieldLabel(pnlEditor, "Record ID", 16, 42);
            txtEditRecordId = CreateTextBox(16, 66, 70, "ID");
            txtEditRecordId.ReadOnly = true;
            AddFieldLabel(pnlEditor, "Patient ID", 102, 42);
            txtEditPatientId = CreateTextBox(102, 66, 80, "Pasien");
            AddFieldLabel(pnlEditor, "Nama Pasien", 198, 42);
            txtEditPatientName = CreateTextBox(198, 66, 190, "Nama pasien");
            AddFieldLabel(pnlEditor, "Dokter", 404, 42);
            txtEditDoctorName = CreateTextBox(404, 66, 180, "Dokter");
            AddFieldLabel(pnlEditor, "Keluhan", 16, 100);
            txtEditComplaint = CreateTextBox(16, 124, 260, "Keluhan");
            AddFieldLabel(pnlEditor, "Diagnosis", 292, 100);
            txtEditDiagnosis = CreateTextBox(292, 124, 260, "Diagnosis");
            AddFieldLabel(pnlEditor, "Obat", 568, 100);
            txtEditMedicine = CreateTextBox(568, 124, 130, "Obat");

            if (IsDoctorRole())
            {
                txtEditDoctorName.Text = UserSession.Name;
                txtEditDoctorName.ReadOnly = true;
                txtEditRecordId.Clear();
            }

            btnSaveRecord = new Button
            {
                Text = IsDoctorRole() ? "Tambah" : "Tambah/Edit",
                BackColor = Color.FromArgb(0xC6, 0x28, 0x28),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(712, 122),
                Size = new Size(105, 32)
            };
            btnSaveRecord.Click += btnSaveRecord_Click;

            btnDeleteRecord = new Button
            {
                Text = "Hapus",
                BackColor = Color.FromArgb(192, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(827, 122),
                Size = new Size(80, 32),
                Visible = IsAdminRole()
            };
            btnDeleteRecord.Click += btnDeleteRecord_Click;

            pnlEditor.Controls.Add(lblEditorTitle);
            pnlEditor.Controls.Add(txtEditRecordId);
            pnlEditor.Controls.Add(txtEditPatientId);
            pnlEditor.Controls.Add(txtEditPatientName);
            pnlEditor.Controls.Add(txtEditDoctorName);
            pnlEditor.Controls.Add(txtEditComplaint);
            pnlEditor.Controls.Add(txtEditDiagnosis);
            pnlEditor.Controls.Add(txtEditMedicine);
            pnlEditor.Controls.Add(btnSaveRecord);
            pnlEditor.Controls.Add(btnDeleteRecord);
            Controls.Add(pnlEditor);
        }

        private static TextBox CreateTextBox(int x, int y, int width, string placeholder)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 30),
                PlaceholderText = placeholder
            };
        }

        private static void AddFieldLabel(Control parent, string text, int x, int y)
        {
            parent.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(90, 90, 90),
                Location = new Point(x, y),
                AutoSize = true
            });
        }

        private void FillEditor(MedicalRecord record)
        {
            if (pnlEditor == null || record == null)
                return;

            txtEditRecordId.Text = IsAdminRole() ? record.Id.ToString() : string.Empty;
            txtEditPatientId.Text = record.PatientId.ToString();
            txtEditPatientName.Text = record.PatientName;
            txtEditDoctorName.Text = IsDoctorRole() ? UserSession.Name : record.DoctorName;
            txtEditComplaint.Text = record.Complaint;
            txtEditDiagnosis.Text = record.Diagnosis;
            txtEditMedicine.Text = record.Medicine;
        }

        private void ClearEditor()
        {
            if (pnlEditor == null)
                return;

            txtEditRecordId.Clear();
            txtEditPatientId.Clear();
            txtEditPatientName.Clear();
            txtEditDoctorName.Text = IsDoctorRole() ? UserSession.Name : string.Empty;
            txtEditComplaint.Clear();
            txtEditDiagnosis.Clear();
            txtEditMedicine.Clear();
        }

        private void btnSaveRecord_Click(object? sender, EventArgs e)
        {
            if (!IsDoctorRole() && !IsAdminRole())
                return;

            if (!int.TryParse(txtEditPatientId.Text, out int patientId) || patientId <= 0)
            {
                lblStatus.Text = "Patient ID harus berupa angka lebih dari 0.";
                return;
            }

            var record = new MedicalRecord
            {
                PatientId = patientId,
                PatientName = txtEditPatientName.Text.Trim(),
                DoctorName = IsDoctorRole() ? UserSession.Name : txtEditDoctorName.Text.Trim(),
                Complaint = txtEditComplaint.Text.Trim(),
                Diagnosis = txtEditDiagnosis.Text.Trim(),
                Medicine = txtEditMedicine.Text.Trim(),
                RecordDate = DateTime.Now
            };

            var response = IsAdminRole() && int.TryParse(txtEditRecordId.Text, out int id) && id > 0
                ? medicalServices.UpdateMedicalRecord(id, record)
                : medicalServices.AddMedicalRecord(record);

            lblStatus.Text = response.Message;
            if (response.Status)
            {
                txtPatientId.Text = patientId.ToString();
                if (IsAdminRole())
                    LoadAllMedicalRecords();
                else
                    LoadMedicalRecords(patientId);
            }
        }

        private void btnDeleteRecord_Click(object? sender, EventArgs e)
        {
            if (!IsAdminRole())
                return;

            if (!int.TryParse(txtEditRecordId.Text, out int id) || id <= 0)
            {
                lblStatus.Text = "Pilih rekam medis yang akan dihapus.";
                return;
            }

            var response = medicalServices.DeleteMedicalRecord(id);
            lblStatus.Text = response.Message;
            if (response.Status)
            {
                ClearEditor();
                LoadAllMedicalRecords();
            }
        }

        private static bool IsDoctorRole()
        {
            return UserSession.Role.Equals("Dokter", StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsAdminRole()
        {
            return UserSession.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }
    }
}
