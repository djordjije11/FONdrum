namespace FONdrum.DTO.Models
{
    public record OrderDto(ICollection<OrderItemDto> Items, string BuyerName, string BuyerPhoneNumber, string BuyerAddress);
}
