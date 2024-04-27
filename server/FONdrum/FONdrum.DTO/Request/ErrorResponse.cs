using FONdrum.Domain.Shared.Results;

namespace FONdrum.DTO.Request
{
    public record ErrorResponse(ErrorCode ErrorCode, string Message, IDictionary<string, string[]> Errors)
    {
        public static ErrorResponse Create(Error error)
        {
            return new(error.Code, error.Message, new Dictionary<string, string[]>());
        }
    }
}
