using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.States;
using Tubes_KPL_Kelompok_1.src.Utils;

namespace TelkomMedika.Services
{
    public sealed class AuthService
    {
        // singleton
        public static AuthService Instance { get; } = new AuthService();

        private AuthService() { }

        public AuthState State { get; private set; } = AuthState.LoggedOut;
        public User CurrentUser;

        // per-user login info
        private class LoginInfo
        {
            public int Attempts;
            public DateTime? LockUntil;
        }

        private class PatientAccount
        {
            public string Username { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public int PatientId { get; set; }
            public string Phone { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
        }

        private static readonly List<PatientAccount> PatientAccounts = new()
        {
            new PatientAccount { Username = "pasien1", Name = "Andi Pratama", PatientId = 1, Phone = "08123456789", Address = "Jl. Merdeka No. 10, Bandung" },
            new PatientAccount { Username = "pasien2", Name = "Siti Rahma", PatientId = 2, Phone = "08129876543", Address = "Jl. Telekomunikasi No. 5, Bandung" },
            new PatientAccount { Username = "pasien3", Name = "Raka Wijaya", PatientId = 3, Phone = "08127654321", Address = "Jl. Dipatiukur No. 21, Bandung" }
        };

        private readonly System.Collections.Concurrent.ConcurrentDictionary<string, LoginInfo> _loginMap = new();

        private const int MAX_ATTEMPTS = 3;
        private static readonly TimeSpan LOCK_DURATION = TimeSpan.FromMinutes(15);

        public Response<User> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new Response<User> { Status = false, Message = "Username wajib diisi!" };
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return new Response<User> { Status = false, Message = "Password wajib diisi!" };
            }

            if (!IsUserRegistered(username))
            {
                return new Response<User> { Status = false, Message = "Username tidak terdaftar!" };
            }

            var info = _loginMap.GetOrAdd(username, _ => new LoginInfo { Attempts = 0, LockUntil = null });

            if (info.LockUntil.HasValue && info.LockUntil.Value > DateTime.UtcNow)
            {
                var remaining = info.LockUntil.Value - DateTime.UtcNow;
                var minutes = (int)Math.Ceiling(remaining.TotalMinutes);
                return new Response<User>
                {
                    Status = false,
                    Message = $"Akun terkunci. Coba lagi dalam {minutes} menit."
                };
            }

            // validate credentials (existing hardcoded users)
            if (username == "admin" && password == "123")
            {
                State = AuthState.LoggedIn;
                _loginMap.TryRemove(username, out _);

                ProfileService<AdminProfile>.Seed(username, new AdminProfile { Username = username, Name = "Admin", Role = "Admin", NoTelpKantor = "021-1234567" });
                var adminProfile = new ProfileService<AdminProfile>().GetProfile(username);
                string adminName = adminProfile.Status && adminProfile.Data != null ? adminProfile.Data.Name : "Admin";

                CurrentUser = new User { Username = username, Name = adminName, Role = "Admin" };
                UserSession.Username = username;
                UserSession.Name = adminName;
                UserSession.Role = "Admin";

                return new Response<User> { Status = true, Data = CurrentUser, Message = "Login berhasil sebagai Admin!" };
            }

            if (username == "dokter" && password == "123")
            {
                State = AuthState.LoggedIn;
                _loginMap.TryRemove(username, out _);

                ProfileService<DokterProfile>.Seed(username, new DokterProfile { Username = username, Name = "Dr. Budi", Role = "Dokter", Spesialisasi = "Umum", NomorSTR = "STR-12345" });
                var dokterProfile = new ProfileService<DokterProfile>().GetProfile(username);
                string dokterName = dokterProfile.Status && dokterProfile.Data != null ? dokterProfile.Data.Name : "Dr. Budi";

                CurrentUser = new User { Username = username, Name = dokterName, Role = "Dokter" };
                UserSession.Username = username;
                UserSession.Name = dokterName;
                UserSession.Role = "Dokter";

                return new Response<User> { Status = true, Data = CurrentUser, Message = "Login berhasil sebagai Dokter!" };
            }

            var patientAccount = PatientAccounts.FirstOrDefault(patient =>
                patient.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (patientAccount != null && password == "123")
            {
                return LoginPatient(patientAccount);
            }

            // wrong credentials
            info.Attempts++;
            int remainingAttempts = MAX_ATTEMPTS - info.Attempts;

            if (info.Attempts >= MAX_ATTEMPTS)
            {
                info.LockUntil = DateTime.UtcNow.Add(LOCK_DURATION);
                return new Response<User> { Status = false, Message = $"Akun terkunci. Coba lagi dalam {LOCK_DURATION.TotalMinutes} menit." };
            }

            return new Response<User> { Status = false, Message = $"Login gagal! Sisa percobaan: {remainingAttempts}" };
        }

        public Response<string> Logout()
        {
            State = AuthState.LoggedOut;
            CurrentUser = null;
            UserSession.Clear();

            return new Response<string> { Status = true, Message = "Logout berhasil!" };
        }

        // admin / helper APIs
        public bool UnlockUser(string username)
        {
            return _loginMap.TryRemove(username, out _);
        }

        public void ClearAllAttempts()
        {
            _loginMap.Clear();
        }

        public int GetAttempts(string username)
        {
            return _loginMap.TryGetValue(username, out var info) ? info.Attempts : 0;
        }

        public TimeSpan? GetRemainingLockTime(string username)
        {
            if (_loginMap.TryGetValue(username, out var info) && info.LockUntil.HasValue)
            {
                var rem = info.LockUntil.Value - DateTime.UtcNow;
                return rem > TimeSpan.Zero ? rem : (TimeSpan?)null;
            }
            return null;
        }

        public List<string> GetRegisteredUsers()
        {
            var users = new List<string> { "admin", "dokter" };
            users.AddRange(PatientAccounts.Select(patient => patient.Username));
            return users;
        }

        public bool IsUserRegistered(string username)
        {
            return GetRegisteredUsers().Contains(username, StringComparer.OrdinalIgnoreCase);
        }

        private Response<User> LoginPatient(PatientAccount patient)
        {
            State = AuthState.LoggedIn;
            _loginMap.TryRemove(patient.Username, out _);

            ProfileService<PasienProfile>.Seed(patient.Username, new PasienProfile
            {
                Username = patient.Username,
                Name = patient.Name,
                Role = "Pasien",
                NoTelp = patient.Phone,
                Alamat = patient.Address
            });

            var pasienProfile = new ProfileService<PasienProfile>().GetProfile(patient.Username);
            string pasienName = pasienProfile.Status && pasienProfile.Data != null ? pasienProfile.Data.Name : patient.Name;

            CurrentUser = new User
            {
                Username = patient.Username,
                Name = pasienName,
                Role = "Pasien",
                PatientId = patient.PatientId
            };

            UserSession.Username = patient.Username;
            UserSession.Name = pasienName;
            UserSession.Role = "Pasien";
            UserSession.PatientId = patient.PatientId;

            return new Response<User> { Status = true, Data = CurrentUser, Message = $"Login berhasil sebagai Pasien {pasienName}!" };
        }

        public List<string> GetLockedUsers()
        {
            var now = DateTime.UtcNow;
            return _loginMap.Where(kv => kv.Value.LockUntil.HasValue && kv.Value.LockUntil.Value > now).Select(kv => kv.Key).ToList();
        }
    }
}
