using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBK_dita.Models
{
    [Table("m_rekam_medis")]
    public record RekamMedis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Column("tanggal_input")]
        [Display(Name = "Tanggal Input")]
        public DateTimeOffset TanggalInput { get; init; }
        
        public Penyakit Penyakit { get; init; }

        public ICollection<Gejala> ListGejala { get; set; }
    }
}