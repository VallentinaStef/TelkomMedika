using System.Collections.Concurrent;
using System.IO;
using System.Text.Json;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Utils;

namespace TelkomMedika.Services
{
    public class ProfileService<T> where T : class
    {
        private static readonly ConcurrentDictionary<string, T> _store = new();
        private static readonly string _jsonPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "TelkomMedika",
            $"profiles_{typeof(T).Name.ToLower()}.json");
        private static readonly object _lock = new();
        private static bool _loaded = false;

        private static void EnsureLoaded()
        {
            if (_loaded) return;
            lock (_lock)
            {
                if (_loaded) return;
                try
                {
                    if (File.Exists(_jsonPath))
                    {
                        string json = File.ReadAllText(_jsonPath);
                        var data = JsonSerializer.Deserialize<Dictionary<string, T>>(json);
                        if (data != null)
                            foreach (var kvp in data)
                                _store[kvp.Key] = kvp.Value;
                    }
                }
                catch { }
                _loaded = true;
            }
        }

        private static void SaveToStorage()
        {
            lock (_lock)
            {
                string? dir = Path.GetDirectoryName(_jsonPath);
                if (!string.IsNullOrWhiteSpace(dir))
                    Directory.CreateDirectory(dir);
                string json = JsonSerializer.Serialize(
                    new Dictionary<string, T>(_store),
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_jsonPath, json);
            }
        }

        public static void Seed(string username, T profile)
        {
            EnsureLoaded();
            if (_store.ContainsKey(username)) return;
            _store[username] = profile;
            SaveToStorage();
        }

        public Response<T> GetProfile(string username)
        {
            EnsureLoaded();
            if (string.IsNullOrWhiteSpace(username))
                return new Response<T> { Status = false, Message = "Username tidak valid." };

            if (_store.TryGetValue(username, out var profile))
                return new Response<T> { Status = true, Data = profile, Message = "Profil ditemukan." };

            return new Response<T> { Status = false, Message = "Profil tidak ditemukan." };
        }

        public Response<bool> UpdateProfile(string username, T profile)
        {
            EnsureLoaded();
            if (string.IsNullOrWhiteSpace(username))
                return new Response<bool> { Status = false, Message = "Username tidak valid." };

            if (profile == null)
                return new Response<bool> { Status = false, Message = "Data profil tidak boleh kosong." };

            _store[username] = profile;
            SaveToStorage();
            return new Response<bool> { Status = true, Data = true, Message = "Profil berhasil diperbarui." };
        }
    }
}
