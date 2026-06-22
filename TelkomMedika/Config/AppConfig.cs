namespace Tubes_KPL_Kelompok_1.Config
{
    public static class AppConfig
    {
        public static string ReminderMessage { get; set; } = "[PENGINGAT] Waktunya minum obat:";

        public static string ReservationApiBaseUrl = "";
        public static string ReservationEndpoint = "api/reservations";
        public static string ReservationApproveEndpoint = "api/reservations/{0}/approve";
        public static string ReservationCancelEndpoint = "api/reservations/{0}/cancel";
        public static string ReservationStatusEndpoint = "api/reservations/{0}/status";

        public static string MedicalApiBaseUrl = "http://localhost:5287";
        public static string MedicalHistoryEndpoint = "api/medical-histories";
        public static string PatientCardEndpoint = "api/patient-cards";
        public static string MedicalRecordEndpoint = "api/medical-records";
    }
}
