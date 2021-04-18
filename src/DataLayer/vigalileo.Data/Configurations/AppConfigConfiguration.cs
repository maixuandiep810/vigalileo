using vigalileo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace vigalileo.Data.Configurations
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            builder.ToTable("AppConfigs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("varchar(256)");
            builder.Property(x => x.Value).HasColumnType("ntext").IsRequired(true);
        }
    }
}
