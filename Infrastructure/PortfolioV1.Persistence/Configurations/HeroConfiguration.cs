using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioV1.Domain.Entities;

namespace PortfolioV1.Persistence.Configurations;

public class HeroConfiguration : BaseConfiguration<Hero>
{
    public override void Configure(EntityTypeBuilder<Hero> builder)
    {
        base.Configure(builder);
        //builder.HasKey(x => x.Id);
    }
}
