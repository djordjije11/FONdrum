using FONdrum.DTO.Request;

namespace FONdrum.API.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (OperationCanceledException ex)
            {
                await HandleExceptionAsync(context, ex, LogLevel.Error, StatusCodes.Status404NotFound,
                    new MessageResponse("The action is canceled."));
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, LogLevel.Critical, StatusCodes.Status500InternalServerError,
                    new MessageResponse("The action is not done successfully."));
            }
        }

        private void LogException(LogLevel logLevel, Exception ex)
        {
            _logger.Log(logLevel, "{DateTime}: {ThisObject}\nException: {Exception}; Message: {Message}; StackTrace: \n{StackTrace}",
                DateTime.UtcNow, this, ex.GetType(), ex.Message + (" " + ex.InnerException?.Message ?? string.Empty), ex.StackTrace);
        }

        private async Task HandleExceptionAsync<TBody>(HttpContext context, Exception ex, LogLevel logLevel, int statusCode, TBody bodyObject)
        {
            LogException(logLevel, ex);
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(bodyObject);
        }
    }
}
