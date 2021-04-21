using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace vigalileo.Data.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnType("nvarchar(1024)").IsRequired();
            builder.Property(x => x.Alias).HasColumnType("nvarchar(256)");
            builder.Property(x => x.Description).HasColumnType("ntext");

            builder.HasOne<Brand>(x => x.Brand).WithMany(x => x.Stores).HasForeignKey(x => x.BrandId);
        }
    }
}
