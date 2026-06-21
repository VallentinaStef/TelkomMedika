using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using Tubes_KPL_Kelompok_1.Config;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Utils;

namespace Tubes_KPL_Kelompok_1.src.API
{
    public class MedicalApiClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private readonly List<MedicalHistory> histories = new List<MedicalHistory>();
        private readonly List<PatientCard> patientCards = new List<PatientCard>();
        private readonly List<MedicalRecord> records = new List<MedicalRecord>();

        private bool UseRemoteMedicalApi => !string.IsNullOrWhiteSpace(AppConfig.MedicalApiBaseUrl);

        public Response<MedicalHistory> AddMedicalHistory(MedicalHistory history)
        {
            if (!ValidationHelper.IsValidMedicalHistory(history))
            {
                return new Response<MedicalHistory>
                {
                    Status = false,
                    Message = "Data riwayat layanan tidak lengkap."
                };
            }

            if (UseRemoteMedicalApi)
            {
                return PostToApi<MedicalHistory, MedicalHistory>(AppConfig.MedicalHistoryEndpoint, history);
            }

            history.Id = histories.Count + 1;
            history.ServiceDate = DateTime.Now;
            histories.Add(history);

            return new Response<MedicalHistory>
            {
                Status = true,
                Message = "Riwayat layanan berhasil ditambahkan.",
                Data = history
            };
        }

        public Response<List<MedicalHistory>> GetHistory(int patientId)
        {
            if (!ValidationHelper.IsValidPatientId(patientId))
            {
                return new Response<List<MedicalHistory>>
                {
                    Status = false,
                    Message = "Patient ID tidak valid.",
                    Data = new List<MedicalHistory>()
                };
            }

            if (UseRemoteMedicalApi)
            {
                return GetFromApi<List<MedicalHistory>>($"{AppConfig.MedicalHistoryEndpoint}/patient/{patientId}", new List<MedicalHistory>());
            }

            var result = histories
                .Where(h => h.PatientId == patientId)
                .ToList();

            return new Response<List<MedicalHistory>>
            {
                Status = true,
                Message = "Riwayat layanan berhasil diambil.",
                Data = result
            };
        }

        public Response<List<MedicalHistory>> GetAllMedicalHistories()
        {
            if (UseRemoteMedicalApi)
            {
                return GetFromApi<List<MedicalHistory>>(AppConfig.MedicalHistoryEndpoint, new List<MedicalHistory>());
            }

            return new Response<List<MedicalHistory>>
            {
                Status = true,
                Message = "Semua riwayat layanan berhasil diambil.",
                Data = histories.ToList()
            };
        }

        public Response<MedicalHistory> UpdateMedicalHistory(int id, MedicalHistory history)
        {
            if (!ValidationHelper.IsValidMedicalHistory(history))
            {
                return new Response<MedicalHistory>
                {
                    Status = false,
                    Message = "Data riwayat layanan tidak lengkap."
                };
            }

            if (UseRemoteMedicalApi)
            {
                return PutToApi<MedicalHistory, MedicalHistory>($"{AppConfig.MedicalHistoryEndpoint}/{id}", history);
            }

            var existing = histories.FirstOrDefault(item => item.Id == id);
            if (existing == null)
            {
                return new Response<MedicalHistory>
                {
                    Status = false,
                    Message = "Riwayat layanan tidak ditemukan."
                };
            }

            existing.PatientId = history.PatientId;
            existing.ServiceName = history.ServiceName;
            existing.DoctorName = history.DoctorName;
            existing.Description = history.Description;
            existing.ServiceDate = history.ServiceDate == default ? existing.ServiceDate : history.ServiceDate;

            return new Response<MedicalHistory>
            {
                Status = true,
                Message = "Riwayat layanan berhasil diupdate.",
                Data = existing
            };
        }

