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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(6).IsRequired();

            builder.HasOne(x => x.Gender).WithMany(x => x.AppUsers).HasForeignKey(x => x.GenderId);
        }
    }
}
