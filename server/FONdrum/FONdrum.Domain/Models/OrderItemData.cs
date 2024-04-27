namespace FONdrum.Domain.Models;

public record OrderItemData(Guid WineId, byte[] WineRowVersion, int Amount);
