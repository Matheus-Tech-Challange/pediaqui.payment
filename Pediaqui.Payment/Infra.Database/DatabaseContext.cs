using Domain.Payment.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infra.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Payment>(c =>
        {
            c.ToCollection("payments");

            c.Property(p => p.PaymentId)
                .HasConversion<string>();

            c.Ignore(p => p.Invalid);
            c.Ignore(p => p.Valid);
            c.Ignore(p => p.Errors);
            c.Property(p => p.Status)
                .HasConversion<string>()
                .IsRequired(true);
        });
    }
}
