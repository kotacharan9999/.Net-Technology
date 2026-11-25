using Microsoft.EntityFrameworkCore;
using Practical11.Models;

namespace Practical11.Data;

public class CampusDbContext : DbContext
{
    public CampusDbContext(DbContextOptions<CampusDbContext> options) : base(options) { }
    public DbSet<CampusServiceRequest> ServiceRequests => Set<CampusServiceRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CampusServiceRequest>().HasIndex(r => r.Email);
        modelBuilder.Entity<CampusServiceRequest>().Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
    }
}
