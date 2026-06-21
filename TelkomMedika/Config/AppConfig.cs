namespace Tubes_KPL_Kelompok_1.Config
{
    public static class AppConfig
    {
        public static string ReminderMessage = "[PENGINGAT] Waktunya minum obat:";

        public static string ReservationApiBaseUrl = "";
        public static string ReservationEndpoint = "api/reservations";
        public static string ReservationApproveEndpoint = "api/reservations/{0}/approve";
        public static string ReservationCancelEndpoint = "api/reservations/{0}/cancel";
        public static string ReservationStatusEndpoint = "api/reservations/{0}/status";
    }
}
