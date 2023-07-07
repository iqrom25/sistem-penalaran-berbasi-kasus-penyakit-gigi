using System.ComponentModel.DataAnnotations;
using PBK_dita.Utils;

namespace PBK_dita.Models
{
    public class RevisiModel
    {
        public int IdRiwayat { get; set; }
     
        [Required]
        [Display(Name = "Diagnosa")]
        public int IdPenyakit { get; set; }
        
        [Required]
        [Display(Name = "Kecocokan")]
        [MinValue(80,"Similiarity must be greater or equal threshold (80%)")]
        [MaxValue(100)]
        public double Similiarity { get; set; }
    }
}