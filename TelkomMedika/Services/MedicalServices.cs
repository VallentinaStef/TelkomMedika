using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes_KPL_Kelompok_1.src.API;
using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Utils;

namespace Tubes_KPL_Kelompok_1.src.Services
{
    public class MedicalServices
    {
        private MedicalApiClient api;

        public MedicalServices(MedicalApiClient api)
        {
            this.api = api;
        }

        public Response<MedicalHistory> AddMedicalHistory(MedicalHistory h)
        {
            return api.AddMedicalHistory(h);
        }

        public Response<List<MedicalHistory>> GetHistory(int pasien)
        {
            return api.GetHistory(pasien);
        }

        public Response<List<MedicalHistory>> GetAllMedicalHistories()
        {
            return api.GetAllMedicalHistories();
        }

        public Response<MedicalHistory> UpdateMedicalHistory(int id, MedicalHistory history)
        {
            return api.UpdateMedicalHistory(id, history);
        }

        public Response<bool> DeleteMedicalHistory(int id)
        {
            return api.DeleteMedicalHistory(id);
        }

        public Response<PatientCard> AddPatientCard(PatientCard card)
        {
            return api.AddPatientCard(card);
        }

        public Response<PatientCard> GetPatientCard(int patient)
        {
            return api.GetPatientCard(patient);
        }

        public Response<List<PatientCard>> GetAllPatientCards()
        {
            return api.GetAllPatientCards();
        }

        public Response<PatientCard> UpdatePatientCard(int patientId, PatientCard card)
        {
            return api.UpdatePatientCard(patientId, card);
        }

        public Response<bool> DeletePatientCard(int patientId)
        {
            return api.DeletePatientCard(patientId);
        }

        public Response<MedicalRecord> AddMedicalRecord(MedicalRecord record)
        {
            return api.AddMedicalRecord(record);
        }

        public Response<List<MedicalRecord>> GetMedicalRecords(int pI)
        {
            return api.GetMedicalRecords(pI);
        }

        public Response<List<MedicalRecord>> GetAllMedicalRecords()
        {
            return api.GetAllMedicalRecords();
        }

        public Response<MedicalRecord> UpdateMedicalRecord(int id, MedicalRecord record)
        {
            return api.UpdateMedicalRecord(id, record);
        }

        public Response<bool> DeleteMedicalRecord(int id)
        {
            return api.DeleteMedicalRecord(id);
        }
    }
}
