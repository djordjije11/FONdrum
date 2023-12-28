using FONdrum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FONdrum.DataAccess.Configurations.Wines
{
    public class WineStyleConfiguration : IEntityTypeConfiguration<WineStyle>
    {
        public void Configure(EntityTypeBuilder<WineStyle> builder)
        {
            builder
               .Property(ws => ws.Name)
               .HasMaxLength(40)
               .IsUnicode();

            builder.HasIndex(ws => ws.Name).IsUnique();
        }
    }
}
