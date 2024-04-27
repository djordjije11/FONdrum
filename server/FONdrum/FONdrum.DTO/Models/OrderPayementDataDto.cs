namespace FONdrum.DTO.Models;

public record OrderPayementDataDto(string OrderID, string? PayerID, string? PaymentID, string? PayerEmailAddress, string? PayerName);