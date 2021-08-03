using Bicicletaria_ploomes.Models;
using Microsoft.EntityFrameworkCore;

namespace Bicicletaria_ploomes.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<Product> Product { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Product>(entity =>
      {
        entity.HasKey(p => p.Id);
        entity.Property(p => p.NameProduct).IsRequired().HasMaxLength(255);
        entity.Property(p => p.Description).HasMaxLength(450);
        entity.Property(p => p.Size).IsRequired().HasMaxLength(30);
        entity.Property(p => p.Value).IsRequired().HasPrecision(16, 2);
        entity.Property(p => p.DateCreate).IsRequired();
        entity.Property(p => p.RecordIdentifier).IsRequired();
        entity.Property(p => p.CreatorUserId).IsRequired();
      });

      modelBuilder.Entity<User>(entity =>
      {
        entity.HasKey(u => u.Id);
        entity.Property(u => u.UserName).IsRequired().HasMaxLength(250);
        entity.Ignore(u => u.Product);
        entity.HasMany(u => u.Product).WithOne().HasForeignKey(p => p.CreatorUserId);
      }
      );
    }
  }
}