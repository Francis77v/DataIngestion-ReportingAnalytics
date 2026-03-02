using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Context;

public partial class MyDbContext : DbContext
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
        OnModelCreatingPartial(modelBuilder);
        
        modelBuilder.Entity<StagingImport>(entity =>
        {
            entity.ToTable("staging_imports");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.RawData)
                .HasColumnType("jsonb");
            entity.Property(e => e.Processed)
                .HasDefaultValue(false);
            entity.Property(e => e.ImportedAt)
                .HasDefaultValueSql("NOW()");
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
