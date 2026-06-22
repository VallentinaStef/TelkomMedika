using TelkomMedika.Services;
using Tubes_KPL_Kelompok_1.src.Models;

namespace TelkomMedikaForm
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SetWelcomeLabel();
            SetupSidebarMenu();
        }

        private void SetWelcomeLabel()
        {
            string welcomeName = UserSession.Role == "Dokter" ? "Dokter" : UserSession.Name;
            lblWelcome.Text = $"Selamat Datang, {welcomeName}";
            lblRoleDisplay.Text = $"Anda login sebagai {UserSession.Role}";
        }

        internal void RefreshWelcome()
        {
            SetWelcomeLabel();
        }

        private void Dashboard_Activated(object? sender, EventArgs e)
        {
            SetWelcomeLabel();
        }

        private Button _activeMenuButton;

        private void SetupSidebarMenu()
        {
            panelSidebar.Controls.Clear();
            _activeMenuButton = null;

            var menus = GetMenusByRole();
            int y = 20;

            foreach (var menu in menus)
            {
                var btn = new Button
                {
                    Text = menu.Text,
                    Tag = menu.Action,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(0xC6, 0x28, 0x28),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(5, 0, 0, 0),
                    Size = new Size(280, 45),
                    Location = new Point(10, y),
                    FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(0x8E, 0x00, 0x00) }
                };

                btn.Click += MenuButton_Click;
                panelSidebar.Controls.Add(btn);
                y += 55;
            }
        }

        private List<(string Text, string Action)> GetMenusByRole()
        {
            var allMenus = new Dictionary<string, List<(string, string)>>
            {
                ["Admin"] = new()
                {
                    ("Profil", "profil"),
                    ("Kartu Pasien", "kartupasien"),
                    ("Riwayat Layanan", "riwayatlayanan"),
                    ("Rekam Medis", "rekammedis"),
                    ("Reservasi", "reservasi"),
                    ("Kelola Reservasi", "kelolareservasi"),
                    ("Jadwal Dokter", "jadwaldokter"),
                    ("Notifikasi", "notifikasi"),
                    ("Konsultasi", "konsultasi"),
                    ("Unlock User", "unlock"),
                    ("Logout", "logout")
                },
                ["Dokter"] = new()
                {
                    ("Riwayat Layanan Pasien", "riwayatlayanan"),
                    ("Rekam Medis Pasien", "rekammedis"),
                    ("Reservasi Disetujui", "reservasidisetujui"),
                    ("Jadwal Dokter", "jadwaldokter"),
                    ("Logout", "logout")
                },
                ["Pasien"] = new()
                {
                    ("Profil", "profil"),
                    ("Kartu Pasien", "kartupasien"),
                    ("Riwayat Layanan", "riwayatlayanan"),
                    ("Rekam Medis", "rekammedis"),
                    ("Reservasi", "reservasi"),
                    ("Jadwal Dokter", "jadwaldokter"),
                    ("Notifikasi", "notifikasi"),
                    ("Konsultasi", "konsultasi"),
                    ("Pengingat Obat", "pengingatobat"),
                    ("Logout", "logout")
                }
            };

            string role = UserSession.Role;
            return allMenus.ContainsKey(role) ? allMenus[role] : new();
        }

        private void MenuButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not string action)
                return;

            if (_activeMenuButton != null && _activeMenuButton != btn)
                _activeMenuButton.BackColor = Color.FromArgb(0xC6, 0x28, 0x28);

            btn.BackColor = Color.FromArgb(0x8E, 0x00, 0x00);
            _activeMenuButton = btn;

            switch (action)
            {
                case "profil":
                    using (var pf = new ProfileForm())
                        pf.ShowDialog();
                    RefreshWelcome();
                    break;

                case "logout":
                    DoLogout();
                    break;

                case "unlock":
                    var unlockForm = new UnlockUserForm();
                    unlockForm.ShowDialog();
                    break;

                case "pengingatobat":
                    var obatForm = new ObatForm();
                    obatForm.ShowDialog();
                    break;

                case "reservasi":
                    var reservationForm = new ReservationForm();
                    reservationForm.ShowDialog();
                    break;

                case "jadwaldokter":
                    var doctorScheduleForm = new DoctorScheduleForm();
                    doctorScheduleForm.ShowDialog();
                    break;

                case "kelolareservasi":
                    var manageReservationForm = new ManageReservationForm();
                    manageReservationForm.ShowDialog();
                    break;

                case "reservasidisetujui":
                    var approvedReservationForm = new ApprovedReservationForm();
                    approvedReservationForm.ShowDialog();
                    break;

                case "kartupasien":
                    var patientCardForm = new PatientCardForm();
                    patientCardForm.ShowDialog();
                    break;

                case "riwayatlayanan":
                    var medicalHistoryForm = new MedicalHistoryForm();
                    medicalHistoryForm.ShowDialog();
                    break;

                case "rekammedis":
                    var medicalRecordForm = new MedicalRecordForm();
                    medicalRecordForm.ShowDialog();
                    break;

                case "notifikasi":
                    var notifikasiForm = new NotifikasiForm();
                    notifikasiForm.ShowDialog();
                    break;

                case "konsultasi":
                    var konsultasiForm = new KonsultasiForm();
                    konsultasiForm.ShowDialog();
                    break;

                default:
                    string featureName = btn.Text;
                    MessageBox.Show(
                        $"Fitur \"{featureName}\" akan segera tersedia.",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    break;
            }
        }

        private void DoLogout()
        {
            var confirm = MessageBox.Show(
                "Yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirm != DialogResult.Yes)
                return;

            var authService = TelkomMedika.Services.AuthService.Instance;
            authService.Logout();

            this.Close();

            LoginForm login = new LoginForm();
            login.Show();
        }

        private void Dashboard_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (!UserSession.IsLoggedIn)
                return;

            Application.Exit();
        }
    }
}