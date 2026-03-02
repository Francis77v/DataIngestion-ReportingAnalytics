using Backend.Domains;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Context;

public class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<StagingImport> StagingImports { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Case> Cases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StagingImport>(entity =>
        {
            entity.ToTable("staging_imports");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Processed)
                .HasDefaultValue(false);
            entity.Property(e => e.ImportedAt)
                .HasDefaultValueSql("NOW()");
        });

        modelBuilder.Entity<Client>()
            .HasOne(c => c.CaseNavigation)
            .WithOne(c => c.ClientNavigation)
            .HasForeignKey<Case>(c => c.Id)
            .IsRequired();
        
    }

 
}
