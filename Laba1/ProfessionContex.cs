using Microsoft.EntityFrameworkCore;

namespace Laba1
{
    public class ProfessionContex : DbContext
    {
        public ProfessionContex()
        {
            Database.EnsureCreated();
        }
        public DbSet<Profession> Professions { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=password;database=professions;",
                //"server=mysql5042.site4now.net;Uid=a8d23c_db;password=password1;database= db_a8d23c_db;", // Удаленнаяя бд
                new MySqlServerVersion(new Version(8, 0, 29))
                );
        }
    }
}
