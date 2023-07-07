using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PBK_dita.Models
{
    [Table("m_gejala")]
    [Index(nameof(KodeGejala),IsUnique = true)]
    public record Gejala
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        [Required]
        [Column("kode_gejala")]
        [Display(Name = "Kode Gejala")]
        public string KodeGejala { get; init; }
        [Required]
        [Display(Name = "Nama Gejala")]
        public string Nama { get; init; }

        public ICollection<RekamMedis> ListRekamMedis { get; set; }
        
        public ICollection<RiwayatKonsultasi> ListRiwayatKonsultasi { get; set; }
    }
}