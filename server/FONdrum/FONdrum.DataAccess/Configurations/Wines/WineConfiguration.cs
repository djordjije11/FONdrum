using FONdrum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FONdrum.DataAccess.Configurations.Wines
{
    public class WineConfiguration : IEntityTypeConfiguration<Wine>
    {
        public void Configure(EntityTypeBuilder<Wine> builder)
        {
            builder
                .Property(w => w.RowVersion)
                .IsRowVersion();

            builder
                .Property(w => w.Name)
                .HasMaxLength(80)
                .IsUnicode();

            builder
                .Property(w => w.Price)
                .HasPrecision(10, 2);

            builder
                .HasOne(w => w.Style)
                .WithMany()
                .HasForeignKey(w => w.StyleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(w => w.Variety)
                .WithMany()
                .HasForeignKey(w => w.VarietyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
