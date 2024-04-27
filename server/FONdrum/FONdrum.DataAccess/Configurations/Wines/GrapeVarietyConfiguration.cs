using FONdrum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FONdrum.DataAccess.Configurations.Wines
{
    public class GrapeVarietyConfiguration : IEntityTypeConfiguration<GrapeVariety>
    {
        public void Configure(EntityTypeBuilder<GrapeVariety> builder)
        {
            builder
                .Property(gv => gv.Name)
                .HasMaxLength(60)
                .IsUnicode();

            builder.HasIndex(gv => gv.Name).IsUnique();
        }
    }
}
