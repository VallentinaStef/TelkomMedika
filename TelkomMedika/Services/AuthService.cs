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

            if (username != "admin" && username != "dokter" && username != "pasien")
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

                CurrentUser = new User { Username = username, Name = "Admin", Role = "Admin" };
                UserSession.Username = username;
                UserSession.Name = "Admin";
                UserSession.Role = "Admin";

                return new Response<User> { Status = true, Data = CurrentUser, Message = "Login berhasil sebagai Admin!" };
            }

            if (username == "dokter" && password == "123")
            {
                State = AuthState.LoggedIn;
                _loginMap.TryRemove(username, out _);

                CurrentUser = new User { Username = username, Name = "Dr. Budi", Role = "Dokter" };
                UserSession.Username = username;
                UserSession.Name = "Dr. Budi";
                UserSession.Role = "Dokter";

                return new Response<User> { Status = true, Data = CurrentUser, Message = "Login berhasil sebagai Dokter!" };
            }

            if (username == "pasien" && password == "123")
            {
                State = AuthState.LoggedIn;
                _loginMap.TryRemove(username, out _);

                CurrentUser = new User { Username = username, Name = "Andi", Role = "Pasien" };
                UserSession.Username = username;
                UserSession.Name = "Andi";
                UserSession.Role = "Pasien";

                return new Response<User> { Status = true, Data = CurrentUser, Message = "Login berhasil sebagai Pasien!" };
            }

            // wrong credentials
            info.Attempts++;

            if (info.Attempts >= MAX_ATTEMPTS)
            {
                info.LockUntil = DateTime.UtcNow.Add(LOCK_DURATION);
                return new Response<User> { Status = false, Message = $"Akun terkunci. Coba lagi dalam {LOCK_DURATION.TotalMinutes} menit." };
            }

            return new Response<User> { Status = false, Message = $"Login gagal! Percobaan ke-{info.Attempts}" };
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
            return new List<string> { "admin", "dokter", "pasien" };
        }

        public bool IsUserRegistered(string username)
        {
            return GetRegisteredUsers().Contains(username, StringComparer.OrdinalIgnoreCase);
        }

        public List<string> GetLockedUsers()
        {
            var now = DateTime.UtcNow;
            return _loginMap.Where(kv => kv.Value.LockUntil.HasValue && kv.Value.LockUntil.Value > now).Select(kv => kv.Key).ToList();
        }
    }
}
