namespace FONdrum.Domain.Shared.Results
{
    public interface IResult
    {
        public bool IsError { get; }
        public Error? Error { get; }
    }
}
