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
            lblWelcome.Text = $"Selamat Datang, {UserSession.Name}";
            lblRoleDisplay.Text = $"Anda login sebagai {UserSession.Role}";
            SetupSidebarMenu();
        }

        private void SetupSidebarMenu()
        {
            panelSidebar.Controls.Clear();

            var menus = GetMenusByRole();
            int y = 20;

            foreach (var menu in menus)
            {
                var btn = new Button
                {
                    Text = menu.Text,
                    Tag = menu.Action,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Teal,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 0, 0, 0),
                    Size = new Size(200, 45),
                    Location = new Point(10, y),
                    FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.DarkSlateGray }
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
                    ("Data Pasien", "datapasien"),
                    ("Reservasi", "reservasi"),
                    ("Jadwal Dokter", "jadwaldokter"),
                    ("Notifikasi & Konsultasi", "notifikasi"),
                    ("Logout", "logout")
                },
                ["Dokter"] = new()
                {
                    ("Profil", "profil"),
                    ("Rekam Medis Pasien", "rekammedis"),
                    ("Riwayat Medis", "riwayatmedis"),
                    ("Jadwal Dokter", "jadwaldokter"),
                    ("Reservasi", "reservasi"),
                    ("Logout", "logout")
                },
                ["Pasien"] = new()
                {
                    ("Profil", "profil"),
                    ("Rekam Medis Pribadi", "rekammedis"),
                    ("Riwayat Layanan", "riwayatlayanan"),
                    ("Reservasi", "reservasi"),
                    ("Jadwal Operasional", "jadwaloperasional"),
                    ("Notifikasi & Konsultasi", "notifikasi"),
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

            switch (action)
            {
                case "profil":
                    var profileForm = new ProfileForm();
                    profileForm.Show();
                    break;

                case "logout":
                    DoLogout();
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
            var authService = new AuthService();
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
