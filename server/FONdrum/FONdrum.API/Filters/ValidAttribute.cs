using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Request;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FONdrum.API.Filters;

[AttributeUsage(AttributeTargets.Method)]
public class ValidAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ModelState.IsValid == false)
        {
            await HandleValidationErrorAsync(context);
            return;
        }

        await next();
    }

    private static Task HandleValidationErrorAsync(ActionExecutingContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
        ErrorResponse errorResponse = CreateErrorResponse(context.ModelState);
        LogValidationError(context, errorResponse);
        return context.HttpContext.Response.WriteAsJsonAsync(errorResponse);
    }

    private static ErrorResponse CreateErrorResponse(ModelStateDictionary modelState)
    {
        return new ErrorResponse(ErrorCode.ModelInvalid, "The model is not valid.", MapModelStateErrors(modelState));
    }

    private static Dictionary<string, string[]> MapModelStateErrors(ModelStateDictionary modelState)
    {
        var validationErrorsDictionary = new Dictionary<string, string[]>();
        foreach (KeyValuePair<string, ModelStateEntry> msKeyValue in modelState)
        {
            string[] validationErrorMessages = msKeyValue.Value.Errors.Select(x => x.ErrorMessage).ToArray();
            if (validationErrorMessages.Any())
            {
                validationErrorsDictionary.Add(msKeyValue.Key, validationErrorMessages);
            }
        }
        return validationErrorsDictionary;
    }

    private static void LogValidationError(ActionExecutingContext context, ErrorResponse errorResponse)
    {
        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ValidAttribute>>();
        logger.LogError("Action: {ActionName}\nThe model is not valid. {ErrorMessages}",
            context.ActionDescriptor.DisplayName, string.Join(" ", errorResponse.Errors.SelectMany(e => e.Value)));
    }
}
