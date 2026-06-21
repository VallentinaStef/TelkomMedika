using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tubes_KPL_Kelompok_1.Config;
using Tubes_KPL_Kelompok_1.src.Models;

namespace Tubes_KPL_Kelompok_1.src.API
{
        public class ReservationApiClient
        {
            private static readonly HttpClient HttpClient = new HttpClient();
            private static readonly object ReservationLock = new object();
            private static readonly string ReservationStoragePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "TelkomMedika",
                "reservations.json");

            private static readonly (string DoctorName, string Poli, string Day, string Time, int AvailableQuota)[] DoctorScheduleTable =
            {
                ("dr. Adiah Desti", "umum", "Rabu", "07.00 - 15.00 WIB", 10),
                ("dr. Rizky Regia", "umum", "Senin, Selasa, Kamis", "07.00 - 07.00 WIB", 10),
                ("dr. Rizky Regia", "umum", "Sabtu", "07.00 - 21.00 WIB", 10),
                ("dr. Achmad N", "umum", "Jumat & Minggu", "15.00 - 07.00 WIB", 10),
                ("dr. Faizah", "umum", "Rabu", "15.00 - 21.00 WIB", 10),
                ("dr. Faizah", "umum", "Sabtu", "21.00 - 07.00 WIB", 10),
                ("dr. Faizah", "umum", "Minggu", "07.00 - 21.00 WIB", 10),
                ("dr. Nandika Larasati", "umum", "Senin - Minggu", "21.00 - 07.00 WIB", 10),
                ("drg. Siti Aulia", "gigi", "Senin", "07.00 - 15.00 WIB", 10),
                ("drg. Budi Santoso", "gigi", "Selasa & Kamis", "07.00 - 15.00 WIB", 10),
                ("drg. Citra Maharani", "gigi", "Rabu & Jumat", "15.00 - 21.00 WIB", 10),
                ("drg. Dimas Pratama", "gigi", "Sabtu", "07.00 - 21.00 WIB", 10),
                ("drg. Eka Putri", "gigi", "Senin - Minggu", "21.00 - 07.00 WIB", 10)
            };

            private static readonly List<Reservation> reservations = LoadReservationsFromStorage();

            private bool UseRemoteReservationApi => !string.IsNullOrWhiteSpace(AppConfig.ReservationApiBaseUrl);


            // TABLE-DRIVEN CONSTRUCTION
            private List<DoctorSchedule> doctorSchedules =
                DoctorScheduleTable
                    .Select(schedule => new DoctorSchedule
                    {
                        DoctorName = schedule.DoctorName,
                        Poli = schedule.Poli,
                        Day = schedule.Day,
                        Time = schedule.Time,
                        AvailableQuota = schedule.AvailableQuota
                    })
                    .ToList();


            // TABLE-DRIVEN CONSTRUCTION
            private List<OperationalSchedule>
                operationalSchedules =
                new List<OperationalSchedule>()
            {
                new OperationalSchedule
                {
                    Day = "Senin - Minggu",
                    OpenTime = "24 Jam",
                    CloseTime = "-",
                    Is24Hours = true
                }
            };

            // OPERATIONAL SCHEDULE
            public List<OperationalSchedule>
                    GetOperationalSchedules()
                {
                    return operationalSchedules;
                }

            // DOCTOR SCHEDULE
            public List<DoctorSchedule>
                    GetDoctorSchedules()
                {
                    return doctorSchedules;
                }

