using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models;

public partial class WebScrappingDbContext : DbContext
{
  public WebScrappingDbContext()
  {
  }

  public WebScrappingDbContext(DbContextOptions<WebScrappingDbContext> options)
      : base(options)
  {
  }

  public virtual DbSet<IAliment> Aliments { get; set; }
  public virtual DbSet<ISingleComponent> SingleComponent { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Server=localhost;Database=WebScrappingDB;User=SA;Password=Password123;TrustServerCertificate=True");

  protected override void OnModelCreating(ModelBuilder modelBuilder) { }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
