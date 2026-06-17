using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.States;
using Tubes_KPL_Kelompok_1.src.Utils;

namespace TelkomMedika.Services
{
    public class AuthService
    {
        public AuthState State { get; private set; } = AuthState.LoggedOut;
        public User CurrentUser;

        private readonly Dictionary<string, int> _loginAttempts = new();
        private const int MAX_ATTEMPTS = 3;

        public Response<User> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new Response<User>
                {
                    Status = false,
                    Message = "Username wajib diisi!"
                };
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return new Response<User>
                {
                    Status = false,
                    Message = "Password wajib diisi!"
                };
            }

            if (!_loginAttempts.ContainsKey(username))
            {
                _loginAttempts[username] = 0;
            }

            if (_loginAttempts[username] >= MAX_ATTEMPTS)
            {
                return new Response<User>
                {
                    Status = false,
                    Message = "Akun terkunci! Terlalu banyak percobaan login."
                };
            }

            if (username == "admin" && password == "123")
            {
                State = AuthState.LoggedIn;
                _loginAttempts[username] = 0;

                CurrentUser = new User
                {
                    Username = username,
                    Name = "Admin",
                    Role = "Admin"
                };

                UserSession.Username = username;
                UserSession.Name = "Admin";
                UserSession.Role = "Admin";

                return new Response<User>
                {
                    Status = true,
                    Data = CurrentUser,
                    Message = "Login berhasil sebagai Admin!"
                };
            }

            if (username == "dokter" && password == "123")
            {
                State = AuthState.LoggedIn;
                _loginAttempts[username] = 0;

                CurrentUser = new User
                {
                    Username = username,
                    Name = "Dr. Budi",
                    Role = "Dokter"
                };

                UserSession.Username = username;
                UserSession.Name = "Dr. Budi";
                UserSession.Role = "Dokter";

                return new Response<User>
                {
                    Status = true,
                    Data = CurrentUser,
                    Message = "Login berhasil sebagai Dokter!"
                };
            }

            if (username == "pasien" && password == "123")
            {
                State = AuthState.LoggedIn;
                _loginAttempts[username] = 0;

                CurrentUser = new User
                {
                    Username = username,
                    Name = "Andi",
                    Role = "Pasien"
                };

                UserSession.Username = username;
                UserSession.Name = "Andi";
                UserSession.Role = "Pasien";

                return new Response<User>
                {
                    Status = true,
                    Data = CurrentUser,
                    Message = "Login berhasil sebagai Pasien!"
                };
            }

            _loginAttempts[username]++;

            return new Response<User>
            {
                Status = false,
                Message = $"Login gagal! Percobaan ke-{_loginAttempts[username]}"
            };
        }

        public Response<string> Logout()
        {
            State = AuthState.LoggedOut;
            CurrentUser = null;
            UserSession.Clear();

            return new Response<string>
            {
                Status = true,
                Message = "Logout berhasil!"
            };
        }

        public int GetAttempts(string username)
        {
            return _loginAttempts.ContainsKey(username) ? _loginAttempts[username] : 0;
        }
    }
}
