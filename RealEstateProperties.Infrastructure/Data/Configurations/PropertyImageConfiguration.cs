using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateProperties.Core.Entitites;

namespace RealEstateProperties.Infrastructure.Data.Configurations
{
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.HasKey(e => e.IdPropertyImage)
                    .HasName("PK__Property__018BACD5F2BD7267");

            builder.ToTable("PropertyImage");

            builder.Property(e => e.File)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdPropertyNavigation)
                .WithMany(p => p.PropertyImages)
                .HasForeignKey(d => d.IdProperty)
                .HasConstraintName("fk_Property_PropertyImage");
        }
    }
}
