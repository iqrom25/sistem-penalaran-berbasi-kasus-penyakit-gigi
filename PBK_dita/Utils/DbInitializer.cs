using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PBK_dita.Models;
using PBK_dita.Repositories;

namespace PBK_dita.Utils
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {

            var totalAdmin = context.Users.Where(user => user.Role == 1).ToList();

            if (totalAdmin.Count == 0)
            {
                var admin = new User()
                {
                    Email = "admin@gmail.com",
                    JenisKelamin = "Laki-laki",
                    Nama = "Admin",
                    Umur = 23,
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin123"),
                    Role = 1
                };

                context.Users.Add(admin);
                context.SaveChanges();
            }
        }
    }
}