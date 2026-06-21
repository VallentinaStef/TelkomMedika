using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Services;

namespace TelkomMedikaForm
{
    public partial class PatientCardForm : Form
    {
        private static bool demoDataSeeded;
        private readonly MedicalServices medicalServices;
        private PatientCard? currentCard;
        private Panel pnlEditor = null!;
        private TextBox txtEditPatientId = null!;
        private TextBox txtEditName = null!;
        private ComboBox cmbEditGender = null!;
        private DateTimePicker dtpEditBirthDate = null!;
        private TextBox txtEditAddress = null!;
        private Button btnSaveCard = null!;
        private Button btnDeleteCard = null!;

        public PatientCardForm()
        {
            InitializeComponent();

            medicalServices = new MedicalServices(new MedicalApiClient());
            ConfigurePatientView();
            ConfigureEditor();
            SeedDemoData();
            LoadPatientCard(GetDefaultPatientId());
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

            medicalServices.AddPatientCard(new PatientCard
            {
                PatientId = 3,
                PatientName = "Raka Wijaya",
                Gender = "Laki-laki",
                BirthDate = new DateTime(1996, 11, 3),
                Address = "Jl. Dipatiukur No. 21, Bandung"
            });

            demoDataSeeded = true;
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
            currentCard = card;
            lblCardPatientId.Text = card.PatientId.ToString();
            lblCardName.Text = card.PatientName;
            lblCardGender.Text = card.Gender;
            lblCardBirthDate.Text = card.BirthDate.ToString("dd MMMM yyyy");
            lblCardAddress.Text = card.Address;
            lblStatus.Text = "Kartu pasien digital berhasil ditampilkan.";
            FillEditor(card);
        }

        private void ClearCard()
        {
            lblCardPatientId.Text = "-";
            lblCardName.Text = "-";
            lblCardGender.Text = "-";
            lblCardBirthDate.Text = "-";
            lblCardAddress.Text = "-";
            currentCard = null;
            ClearEditor();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsPatientRole())
            {
                LoadPatientCard(UserSession.PatientId);
                return;
            }

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
            if (IsPatientRole())
            {
                LoadPatientCard(UserSession.PatientId);
                return;
            }

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
            bool canEdit = IsPatientRole() || IsAdminRole();
            if (!canEdit)
                return;

            ClientSize = new Size(ClientSize.Width, 720);
            MinimumSize = new Size(820, 760);
            lblStatus.Location = new Point(24, 656);
            btnBack.Location = new Point(640, 650);

            pnlEditor = new Panel
            {
                BackColor = Color.White,
                Location = new Point(24, 470),
                Size = new Size(736, 160)
            };

            var lblEditorTitle = new Label
            {
                Text = IsPatientRole() ? "Edit Kartu Pasien Saya" : "Kelola Kartu Pasien",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0xC6, 0x28, 0x28),
                Location = new Point(16, 10),
                AutoSize = true
            };

            AddFieldLabel(pnlEditor, "Patient ID", 16, 42);
            txtEditPatientId = CreateTextBox(16, 66, 80, "ID");
            AddFieldLabel(pnlEditor, "Nama", 112, 42);
            txtEditName = CreateTextBox(112, 66, 180, "Nama");
            AddFieldLabel(pnlEditor, "Gender", 308, 42);
            cmbEditGender = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(308, 66),
                Size = new Size(130, 30)
            };
            cmbEditGender.Items.AddRange(new object[] { "Laki-laki", "Perempuan" });
            AddFieldLabel(pnlEditor, "Tanggal Lahir", 454, 42);
            dtpEditBirthDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(454, 66),
                Size = new Size(130, 30)
            };
            AddFieldLabel(pnlEditor, "Alamat", 16, 100);
            txtEditAddress = CreateTextBox(16, 124, 422, "Alamat");

            btnSaveCard = new Button
            {
                Text = IsPatientRole() ? "Simpan" : "Tambah/Edit",
                BackColor = Color.FromArgb(0xC6, 0x28, 0x28),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(500, 122),
                Size = new Size(108, 32)
            };
            btnSaveCard.Click += btnSaveCard_Click;

            btnDeleteCard = new Button
            {
                Text = "Hapus",
                BackColor = Color.FromArgb(192, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(620, 122),
                Size = new Size(96, 32),
                Visible = IsAdminRole()
            };
            btnDeleteCard.Click += btnDeleteCard_Click;

            if (IsPatientRole())
                txtEditPatientId.ReadOnly = true;

            pnlEditor.Controls.Add(lblEditorTitle);
            pnlEditor.Controls.Add(txtEditPatientId);
            pnlEditor.Controls.Add(txtEditName);
            pnlEditor.Controls.Add(cmbEditGender);
            pnlEditor.Controls.Add(dtpEditBirthDate);
            pnlEditor.Controls.Add(txtEditAddress);
            pnlEditor.Controls.Add(btnSaveCard);
            pnlEditor.Controls.Add(btnDeleteCard);
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

        private void FillEditor(PatientCard card)
        {
            if (pnlEditor == null || card == null)
                return;

            txtEditPatientId.Text = card.PatientId.ToString();
            txtEditName.Text = card.PatientName;
            cmbEditGender.SelectedItem = card.Gender;
            dtpEditBirthDate.Value = card.BirthDate == default ? DateTime.Today : card.BirthDate;
            txtEditAddress.Text = card.Address;
        }

        private void ClearEditor()
        {
            if (pnlEditor == null)
                return;

            if (IsPatientRole())
                txtEditPatientId.Text = UserSession.PatientId.ToString();
            else
                txtEditPatientId.Clear();

            txtEditName.Clear();
            cmbEditGender.SelectedIndex = -1;
            dtpEditBirthDate.Value = DateTime.Today;
            txtEditAddress.Clear();
        }

        private void btnSaveCard_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtEditPatientId.Text, out int patientId) || patientId <= 0)
            {
                lblStatus.Text = "Patient ID harus berupa angka lebih dari 0.";
                return;
            }

            if (IsPatientRole())
                patientId = UserSession.PatientId;

            var card = new PatientCard
            {
                PatientId = patientId,
                PatientName = txtEditName.Text.Trim(),
                Gender = cmbEditGender.Text,
                BirthDate = dtpEditBirthDate.Value.Date,
                Address = txtEditAddress.Text.Trim()
            };

            var response = currentCard == null || (IsAdminRole() && currentCard.PatientId != patientId)
                ? medicalServices.AddPatientCard(card)
                : medicalServices.UpdatePatientCard(patientId, card);

            lblStatus.Text = response.Message;
            if (response.Status)
            {
                txtPatientId.Text = patientId.ToString();
                LoadPatientCard(patientId);
            }
        }

        private void btnDeleteCard_Click(object? sender, EventArgs e)
        {
            if (!IsAdminRole())
                return;

            if (!int.TryParse(txtEditPatientId.Text, out int patientId) || patientId <= 0)
            {
                lblStatus.Text = "Patient ID harus berupa angka lebih dari 0.";
                return;
            }

            var response = medicalServices.DeletePatientCard(patientId);
            lblStatus.Text = response.Message;
            if (response.Status)
                ClearCard();
        }

        private static bool IsAdminRole()
        {
            return UserSession.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }
    }
}
