using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateProperties.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Infrastructure.Data.Configurations
{
    public  class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.HasKey(e => e.IdOwner)
                    .HasName("PK__Owner__D3261816016F7CCE");

            builder.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Birthday).HasColumnType("date");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Photo)
                .HasMaxLength(100)
                .IsUnicode(false);
        }

    }
}
