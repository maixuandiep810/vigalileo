using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace vigalileo.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");

            builder.Property(x => x.FirstName).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.LastName).HasColumnType("nvarchar(256)").IsRequired();
            // builder.Property(x => x.Dob).IsRequired();

            builder.HasOne<CustomerDetail>(x => x.CustomerDetail).WithOne(x => x.ApplicationUser).HasForeignKey<CustomerDetail>(x => x.ApplicationUserId);
            builder.HasOne<SellerDetail>(x => x.SellerDetail).WithOne(x => x.ApplicationUser).HasForeignKey<SellerDetail>(x => x.ApplicationUserId);
        }
    }
}
