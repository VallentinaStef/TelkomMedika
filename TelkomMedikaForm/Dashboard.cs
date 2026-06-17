using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelkomMedika.Services;

namespace TelkomMedikaForm
{
    public partial class Dashboard : Form
    {
        private AuthService authService;
        public Dashboard()
        {
            InitializeComponent();
            authService = new AuthService();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            authService.Logout();

            this.Hide();

            LoginForm login = new LoginForm();
            login.Show();
        }

        private void btnObat_Click(object? sender, EventArgs e)
        {
            ObatForm obatForm = new ObatForm();
            obatForm.ShowDialog();
        }
    }
}
