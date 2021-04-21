using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace vigalileo.Data.Configurations
{
    public class BrandInCategoryConfiguration : IEntityTypeConfiguration<BrandInCategory>
    {
        public void Configure(EntityTypeBuilder<BrandInCategory> builder)
        {
            builder.ToTable("BrandInCategories");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.CategoryId, x.BrandId });

            builder.HasOne<Brand>(x => x.Brand).WithMany(x => x.BrandInCategories)
                .HasForeignKey(x => x.BrandId);
            builder.HasOne<Category>(x => x.Category).WithMany(x => x.BrandInCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
