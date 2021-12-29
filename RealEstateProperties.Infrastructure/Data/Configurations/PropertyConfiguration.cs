using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateProperties.Core.Entitites;

namespace RealEstateProperties.Infrastructure.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(e => e.IdProperty)
                    .HasName("PK__Property__842B6AA789280541");

            builder.ToTable("Property");

            builder.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CodeInternal)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Price).HasColumnType("decimal(19, 4)");

            builder.HasOne(d => d.IdOwnerNavigation)
                .WithMany(p => p.Properties)
                .HasForeignKey(d => d.IdOwner)
                .HasConstraintName("fk_Owner");

        }
    }
}
