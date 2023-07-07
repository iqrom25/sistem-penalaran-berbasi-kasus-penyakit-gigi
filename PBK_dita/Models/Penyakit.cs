using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PBK_dita.Utils;

namespace PBK_dita.Models
{
    [Table("m_penyakit")]
    [Index(nameof(KodePenyakit),IsUnique = true)]
    public record Penyakit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        [Required]
        [Column("kode_penyakit")]
        [Display(Name = "Kode Penyakit")]
        public string KodePenyakit { get; init; }
        [Required]
        [Display(Name = "Nama Penyakit")]
        public string Nama { get; init; }
        
        [Required]
        [Display(Name = "Deskripsi Penyakit")]
        public string Deskripsi { get; init; }
        
        [Required]
        [Display(Name = "Solusi Penyakit")]
        public string Solusi { get; init; }
        
        public string Gambar { get; init; }
        
        [NotMapped]
        [Required]
        [AllowedExtensions(new string[]{"jpeg","jpg","png"})]
        [MaximumFileSize(2 * 1024 * 1024 /*dalam KB*/)]
        [Display(Name= "Gambar Penyakit")]
        public IFormFile ImageFile { get; set; }
    }
}