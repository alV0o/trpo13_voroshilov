using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo12_voroshilov.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=trpo12_voroshilov_db;User Id=student_08;Password=student_08;TrustServerCertificate=True;");
        }
    }
}
