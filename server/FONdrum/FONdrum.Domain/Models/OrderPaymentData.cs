namespace FONdrum.Domain.Models;

public struct OrderPaymentData
{
    public string? OrderID;
    public string? PayerID;
    public string? PaymentID;
    public string? PayerEmailAddress;
    public string? PayerName;

    public static OrderPaymentData Empty() => new OrderPaymentData(null, null, null, null, null);

    public OrderPaymentData(string? orderID, string? payerID, string? paymentID, string? payerEmailAddress, string? payerName)
    {
        OrderID = orderID;
        PayerID = payerID;
        PaymentID = paymentID;
        PayerEmailAddress = payerEmailAddress;
        PayerName = payerName;
    }
}
