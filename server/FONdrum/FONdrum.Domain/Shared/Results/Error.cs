namespace FONdrum.Domain.Shared.Results
{
    public class Error
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }

        public Error(ErrorCode code, string message)
        {
            Code = code;
            Message = message;
        }

        public static Error NotFound(Type type, string identifierName, string identifier)
        {
            return new Error(ErrorCode.NotFound, $"{type.Name} with {identifierName}: {identifier} is not found.");
        }

        public static Error NotFound(Type type, string identifier)
        {
            return NotFound(type, "identifier", identifier);
        }

        public static Error BadRequest(string message)
        {
            return new Error(ErrorCode.BadRequest, message);
        }

        public static Error Outdated()
        {
            return new Error(ErrorCode.Outdated, "You are working with the old version of data.");
        }
    }
}
