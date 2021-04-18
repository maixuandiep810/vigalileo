using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace vigalileo.Data.Configurations
{
    public class StoreInOrderConfiguration : IEntityTypeConfiguration<StoreInOrder>
    {
        public void Configure(EntityTypeBuilder<StoreInOrder> builder)
        {
            builder.ToTable("StoreInOrders");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.StoreId, x.OrderId });

            builder.HasOne<Store>(x => x.Store).WithMany(x => x.StoreInOrders)
                .HasForeignKey(x => x.StoreId);
            builder.HasOne<Order>(x => x.Order).WithMany(x => x.StoreInOrders)
                .HasForeignKey(x => x.OrderId);
            builder.HasOne<SellerDetail>(x => x.SellerDetail).WithMany(x => x.StoreInOrders)
                .HasForeignKey(x => x.SellerDetailId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
