using Animal.infrastructure.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Animal.infrastructure{
    public class AnimalContext : DbContext{
        public DbSet<Specie> Species { get; set; }
        public DbSet<Animais> Animals { get; set; }
        public AnimalContext()
        {

        }
        public AnimalContext(DbContextOptions<AnimalContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=ep-restless-bush-a8n1a3jt-pooler.eastus2.azure.neon.tech;Database=Animal;Username=Animal_owner;Password=npg_lM2mhEuYW4dN");
        }
    }
}
