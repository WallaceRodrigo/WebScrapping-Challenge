using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Models
{
  public class AlimentContext : DbContext
  {
    public DbSet<IAliment> aliment { get; set; }

    public AlimentContext(DbContextOptions<AlimentContext> options) : base(options){ }

    public AlimentContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost;Database=WebScrappingDB;User=sa;Password=SqlServer123!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
  }
}