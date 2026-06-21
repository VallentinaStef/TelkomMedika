using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class MedicalHistoryForm : Form
    {
        private static bool demoDataSeeded;
        private readonly MedicalServices medicalServices;
        private List<MedicalHistory> currentHistories = new List<MedicalHistory>();
        private Panel pnlEditor = null!;
        private TextBox txtEditHistoryId = null!;
        private TextBox txtEditPatientId = null!;
        private TextBox txtEditServiceName = null!;
        private TextBox txtEditDoctorName = null!;
        private TextBox txtEditDescription = null!;
        private Button btnSaveHistory = null!;
        private Button btnDeleteHistory = null!;

        public MedicalHistoryForm()
        {
            InitializeComponent();

            medicalServices = new MedicalServices(new MedicalApiClient());
            ConfigurePatientView();
            ConfigureAdminEditor();
            SeedDemoData();
            if (IsAdminRole())
                LoadAllHistories();
            else
                LoadHistory(GetDefaultPatientId());
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

            medicalServices.AddMedicalHistory(new MedicalHistory
            {
                PatientId = 2,
                ServiceName = "Konsultasi Gigi",
                DoctorName = "drg. Siti Aulia",
                Description = "Pemeriksaan nyeri gigi dan pembersihan karang gigi."
            });

            medicalServices.AddMedicalHistory(new MedicalHistory
            {
                PatientId = 3,
                ServiceName = "Pemeriksaan Fisik",
                DoctorName = "Dr. Nandika Larasati",
                Description = "Pemeriksaan kesehatan rutin dan evaluasi kondisi umum."
            });

            medicalServices.AddMedicalHistory(new MedicalHistory
            {
                PatientId = 3,
                ServiceName = "Kontrol Tekanan Darah",
                DoctorName = "Dr. Faizah",
                Description = "Kontrol tekanan darah dan konsultasi pola makan."
            });

            demoDataSeeded = true;
        }

        private void LoadAllHistories()
        {
            var response = medicalServices.GetAllMedicalHistories();
            if (!response.Status)
            {
                lblStatus.Text = response.Message;
                dgvMedicalHistory.DataSource = null;
                currentHistories = new List<MedicalHistory>();
                return;
            }

            BindHistories(response.Data);
            lblStatus.Text = response.Data.Count == 0
                ? "Belum ada riwayat layanan."
                : $"Menampilkan {response.Data.Count} riwayat layanan.";
        }

        private void LoadHistory(int patientId)
        {
            var response = medicalServices.GetHistory(patientId);

            if (!response.Status)
            {
                lblStatus.Text = response.Message;
                dgvMedicalHistory.DataSource = null;
                currentHistories = new List<MedicalHistory>();
                return;
            }

            BindHistories(response.Data);

            lblStatus.Text = response.Data.Count == 0
                ? "Belum ada riwayat layanan untuk pasien ini."
                : $"Menampilkan {response.Data.Count} riwayat layanan.";
        }

        private void BindHistories(List<MedicalHistory> histories)
        {
            currentHistories = histories;
            dgvMedicalHistory.DataSource = currentHistories
                .Select(history => new
                {
                    history.Id,
                    NamaLayanan = history.ServiceName,
                    Dokter = history.DoctorName,
                    TanggalLayanan = history.ServiceDate.ToString("dd MMM yyyy HH:mm"),
                    Deskripsi = history.Description
                })
                .ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsPatientRole())
            {
                LoadHistory(UserSession.PatientId);
                return;
            }

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
            if (IsPatientRole())
            {
                LoadHistory(UserSession.PatientId);
                return;
            }

            if (IsAdminRole() && string.IsNullOrWhiteSpace(txtPatientId.Text))
            {
                LoadAllHistories();
                return;
            }

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

        private int GetDefaultPatientId()
        {
            return IsPatientRole() && UserSession.PatientId > 0 ? UserSession.PatientId : 1;
        }

        private static bool IsPatientRole()
        {
            return UserSession.Role.Equals("Pasien", StringComparison.OrdinalIgnoreCase);
        }

        private void ConfigureAdminEditor()
        {
            if (!IsAdminRole())
                return;

            ClientSize = new Size(ClientSize.Width, 720);
            MinimumSize = new Size(820, 760);
            lblStatus.Location = new Point(24, 656);
            btnBack.Location = new Point(640, 650);
            dgvMedicalHistory.SelectionChanged += dgvMedicalHistory_SelectionChanged;

            pnlEditor = new Panel
            {
                BackColor = Color.White,
                Location = new Point(24, 470),
                Size = new Size(736, 160)
            };

            var lblEditorTitle = new Label
            {
                Text = "Kelola Riwayat Layanan",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0xC6, 0x28, 0x28),
                Location = new Point(16, 10),
                AutoSize = true
            };

            AddFieldLabel(pnlEditor, "ID", 16, 42);
            txtEditHistoryId = CreateTextBox(16, 66, 55, "ID");
            txtEditHistoryId.ReadOnly = true;
            AddFieldLabel(pnlEditor, "Patient ID", 85, 42);
            txtEditPatientId = CreateTextBox(85, 66, 80, "Pasien");
            AddFieldLabel(pnlEditor, "Nama Layanan", 179, 42);
            txtEditServiceName = CreateTextBox(179, 66, 185, "Layanan");
            AddFieldLabel(pnlEditor, "Dokter", 378, 42);
            txtEditDoctorName = CreateTextBox(378, 66, 150, "Dokter");
            AddFieldLabel(pnlEditor, "Deskripsi", 16, 100);
            txtEditDescription = CreateTextBox(16, 124, 470, "Deskripsi");

            btnSaveHistory = new Button
            {
                Text = "Tambah/Edit",
                BackColor = Color.FromArgb(0xC6, 0x28, 0x28),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(500, 122),
                Size = new Size(105, 32)
            };
            btnSaveHistory.Click += btnSaveHistory_Click;

            btnDeleteHistory = new Button
            {
                Text = "Hapus",
                BackColor = Color.FromArgb(192, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(616, 122),
                Size = new Size(100, 32)
            };
            btnDeleteHistory.Click += btnDeleteHistory_Click;

            pnlEditor.Controls.Add(lblEditorTitle);
            pnlEditor.Controls.Add(txtEditHistoryId);
            pnlEditor.Controls.Add(txtEditPatientId);
            pnlEditor.Controls.Add(txtEditServiceName);
            pnlEditor.Controls.Add(txtEditDoctorName);
            pnlEditor.Controls.Add(txtEditDescription);
            pnlEditor.Controls.Add(btnSaveHistory);
            pnlEditor.Controls.Add(btnDeleteHistory);
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

        private void dgvMedicalHistory_SelectionChanged(object? sender, EventArgs e)
        {
            if (!IsAdminRole() || dgvMedicalHistory.CurrentRow == null)
                return;

            int selectedIndex = dgvMedicalHistory.CurrentRow.Index;
            if (selectedIndex < 0 || selectedIndex >= currentHistories.Count)
                return;

            var history = currentHistories[selectedIndex];
            txtEditHistoryId.Text = history.Id.ToString();
            txtEditPatientId.Text = history.PatientId.ToString();
            txtEditServiceName.Text = history.ServiceName;
            txtEditDoctorName.Text = history.DoctorName;
            txtEditDescription.Text = history.Description;
        }

        private void btnSaveHistory_Click(object? sender, EventArgs e)
        {
            if (!IsAdminRole())
                return;

            if (!int.TryParse(txtEditPatientId.Text, out int patientId) || patientId <= 0)
            {
                lblStatus.Text = "Patient ID harus berupa angka lebih dari 0.";
                return;
            }

            var history = new MedicalHistory
            {
                PatientId = patientId,
                ServiceName = txtEditServiceName.Text.Trim(),
                DoctorName = txtEditDoctorName.Text.Trim(),
                Description = txtEditDescription.Text.Trim(),
                ServiceDate = DateTime.Now
            };

            var response = int.TryParse(txtEditHistoryId.Text, out int id) && id > 0
                ? medicalServices.UpdateMedicalHistory(id, history)
                : medicalServices.AddMedicalHistory(history);

            lblStatus.Text = response.Message;
            if (response.Status)
                LoadAllHistories();
        }

        private void btnDeleteHistory_Click(object? sender, EventArgs e)
        {
            if (!IsAdminRole())
                return;

            if (!int.TryParse(txtEditHistoryId.Text, out int id) || id <= 0)
            {
                lblStatus.Text = "Pilih riwayat layanan yang akan dihapus.";
                return;
            }

            var response = medicalServices.DeleteMedicalHistory(id);
            lblStatus.Text = response.Message;
            if (response.Status)
            {
                ClearEditor();
                LoadAllHistories();
            }
        }

        private void ClearEditor()
        {
            if (pnlEditor == null)
                return;

            txtEditHistoryId.Clear();
            txtEditPatientId.Clear();
            txtEditServiceName.Clear();
            txtEditDoctorName.Clear();
            txtEditDescription.Clear();
        }

        private static bool IsAdminRole()
        {
            return UserSession.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }
    }
}
