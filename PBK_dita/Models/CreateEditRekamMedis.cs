using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBK_dita.Models
{
    public record CreateEditRekamMedis
    {
        public int? Id { get; set; }
        [Display(Name="Penyakit")]
        public int IdPenyakit { get; set; }

        public int[] ListIdGejala { get; set; }
    }
}