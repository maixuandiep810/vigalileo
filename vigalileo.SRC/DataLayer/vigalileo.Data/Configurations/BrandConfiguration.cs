using vigalileo.Data.Entities;
using vigalileo.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace vigalileo.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Name);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnType("nvarchar(1024)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
        }
    }
}
