using Tubes_KPL_Kelompok_1.src.Models;
using Tubes_KPL_Kelompok_1.src.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var histories = new List<MedicalHistory>();
var patientCards = new List<PatientCard>();
var records = new List<MedicalRecord>();

app.MapGet("/api/medical-histories", () =>
{
    return Results.Ok(new Response<List<MedicalHistory>>
    {
        Status = true,
        Message = "Semua riwayat layanan berhasil diambil.",
        Data = histories.ToList()
    });
})
.WithName("GetAllMedicalHistories")
.WithOpenApi();

app.MapPost("/api/medical-histories", (MedicalHistory history) =>
{
    if (!ValidationHelper.IsValidMedicalHistory(history))
    {
        return Results.BadRequest(new Response<MedicalHistory>
        {
            Status = false,
            Message = "Data riwayat layanan tidak lengkap."
        });
    }

    history.Id = histories.Count == 0 ? 1 : histories.Max(existing => existing.Id) + 1;
    history.ServiceDate = DateTime.Now;
    histories.Add(history);

    return Results.Ok(new Response<MedicalHistory>
    {
        Status = true,
        Message = "Riwayat layanan berhasil ditambahkan.",
        Data = history
    });
})
.WithName("AddMedicalHistory")
.WithOpenApi();

app.MapGet("/api/medical-histories/patient/{patientId:int}", (int patientId) =>
{
    if (!ValidationHelper.IsValidPatientId(patientId))
    {
        return Results.BadRequest(new Response<List<MedicalHistory>>
        {
            Status = false,
            Message = "Patient ID tidak valid.",
            Data = new List<MedicalHistory>()
        });
    }

    var result = histories
        .Where(history => history.PatientId == patientId)
        .ToList();

    return Results.Ok(new Response<List<MedicalHistory>>
    {
        Status = true,
        Message = "Riwayat layanan berhasil diambil.",
        Data = result
    });
})
.WithName("GetMedicalHistoryByPatient")
.WithOpenApi();

app.MapPut("/api/medical-histories/{id:int}", (int id, MedicalHistory history) =>
{
    if (!ValidationHelper.IsValidMedicalHistory(history))
    {
        return Results.BadRequest(new Response<MedicalHistory>
        {
            Status = false,
            Message = "Data riwayat layanan tidak lengkap."
        });
    }

    var existing = histories.FirstOrDefault(item => item.Id == id);
    if (existing == null)
    {
        return Results.NotFound(new Response<MedicalHistory>
        {
            Status = false,
            Message = "Riwayat layanan tidak ditemukan."
        });
    }

    existing.PatientId = history.PatientId;
    existing.ServiceName = history.ServiceName;
    existing.DoctorName = history.DoctorName;
    existing.Description = history.Description;
    existing.ServiceDate = history.ServiceDate == default ? existing.ServiceDate : history.ServiceDate;

    return Results.Ok(new Response<MedicalHistory>
    {
        Status = true,
        Message = "Riwayat layanan berhasil diupdate.",
        Data = existing
    });
})
.WithName("UpdateMedicalHistory")
.WithOpenApi();

app.MapDelete("/api/medical-histories/{id:int}", (int id) =>
{
    var existing = histories.FirstOrDefault(item => item.Id == id);
    if (existing == null)
    {
        return Results.NotFound(new Response<bool>
        {
            Status = false,
            Message = "Riwayat layanan tidak ditemukan.",
            Data = false
        });
    }

    histories.Remove(existing);

    return Results.Ok(new Response<bool>
    {
        Status = true,
        Message = "Riwayat layanan berhasil dihapus.",
        Data = true
    });
})
.WithName("DeleteMedicalHistory")
.WithOpenApi();

app.MapGet("/api/patient-cards", () =>
{
    return Results.Ok(new Response<List<PatientCard>>
    {
        Status = true,
        Message = "Semua kartu pasien berhasil diambil.",
        Data = patientCards.ToList()
    });
})
.WithName("GetAllPatientCards")
.WithOpenApi();

app.MapPost("/api/patient-cards", (PatientCard card) =>
{
    if (!ValidationHelper.IsValidPatientCard(card))
    {
        return Results.BadRequest(new Response<PatientCard>
        {
            Status = false,
            Message = "Data kartu pasien tidak lengkap."
        });
    }

    patientCards.RemoveAll(existing => existing.PatientId == card.PatientId);
    patientCards.Add(card);

    return Results.Ok(new Response<PatientCard>
    {
        Status = true,
        Message = "Kartu pasien digital berhasil ditambahkan.",
        Data = card
    });
})
.WithName("AddPatientCard")
.WithOpenApi();

app.MapGet("/api/patient-cards/{patientId:int}", (int patientId) =>
{
    if (!ValidationHelper.IsValidPatientId(patientId))
    {
        return Results.BadRequest(new Response<PatientCard>
        {
            Status = false,
            Message = "Patient ID tidak valid."
        });
    }

    var card = patientCards.FirstOrDefault(existing => existing.PatientId == patientId);
    if (card == null)
    {
        return Results.NotFound(new Response<PatientCard>
        {
            Status = false,
            Message = "Kartu pasien digital tidak ditemukan."
        });
    }

    return Results.Ok(new Response<PatientCard>
    {
        Status = true,
        Message = "Kartu pasien digital berhasil diambil.",
        Data = card
    });
})
.WithName("GetPatientCard")
.WithOpenApi();