                public string AddDoctorSchedule(DoctorSchedule schedule)
                {
                    doctorSchedules.Add(schedule);
                    return "Jadwal dokter berhasil ditambahkan!";
                }
                public string UpdateDoctorSchedule(int index, DoctorSchedule newSchedule)
                {
                    if (index < 0 || index >= doctorSchedules.Count)
                    {
                return "Jadwal tidak ditemukan!";
                    }
                    doctorSchedules[index] = newSchedule;

                    return "Jadwal berhasil diupdate!";
                }
                 public string DeleteDoctorSchedule(int index)
                    {
                        if (index < 0 ||
                            index >= doctorSchedules.Count)
                        {
                            return "Jadwal tidak ditemukan!";
                        }

                        doctorSchedules.RemoveAt(index);
                        return "Jadwal berhasil dihapus!";
                    }
        //Reservation
        public string AddReservation(Reservation reservation)
            {
                if (UseRemoteReservationApi)
                {
                    return SendReservationToApi(reservation);
                }

                lock (ReservationLock)
                {
                    var schedule = doctorSchedules.FirstOrDefault(schedule =>
                        schedule.DoctorName == reservation.DoctorName &&
                        schedule.Poli.Equals(reservation.Poli, StringComparison.OrdinalIgnoreCase) &&
                        schedule.Day.Equals(ExtractScheduleDay(reservation.Day), StringComparison.OrdinalIgnoreCase) &&
                        schedule.Time == reservation.Time);

                    if (schedule != null)
                    {
                        int activeReservationCount = reservations.Count(existing =>
                            existing.DoctorName == reservation.DoctorName &&
                            existing.Poli.Equals(reservation.Poli, StringComparison.OrdinalIgnoreCase) &&
                            existing.AppointmentDate.Date == reservation.AppointmentDate.Date &&
                            existing.Time == reservation.Time &&
                            existing.Status != ReservationStatus.Rejected.ToString() &&
                            existing.Status != ReservationStatus.Cancelled.ToString());

                        if (activeReservationCount >= schedule.AvailableQuota)
                            return "Kuota jadwal dokter pada tanggal tersebut sudah penuh!";
                    }

                    bool patientAlreadyBooked = reservations.Any(existing =>
                        existing.PatientUsername == reservation.PatientUsername &&
                        existing.AppointmentDate.Date == reservation.AppointmentDate.Date &&
                        existing.Time == reservation.Time &&
                        existing.Status != ReservationStatus.Rejected.ToString() &&
                        existing.Status != ReservationStatus.Cancelled.ToString());

                    if (patientAlreadyBooked)
                        return "Anda sudah memiliki reservasi aktif pada tanggal dan jam tersebut!";

                    reservation.Id = reservations.Count == 0 ? 1 : reservations.Max(existing => existing.Id) + 1;

                    reservation.BookingNumber = $"A-{reservation.Id:000}";

                    reservations.Add(reservation);
                    SaveReservationsToStorage();
                }

                return "Reservasi berhasil dibuat!";
            }


            public List<Reservation>
                GetReservations()
            {
                if (UseRemoteReservationApi)
                {
                    return GetReservationsFromApi();
                }

                lock (ReservationLock)
                {
                    return reservations.ToList();
                }
            }


            public string ApproveReservation(int id)
            {
                if (UseRemoteReservationApi)
                {
                    return SendReservationStatusToApi(AppConfig.ReservationApproveEndpoint, id, "Reservasi berhasil diapprove!");
                }

                lock (ReservationLock)
                {
                var reservation = reservations.FirstOrDefault( r => r.Id == id);

                if (reservation == null)
                {
                    return "Reservasi tidak ditemukan!";
                }

                reservation.Status = ReservationStatus.Approved.ToString();
                SaveReservationsToStorage();

                return "Reservasi berhasil diapprove!";
                }
            }


            public string CancelReservation(int id)
            {
                if (UseRemoteReservationApi)
                {
                    return SendReservationStatusToApi(AppConfig.ReservationCancelEndpoint, id, "Reservasi berhasil dicancel!");
                }

                lock (ReservationLock)
                {
                var reservation = reservations.FirstOrDefault(r => r.Id == id);

                if (reservation == null)
                {
                    return "Reservasi tidak ditemukan!";
                }

                reservation.Status = ReservationStatus.Cancelled.ToString();
                SaveReservationsToStorage();

                return "Reservasi berhasil dicancel!";
                }
            }

            public string UpdateReservationStatus(int id, ReservationStatus status)
            {
                return UpdateReservationStatus(id, status, string.Empty);
            }

