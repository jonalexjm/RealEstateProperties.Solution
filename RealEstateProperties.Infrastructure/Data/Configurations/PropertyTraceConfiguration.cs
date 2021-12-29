using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateProperties.Core.Entitites;


namespace RealEstateProperties.Infrastructure.Data.Configurations
{
    public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.HasKey(e => e.IdPropertyTrace)
                    .HasName("PK__Property__373407C9C5AE3A7A");

            builder.ToTable("PropertyTrace");

            builder.Property(e => e.DataSale).HasColumnType("date");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Tax).HasColumnType("decimal(19, 4)");

            builder.Property(e => e.Value).HasColumnType("decimal(19, 4)");

            builder.HasOne(d => d.IdPropertyNavigation)
                .WithMany(p => p.PropertyTraces)
                .HasForeignKey(d => d.IdProperty)
                .HasConstraintName("fk_Property_PropertyTrace");
        }
    }
}
