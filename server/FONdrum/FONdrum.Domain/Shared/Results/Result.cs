namespace FONdrum.Domain.Shared.Results
{
    public class Result<T> : IResult
    {
        public bool IsError { get; set; }
        public Error? Error { get; set; }
        public T? Payload { get; set; }

        private Result() { }
        private Result(T? payload = default)
        {
            Payload = payload;
        }
        protected Result(Error? error = null)
        {
            IsError = true;
            Error = error;
        }
        private Result(IResult result)
        {
            IsError = result.IsError;
            Error = result.Error;
        }

        public static Result<T> Success() => new();
        public static Result<T> Success(T? payload = default) => new(payload);
        public static Result<T> Failure() => new() { IsError = true };
        public static Result<T> Failure(ErrorCode code, string message) => new(new Error(code, message));
        public static Result<T> Failure(Error? error = null) => new(error);

        public static implicit operator Result<T>(T payload) => Success(payload);
        public static implicit operator Result<T>(Result result) => new(result);
        public static implicit operator Result<T>(Error? error) => new(error);
    }

    public class Result : IResult
    {
        public bool IsError { get; set; }
        public Error? Error { get; set; }

        private Result() { }
        private Result(Error? error = null)
        {
            IsError = true;
            Error = error;
        }

        public static Result Success() => new();
        public static Result Failure() => new() { IsError = true };
        public static Result Failure(ErrorCode code, string message) => new(new(code, message));
        public static Result Failure(Error? error = null) => new(error);

        public static implicit operator Result(Error? error) => new(error);
    }
}