            public string UpdateReservationStatus(int id, ReservationStatus status, string rejectionReason)
            {
                if (UseRemoteReservationApi)
                {
                    if (status == ReservationStatus.Approved)
                        return ApproveReservation(id);

                    if (status == ReservationStatus.Rejected || status == ReservationStatus.Cancelled)
                        return CancelReservation(id);

                    return SendReservationStatusToApi(AppConfig.ReservationStatusEndpoint, id, "Status reservasi berhasil diupdate!", status.ToString());
                }

                lock (ReservationLock)
                {
                var reservation = reservations.FirstOrDefault(r => r.Id == id);

                if (reservation == null)
                {
                    return "Reservasi tidak ditemukan!";
                }

                reservation.Status = status.ToString();
                reservation.RejectionReason = status == ReservationStatus.Rejected ? rejectionReason : string.Empty;
                SaveReservationsToStorage();
                return "Status reservasi berhasil diupdate!";
                }
            }

            private string SendReservationToApi(Reservation reservation)
            {
                try
                {
                    var response = HttpClient.PostAsJsonAsync(BuildUrl(AppConfig.ReservationEndpoint), reservation)
                        .GetAwaiter()
                        .GetResult();

                    return ReadApiMessage(response, "Reservasi berhasil dibuat!");
                }
                catch (Exception ex)
                {
                    return $"Gagal terhubung ke API reservasi: {ex.Message}";
                }
            }

            private List<Reservation> GetReservationsFromApi()
            {
                try
                {
                    var reservationsFromApi = HttpClient.GetFromJsonAsync<List<Reservation>>(BuildUrl(AppConfig.ReservationEndpoint))
                        .GetAwaiter()
                        .GetResult();

                    return reservationsFromApi ?? new List<Reservation>();
                }
                catch
                {
                    return new List<Reservation>();
                }
            }

            private string SendReservationStatusToApi(string endpointTemplate, int id, string successMessage)
            {
                try
                {
                    string endpoint = string.Format(endpointTemplate, id);
                    var response = HttpClient.PutAsync(BuildUrl(endpoint), null)
                        .GetAwaiter()
                        .GetResult();

                    return ReadApiMessage(response, successMessage);
                }
                catch (Exception ex)
                {
                    return $"Gagal terhubung ke API reservasi: {ex.Message}";
                }
            }

            private string SendReservationStatusToApi(string endpointTemplate, int id, string successMessage, string status)
            {
                try
                {
                    string endpoint = string.Format(endpointTemplate, id);
                    var response = HttpClient.PutAsJsonAsync(BuildUrl(endpoint), new { status })
                        .GetAwaiter()
                        .GetResult();

                    return ReadApiMessage(response, successMessage);
                }
                catch (Exception ex)
                {
                    return $"Gagal terhubung ke API reservasi: {ex.Message}";
                }
            }

            private static string ReadApiMessage(HttpResponseMessage response, string successMessage)
            {
                string body = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                if (response.IsSuccessStatusCode)
                {
                    return string.IsNullOrWhiteSpace(body) ? successMessage : body.Trim('"');
                }

                return string.IsNullOrWhiteSpace(body)
                    ? $"API reservasi gagal: {(int)response.StatusCode} {response.ReasonPhrase}"
                    : $"API reservasi gagal: {body}";
            }

            private static string BuildUrl(string endpoint)
            {
                return $"{AppConfig.ReservationApiBaseUrl.TrimEnd('/')}/{endpoint.TrimStart('/')}";
            }

            private static List<Reservation> LoadReservationsFromStorage()
            {
                try
                {
                    if (!File.Exists(ReservationStoragePath))
                        return new List<Reservation>();

                    string json = File.ReadAllText(ReservationStoragePath);
                    return JsonSerializer.Deserialize<List<Reservation>>(json) ?? new List<Reservation>();
                }
                catch
                {
                    return new List<Reservation>();
                }
            }

            private static void SaveReservationsToStorage()
            {
                string? directory = Path.GetDirectoryName(ReservationStoragePath);
                if (!string.IsNullOrWhiteSpace(directory))
                    Directory.CreateDirectory(directory);

                string json = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ReservationStoragePath, json);
            }

            private static string ExtractScheduleDay(string reservationDay)
            {
                int startIndex = reservationDay.LastIndexOf('(');
                int endIndex = reservationDay.LastIndexOf(')');

                if (startIndex < 0 || endIndex <= startIndex)
                    return reservationDay;

                return reservationDay.Substring(startIndex + 1, endIndex - startIndex - 1);
            }
        }
    }

