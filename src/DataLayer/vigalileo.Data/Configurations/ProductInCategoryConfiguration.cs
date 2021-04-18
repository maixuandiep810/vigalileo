using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace vigalileo.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.CategoryId, x.ProductId });

            builder.HasOne<Product>(x => x.Product).WithMany(x => x.ProductInCategories)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne<Category>(x => x.Category).WithMany(x => x.ProductInCategories)
              .HasForeignKey(x => x.CategoryId);
        }
    }
}
