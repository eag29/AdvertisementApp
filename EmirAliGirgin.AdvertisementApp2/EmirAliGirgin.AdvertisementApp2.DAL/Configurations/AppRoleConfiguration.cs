using EmirAliGirgin.AdvertisementApp2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.DAL.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(250).IsRequired();
            builder.HasData(new AppRole[]
            {
                new()
                {
                    Id=1,
                    Definition="Member",
                },

                new()
                {
                    Id=2,
                    Definition ="Admin",
                },
            });
        }
    }
}
