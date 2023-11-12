using Core.Entities;
using Infrastructure.Data.EntitiesConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Shared.AppConstant;

namespace Infrastructure.Data.EntitiesConfiguration;

internal class OrderTypeEntityConfiguration : BaseEntityConfiguration<OrderTypeEntity>
{
    public override void Configure(EntityTypeBuilder<OrderTypeEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(p => p.Name)
            .HasMaxLength(Length.L2)
            .IsRequired();
    }
}