app.MapPut("/api/patient-cards/{patientId:int}", (int patientId, PatientCard card) =>
{
    card.PatientId = patientId;
    if (!ValidationHelper.IsValidPatientCard(card))
    {
        return Results.BadRequest(new Response<PatientCard>
        {
            Status = false,
            Message = "Data kartu pasien tidak lengkap."
        });
    }

    var existing = patientCards.FirstOrDefault(item => item.PatientId == patientId);
    if (existing == null)
    {
        return Results.NotFound(new Response<PatientCard>
        {
            Status = false,
            Message = "Kartu pasien digital tidak ditemukan."
        });
    }

    existing.PatientName = card.PatientName;
    existing.Gender = card.Gender;
    existing.BirthDate = card.BirthDate;
    existing.Address = card.Address;

    return Results.Ok(new Response<PatientCard>
    {
        Status = true,
        Message = "Kartu pasien digital berhasil diupdate.",
        Data = existing
    });
})
.WithName("UpdatePatientCard")
.WithOpenApi();

app.MapDelete("/api/patient-cards/{patientId:int}", (int patientId) =>
{
    var existing = patientCards.FirstOrDefault(item => item.PatientId == patientId);
    if (existing == null)
    {
        return Results.NotFound(new Response<bool>
        {
            Status = false,
            Message = "Kartu pasien digital tidak ditemukan.",
            Data = false
        });
    }

    patientCards.Remove(existing);

    return Results.Ok(new Response<bool>
    {
        Status = true,
        Message = "Kartu pasien digital berhasil dihapus.",
        Data = true
    });
})
.WithName("DeletePatientCard")
.WithOpenApi();

app.MapGet("/api/medical-records", () =>
{
    return Results.Ok(new Response<List<MedicalRecord>>
    {
        Status = true,
        Message = "Semua rekam medis berhasil diambil.",
        Data = records.ToList()
    });
})
.WithName("GetAllMedicalRecords")
.WithOpenApi();

app.MapPost("/api/medical-records", (MedicalRecord record) =>
{
    if (!ValidationHelper.IsValidMedicalRecord(record))
    {
        return Results.BadRequest(new Response<MedicalRecord>
        {
            Status = false,
            Message = "Data rekam medis tidak lengkap."
        });
    }

    record.Id = records.Count == 0 ? 1 : records.Max(existing => existing.Id) + 1;
    record.RecordDate = DateTime.Now;
    records.Add(record);

    return Results.Ok(new Response<MedicalRecord>
    {
        Status = true,
        Message = "Rekam medis digital berhasil ditambahkan.",
        Data = record
    });
})
.WithName("AddMedicalRecord")
.WithOpenApi();

app.MapGet("/api/medical-records/patient/{patientId:int}", (int patientId) =>
{
    if (!ValidationHelper.IsValidPatientId(patientId))
    {
        return Results.BadRequest(new Response<List<MedicalRecord>>
        {
            Status = false,
            Message = "Patient ID tidak valid.",
            Data = new List<MedicalRecord>()
        });
    }

    var result = records
        .Where(record => record.PatientId == patientId)
        .ToList();

    return Results.Ok(new Response<List<MedicalRecord>>
    {
        Status = true,
        Message = "Data rekam medis berhasil diambil.",
        Data = result
    });
})
.WithName("GetMedicalRecordsByPatient")
.WithOpenApi();

app.MapPut("/api/medical-records/{id:int}", (int id, MedicalRecord record) =>
{
    if (!ValidationHelper.IsValidMedicalRecord(record))
    {
        return Results.BadRequest(new Response<MedicalRecord>
        {
            Status = false,
            Message = "Data rekam medis tidak lengkap."
        });
    }

    var existing = records.FirstOrDefault(item => item.Id == id);
    if (existing == null)
    {
        return Results.NotFound(new Response<MedicalRecord>
        {
            Status = false,
            Message = "Rekam medis digital tidak ditemukan."
        });
    }

    existing.PatientId = record.PatientId;
    existing.PatientName = record.PatientName;
    existing.DoctorName = record.DoctorName;
    existing.Complaint = record.Complaint;
    existing.Diagnosis = record.Diagnosis;
    existing.Medicine = record.Medicine;
    existing.RecordDate = record.RecordDate == default ? existing.RecordDate : record.RecordDate;

    return Results.Ok(new Response<MedicalRecord>
    {
        Status = true,
        Message = "Rekam medis digital berhasil diupdate.",
        Data = existing
    });
})
.WithName("UpdateMedicalRecord")
.WithOpenApi();

app.MapDelete("/api/medical-records/{id:int}", (int id) =>
{
    var existing = records.FirstOrDefault(item => item.Id == id);
    if (existing == null)
    {
        return Results.NotFound(new Response<bool>
        {
            Status = false,
            Message = "Rekam medis digital tidak ditemukan.",
            Data = false
        });
    }

    records.Remove(existing);

    return Results.Ok(new Response<bool>
    {
        Status = true,
        Message = "Rekam medis digital berhasil dihapus.",
        Data = true
    });
})
.WithName("DeleteMedicalRecord")
.WithOpenApi();

app.Run();
