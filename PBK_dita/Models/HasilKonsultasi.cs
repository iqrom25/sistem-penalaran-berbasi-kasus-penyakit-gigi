using System.Collections.Generic;

namespace PBK_dita.Models
{
    public class HasilKonsultasi
    {
        public string Email { get; set; }
        public string Nama { get; set; }
        public int Umur { get; set; }
        public string JenisKelamin { get; set; }
        public Penyakit DiagnosaPenyakit { get; set; }

        public List<Gejala> ListGejala { get; set; }
        public double Similiarity { get; set; }
    }
}