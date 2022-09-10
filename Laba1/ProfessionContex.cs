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
                new MySqlServerVersion(new Version(8, 0, 29))
                );
        }
    }
}
