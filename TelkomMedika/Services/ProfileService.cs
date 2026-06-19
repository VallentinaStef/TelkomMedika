using System.Collections.Concurrent;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Utils;

namespace TelkomMedika.Services
{
    public class ProfileService<T> where T : class
    {
        private static readonly ConcurrentDictionary<string, T> _store = new();

        public static void Seed(string username, T profile)
        {
            _store[username] = profile;
        }

        public Response<T> GetProfile(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return new Response<T> { Status = false, Message = "Username tidak valid." };

            if (_store.TryGetValue(username, out var profile))
                return new Response<T> { Status = true, Data = profile, Message = "Profil ditemukan." };

            return new Response<T> { Status = false, Message = "Profil tidak ditemukan." };
        }

        public Response<bool> UpdateProfile(string username, T profile)
        {
            if (string.IsNullOrWhiteSpace(username))
                return new Response<bool> { Status = false, Message = "Username tidak valid." };

            if (profile == null)
                return new Response<bool> { Status = false, Message = "Data profil tidak boleh kosong." };

            _store[username] = profile;
            return new Response<bool> { Status = true, Data = true, Message = "Profil berhasil diperbarui." };
        }
    }
}
