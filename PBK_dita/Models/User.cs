using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PBK_dita.Models
{
    [Table("m_user")]
    [Index(nameof(Email),IsUnique = true)]
    public record User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        
        [Required]
        public string Nama { get; init; }
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",ErrorMessage = "invalid email")]
        
        public string Email { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int Umur { get; init; }
        [Display(Name = "Jenis Kelamin")]
        [Column("jenis_kelamin")]
        [Required]
        public string JenisKelamin { get; init; }
        [Required]
        [MinLength(8,ErrorMessage = "Passwords must have at least 8 characters")]
        public string Password { get; init; }
        
        public int Role { get; init; }
    };
}