using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace vigalileo.Data.Configurations
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslations");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.CategoryId, x.LanguageId });

            builder.Property(x => x.Name).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("ntext");
            builder.Property(x => x.LanguageId).HasColumnType("varchar(16)").IsRequired();

            builder.HasOne<Language>(x => x.Language).WithMany(x => x.CategoryTranslations).HasForeignKey(x => x.LanguageId);
            builder.HasOne<Category>(x => x.Category).WithMany(x => x.CategoryTranslations).HasForeignKey(x => x.CategoryId);
        }
    }
}
