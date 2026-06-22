using System;
using System.Collections.Generic;
using Tubes_KPL_Kelompok_1.Models;
using Tubes_KPL_Kelompok_1.Config;

namespace Tubes_KPL_Kelompok_1.Modules
{
    public class ObatModule
    {
        private const string FormatWaktuValid = "HH:mm";
        private const string FormatWaktuError = "Format jam salah! Gunakan HH:mm (contoh 08:00)";
        private const string SemuaJadwalLewat = "Semua jadwal obat untuk hari ini sudah lewat.";
        private const string HeaderJadwal = "\n=== JADWAL KONSUMSI OBAT ===";
        private const string BarisJadwal = "- Jam {0} | {1} ({2})";

        private readonly List<Obat> tabelJadwal = new List<Obat>();
        public List<Obat> DaftarJadwal => tabelJadwal;

        private static readonly (string Nama, string Waktu, string Dosis)[] DataAwal =
        {
            ("Paracetamol", "08:00", "500 mg"),
            ("Vitamin C", "18:00", "250 mg")
        };

        public ObatModule()
        {
            foreach (var item in DataAwal)
            {
                TambahJadwal(item.Nama, item.Waktu, item.Dosis);
            }
        }

        public void TambahJadwal(string nama, string waktu, string dosis)
        {
            tabelJadwal.Add(new Obat { Nama = nama, Waktu = waktu, Dosis = dosis });
        }

        public void HapusJadwal(int index)
        {
            if (index >= 0 && index < tabelJadwal.Count)
                tabelJadwal.RemoveAt(index);
        }

        public void TampilkanJadwal()
        {
            Console.WriteLine(HeaderJadwal);
            foreach (var item in tabelJadwal)
            {
                Console.WriteLine(BarisJadwal, item.Waktu, item.Nama, item.Dosis);
            }
        }

        public List<string> CekReminder(string jamSekarangStr)
        {
            var hasil = new List<string>();

            if (!TimeSpan.TryParse(jamSekarangStr, out TimeSpan jamSekarang))
            {
                hasil.Add(FormatWaktuError);
                return hasil;
            }

            bool adaJadwalPas = false;

            foreach (var item in tabelJadwal)
            {
                if (!TimeSpan.TryParse(item.Waktu, out TimeSpan waktuObat))
                    continue;

                if (waktuObat == jamSekarang)
                {
                    hasil.Add($"{AppConfig.ReminderMessage} {item.Nama}!");
                    adaJadwalPas = true;
                }
                else if (waktuObat > jamSekarang)
                {
                    TimeSpan selisih = waktuObat - jamSekarang;
                    hasil.Add($"Kamu harus minum obat {item.Nama}, {FormatSelisih(selisih)} lagi.");
                }
            }

            if (!adaJadwalPas && tabelJadwal.TrueForAll(o =>
                TimeSpan.TryParse(o.Waktu, out TimeSpan t) && t < jamSekarang))
            {
                hasil.Add(SemuaJadwalLewat);
            }

            return hasil;
        }

        private static string FormatSelisih(TimeSpan selisih)
        {
            if (selisih.TotalHours < 1)
                return $"{selisih.Minutes} menit";

            if (selisih.Minutes == 0)
                return $"{selisih.Hours} jam";

            return $"{selisih.Hours} jam {selisih.Minutes} menit";
        }
    }
}