        public Response<bool> DeleteMedicalHistory(int id)
        {
            if (UseRemoteMedicalApi)
            {
                return DeleteFromApi($"{AppConfig.MedicalHistoryEndpoint}/{id}");
            }

            var existing = histories.FirstOrDefault(item => item.Id == id);
            if (existing == null)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = "Riwayat layanan tidak ditemukan.",
                    Data = false
                };
            }

            histories.Remove(existing);
            return new Response<bool>
            {
                Status = true,
                Message = "Riwayat layanan berhasil dihapus.",
                Data = true
            };
        }

        public Response<PatientCard> AddPatientCard(PatientCard card)
        {
            if (!ValidationHelper.IsValidPatientCard(card))
            {
                return new Response<PatientCard>
                {
                    Status = false,
                    Message = "Data kartu pasien tidak lengkap."
                };
            }

            if (UseRemoteMedicalApi)
            {
                return PostToApi<PatientCard, PatientCard>(AppConfig.PatientCardEndpoint, card);
            }

            patientCards.RemoveAll(existing => existing.PatientId == card.PatientId);
            patientCards.Add(card);

            return new Response<PatientCard>
            {
                Status = true,
                Message = "Kartu pasien digital berhasil ditambahkan.",
                Data = card
            };
        }

        public Response<List<PatientCard>> GetAllPatientCards()
        {
            if (UseRemoteMedicalApi)
            {
                return GetFromApi<List<PatientCard>>(AppConfig.PatientCardEndpoint, new List<PatientCard>());
            }

            return new Response<List<PatientCard>>
            {
                Status = true,
                Message = "Semua kartu pasien berhasil diambil.",
                Data = patientCards.ToList()
            };
        }

        public Response<PatientCard> UpdatePatientCard(int patientId, PatientCard card)
        {
            card.PatientId = patientId;
            if (!ValidationHelper.IsValidPatientCard(card))
            {
                return new Response<PatientCard>
                {
                    Status = false,
                    Message = "Data kartu pasien tidak lengkap."
                };
            }

            if (UseRemoteMedicalApi)
            {
                return PutToApi<PatientCard, PatientCard>($"{AppConfig.PatientCardEndpoint}/{patientId}", card);
            }

            var existing = patientCards.FirstOrDefault(item => item.PatientId == patientId);
            if (existing == null)
            {
                return new Response<PatientCard>
                {
                    Status = false,
                    Message = "Kartu pasien digital tidak ditemukan."
                };
            }

            existing.PatientName = card.PatientName;
            existing.Gender = card.Gender;
            existing.BirthDate = card.BirthDate;
            existing.Address = card.Address;

            return new Response<PatientCard>
            {
                Status = true,
                Message = "Kartu pasien digital berhasil diupdate.",
                Data = existing
            };
        }

        public Response<bool> DeletePatientCard(int patientId)
        {
            if (UseRemoteMedicalApi)
            {
                return DeleteFromApi($"{AppConfig.PatientCardEndpoint}/{patientId}");
            }

            var existing = patientCards.FirstOrDefault(item => item.PatientId == patientId);
            if (existing == null)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = "Kartu pasien digital tidak ditemukan.",
                    Data = false
                };
            }

            patientCards.Remove(existing);
            return new Response<bool>
            {
                Status = true,
                Message = "Kartu pasien digital berhasil dihapus.",
                Data = true
            };
        }

        public Response<PatientCard> GetPatientCard(int patientId)
        {
            if (!ValidationHelper.IsValidPatientId(patientId))
            {
                return new Response<PatientCard>
                {
                    Status = false,
                    Message = "Patient ID tidak valid."
                };
            }

            if (UseRemoteMedicalApi)
            {
                return GetFromApi<PatientCard>($"{AppConfig.PatientCardEndpoint}/{patientId}");
            }

            var card = patientCards
                .FirstOrDefault(p => p.PatientId == patientId);

            if (card == null)
            {
                return new Response<PatientCard>
                {
                    Status = false,
                    Message = "Kartu pasien digital tidak ditemukan."
                };
            }

            return new Response<PatientCard>
            {
                Status = true,
                Message = "Kartu pasien digital berhasil diambil.",
                Data = card
            };
        }

        public Response<MedicalRecord> AddMedicalRecord(MedicalRecord record)
        {
            if (!ValidationHelper.IsValidMedicalRecord(record))
            {
                return new Response<MedicalRecord>
                {
                    Status = false,
                    Message = "Data rekam medis tidak lengkap."
                };
            }

            if (UseRemoteMedicalApi)
            {
                return PostToApi<MedicalRecord, MedicalRecord>(AppConfig.MedicalRecordEndpoint, record);
            }

            record.Id = records.Count + 1;
            record.RecordDate = DateTime.Now;
            records.Add(record);

            return new Response<MedicalRecord>
            {
                Status = true,
                Message = "Rekam medis digital berhasil ditambahkan.",
                Data = record
            };
        }

        public Response<List<MedicalRecord>> GetMedicalRecords(int patientId)
        {
            if (!ValidationHelper.IsValidPatientId(patientId))
            {
                return new Response<List<MedicalRecord>>
                {
                    Status = false,
                    Message = "Patient ID tidak valid.",
                    Data = new List<MedicalRecord>()
                };
            }

            if (UseRemoteMedicalApi)
            {
                return GetFromApi<List<MedicalRecord>>($"{AppConfig.MedicalRecordEndpoint}/patient/{patientId}", new List<MedicalRecord>());
            }

            var result = records
                .Where(r => r.PatientId == patientId)
                .ToList();

            return new Response<List<MedicalRecord>>
            {
                Status = true,
                Message = "Data rekam medis berhasil diambil.",
                Data = result
            };
        }

        public Response<List<MedicalRecord>> GetAllMedicalRecords()
        {
            if (UseRemoteMedicalApi)
            {
                return GetFromApi<List<MedicalRecord>>(AppConfig.MedicalRecordEndpoint, new List<MedicalRecord>());
            }

            return new Response<List<MedicalRecord>>
            {
                Status = true,
                Message = "Semua rekam medis berhasil diambil.",
                Data = records.ToList()
            };
        }

        public Response<MedicalRecord> UpdateMedicalRecord(int id, MedicalRecord record)
        {
            if (!ValidationHelper.IsValidMedicalRecord(record))
            {
                return new Response<MedicalRecord>
                {
                    Status = false,
                    Message = "Data rekam medis tidak lengkap."
                };
            }

            if (UseRemoteMedicalApi)
            {
                return PutToApi<MedicalRecord, MedicalRecord>($"{AppConfig.MedicalRecordEndpoint}/{id}", record);
            }

            var existing = records.FirstOrDefault(item => item.Id == id);
            if (existing == null)
            {
                return new Response<MedicalRecord>
                {
                    Status = false,
                    Message = "Rekam medis digital tidak ditemukan."
                };
            }

            existing.PatientId = record.PatientId;
            existing.PatientName = record.PatientName;
            existing.DoctorName = record.DoctorName;
            existing.Complaint = record.Complaint;
            existing.Diagnosis = record.Diagnosis;
            existing.Medicine = record.Medicine;
            existing.RecordDate = record.RecordDate == default ? existing.RecordDate : record.RecordDate;

            return new Response<MedicalRecord>
            {
                Status = true,
                Message = "Rekam medis digital berhasil diupdate.",
                Data = existing
            };
        }

        public Response<bool> DeleteMedicalRecord(int id)
        {
            if (UseRemoteMedicalApi)
            {
                return DeleteFromApi($"{AppConfig.MedicalRecordEndpoint}/{id}");
            }

            var existing = records.FirstOrDefault(item => item.Id == id);
            if (existing == null)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = "Rekam medis digital tidak ditemukan.",
                    Data = false
                };
            }

            records.Remove(existing);
            return new Response<bool>
            {
                Status = true,
                Message = "Rekam medis digital berhasil dihapus.",
                Data = true
            };
        }

        private static Response<TResponse> PostToApi<TRequest, TResponse>(string endpoint, TRequest request)
        {
            try
            {
                var response = HttpClient.PostAsJsonAsync(BuildUrl(endpoint), request)
                    .GetAwaiter()
                    .GetResult();

                return ReadApiResponse<TResponse>(response);
            }
            catch (Exception ex)
            {
                return FailedResponse<TResponse>($"Gagal terhubung ke API medical: {ex.Message}");
            }
        }

        private static Response<TResponse> PutToApi<TRequest, TResponse>(string endpoint, TRequest request)
        {
            try
            {
                var response = HttpClient.PutAsJsonAsync(BuildUrl(endpoint), request)
                    .GetAwaiter()
                    .GetResult();

                return ReadApiResponse<TResponse>(response);
            }
            catch (Exception ex)
            {
                return FailedResponse<TResponse>($"Gagal terhubung ke API medical: {ex.Message}");
            }
        }

        private static Response<bool> DeleteFromApi(string endpoint)
        {
            try
            {
                var response = HttpClient.DeleteAsync(BuildUrl(endpoint))
                    .GetAwaiter()
                    .GetResult();

                return ReadApiResponse(response, false);
            }
            catch (Exception ex)
            {
                return FailedResponse($"Gagal terhubung ke API medical: {ex.Message}", false);
            }
        }

        private static Response<T> GetFromApi<T>(string endpoint, T fallbackData = default!)
        {
            try
            {
                var response = HttpClient.GetAsync(BuildUrl(endpoint))
                    .GetAwaiter()
                    .GetResult();

                return ReadApiResponse(response, fallbackData);
            }
            catch (Exception ex)
            {
                return FailedResponse($"Gagal terhubung ke API medical: {ex.Message}", fallbackData);
            }
        }

        private static Response<T> ReadApiResponse<T>(HttpResponseMessage httpResponse, T fallbackData = default!)
        {
            try
            {
                var response = httpResponse.Content.ReadFromJsonAsync<Response<T>>()
                    .GetAwaiter()
                    .GetResult();

                if (response != null)
                    return response;
            }
            catch
            {
            }

            return FailedResponse(
                $"API medical gagal: {(int)httpResponse.StatusCode} {httpResponse.ReasonPhrase}",
                fallbackData);
        }

        private static Response<T> FailedResponse<T>(string message, T data = default!)
        {
            return new Response<T>
            {
                Status = false,
                Message = message,
                Data = data!
            };
        }

        private static string BuildUrl(string endpoint)
        {
            return $"{AppConfig.MedicalApiBaseUrl.TrimEnd('/')}/{endpoint.TrimStart('/')}";
        }
    }
}
