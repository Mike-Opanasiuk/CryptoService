using Core.Entities;
using Infrastructure.Data.EntitiesConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Shared.AppConstant;

namespace Infrastructure.Data;

internal class CurrencyEntityConfiguration : BaseEntityConfiguration<CurrencyEntity>
{
    public override void Configure(EntityTypeBuilder<CurrencyEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(p => p.Name)
            .HasMaxLength(Length.L4)
            .IsRequired();
    }
}
