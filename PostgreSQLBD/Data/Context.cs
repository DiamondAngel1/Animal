using PostgreSQLBD.Data.Entitis;
using Microsoft.EntityFrameworkCore;
namespace PostgreSQLBD.Data{
    public class Context : DbContext{
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseNpgsql("Host=ep-restless-tree-a87x17dk-pooler.eastus2.azure.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_Xw3F4AUMkluV");
        }
    }
}