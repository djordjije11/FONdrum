using FONdrum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FONdrum.DataAccess.Configurations.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .Property(o => o.Date)
                .HasDefaultValueSql("getutcdate()")
                .ValueGeneratedOnAdd();
            builder
                .Property(o => o.Status)
                .HasConversion<string>();
            builder
                .ComplexProperty(o => o.BuyerData);
            builder
                .ComplexProperty(o => o.PaymentData);
        }
    }
}
