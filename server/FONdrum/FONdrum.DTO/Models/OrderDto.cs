namespace FONdrum.DTO.Models
{
    public record OrderDto(ICollection<OrderItemDto> Items);
}
