using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using vigalileo.Data.Enums;

namespace vigalileo.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Amount).HasColumnType("decimal(10,8)");
            // builder.Property(x => x.ShipEmail).IsRequired().IsUnicode(false).HasMaxLength(50);
            // builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(200);
            // builder.Property(x => x.ShipName).IsRequired().HasMaxLength(200);
            // builder.Property(x => x.ShipPhoneNumber).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Status).HasDefaultValue(OrderStatus.InProgress);


            builder.HasOne<CustomerDetail>(x => x.CustomerDetail).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerDetailId);
            builder.HasOne<Transaction>(x => x.Transaction).WithOne(x => x.Order).HasForeignKey<Transaction>(x => x.OrderId);
        }
    }
}
