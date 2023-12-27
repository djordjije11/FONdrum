namespace FONdrum.DTO
{
    public record OrderDto(ICollection<OrderItemDto> Items);
}
