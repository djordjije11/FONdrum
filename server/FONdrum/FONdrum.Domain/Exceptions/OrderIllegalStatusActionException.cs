namespace FONdrum.Domain.Exceptions;

public class OrderIllegalStatusActionException : Exception
{
    public OrderIllegalStatusActionException(string message): base(message)
    {
    }
}
