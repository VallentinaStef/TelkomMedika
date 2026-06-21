namespace Tubes_KPL_Kelompok_1.src.Models
{
    public static class UserSession
    {
        public static string Username { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;
        public static string Name { get; set; } = string.Empty;
        public static int PatientId { get; set; }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(Username);

        public static void Clear()
        {
            Username = string.Empty;
            Role = string.Empty;
            Name = string.Empty;
            PatientId = 0;
        }
    }
}
