namespace FONdrum.Domain.Shared.Results
{
    public interface IOperationResult
    {
        public bool IsError { get; }
        public Error? Error { get; }
    }
}
