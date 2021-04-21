using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace vigalileo.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            // builder.Property(x => x.Id).ValueGeneratedOnAdd();
            // //  .HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Price).HasColumnType("decimal").IsRequired();

            builder.HasOne<Product>(x => x.Product).WithMany(x => x.Carts).HasForeignKey(x => x.ProductId);
            builder.HasOne<CustomerDetail>(x => x.CustomerDetail).WithMany(x => x.Carts).HasForeignKey(x => x.UserId);
        }
    }
}
