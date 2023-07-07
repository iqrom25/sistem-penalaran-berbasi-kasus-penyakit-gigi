using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBK_dita.Models
{
    public record RiwayatKonsultasi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        
        [Column("tanggal_input")]
        [Display(Name = "Tanggal Konsultasi")]
        public DateTimeOffset TanggalInput { get; init; }

        /* penjelasan status
         * 0 -> similiarity di bawah nilai ambang batas
         * 1 -> similiarity di atas nilai ambang batas tapi blm masuk rekam medis
         * 2 -> sudah masuk rekam medis
         */ 
        public int Status { get; set; }

        public ICollection<Gejala> ListGejala { get; set; }

        public User User { get; set; }

        public Penyakit Penyakit { get; init; }

        [Display(Name = "Tingkat Kemiripan")]
        public double Similiarity { get; set; }

    }
}