using FONdrum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FONdrum.DataAccess.Configurations.Orders
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .HasOne(oi => oi.Wine)
                .WithMany()
                .HasForeignKey(oi => oi.WineId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
