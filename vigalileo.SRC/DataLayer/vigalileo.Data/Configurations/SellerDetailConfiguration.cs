using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace vigalileo.Data.Configurations
{
    public class SellerDetailConfiguration : IEntityTypeConfiguration<SellerDetail>
    {
        public void Configure(EntityTypeBuilder<SellerDetail> builder)
        {
            builder.ToTable("SellerDetails");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.ApplicationUserId);

            builder.HasOne<Store>(x => x.Store).WithMany(x => x.SellerDetails).HasForeignKey(x => x.StoreId);
        }
    }
}
