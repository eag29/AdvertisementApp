using EmirAliGirgin.AdvertisementApp2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmirAliGirgin.AdvertisementApp2.DAL.Configurations
{
    public class AdvertisementConfigurations : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
