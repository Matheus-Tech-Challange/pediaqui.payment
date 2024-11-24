using Domain.Payment.Entities;
using Infra.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.Configurations;

public class PaymentConfiguration : BaseEntityConfiguration<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);

        builder
            .Property(p => p.Guid)
            .HasColumnType("char(36)")
            .IsRequired(true);

        builder
            .HasIndex(p => p.Guid)
            .IsUnique(true);

        builder
            .Property(p => p.PedidoId)
            .IsRequired(true);

        builder
            .HasIndex(p => p.PedidoId)
            .IsUnique();

        builder
            .Property(p => p.Status)
            .HasConversion<string>()
            .IsRequired(true);

        builder
            .Property(p => p.Valor)
            .HasColumnType("decimal(18,2)")
            .IsRequired(true);

    }
}
