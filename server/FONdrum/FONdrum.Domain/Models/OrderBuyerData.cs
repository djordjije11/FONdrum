namespace FONdrum.Domain.Models;

public struct OrderBuyerData
{
    public string Name;
    public string PhoneNumber;
    public string Address;

    public OrderBuyerData(string name, string phoneNumber, string address)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
    }
}
