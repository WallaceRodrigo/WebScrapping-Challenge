using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
  public class AlimentContext : DbContext
  {
    public DbSet<string>? id { get; set; }
    public DbSet<string>? name { get; set; }
    public DbSet<string>? scientificName { get; set; }
    public DbSet<string>? group { get; set; }
    public DbSet<string>? brand { get; set; }
    public IEnumerable<Dictionary<string, string>>? components { get; set; }

    public AlimentContext(DbContextOptions<AlimentContext> options) : base(options){ }

    public AlimentContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost;Database=WebScrappingDB;User=SA;Password=SqlServer123!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
  }
}