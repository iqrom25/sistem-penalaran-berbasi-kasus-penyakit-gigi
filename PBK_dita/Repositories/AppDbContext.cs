using Microsoft.EntityFrameworkCore;
using PBK_dita.Models;

namespace PBK_dita.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Penyakit> DaftarPenyakit { get; set; }
        public DbSet<Gejala> DaftarGejala { get; set; }
        public DbSet<RekamMedis> DaftarRekamMedis { get; set; }
        
 
    }
}