using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace vigalileo.Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.ProductId, x.LanguageId });

            builder.Property(x => x.Name).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.Alias).HasColumnType("nvarchar(256)");
            builder.Property(x => x.Description).HasColumnType("ntext");
            builder.Property(x => x.LanguageId).HasColumnType("varchar(16)").IsRequired();

            builder.HasOne<Language>(x => x.Language).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.LanguageId);
            builder.HasOne<Product>(x => x.Product).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.ProductId);

        }
    }
}
