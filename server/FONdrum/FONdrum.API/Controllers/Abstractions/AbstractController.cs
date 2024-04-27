using FONdrum.API.Http.Headers;
using FONdrum.Domain.Shared.Paginations;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace FONdrum.API.Controllers.Abstractions
{
    [ApiController]
    public abstract class AbstractController : ControllerBase
    {
        protected ActionResult HandleError(Error? error)
        {
            if (error == null)
                return BadRequest();

            var errorResponse = ErrorResponse.Create(error);
            return errorResponse.ErrorCode switch
            {
                ErrorCode.NotFound => NotFound(errorResponse),
                ErrorCode.BadRequest => BadRequest(errorResponse),
                ErrorCode.Outdated => BadRequest(errorResponse),
                _ => BadRequest(errorResponse)
            };
        }

        protected void AddPaginationHeaders(PageInfo pageInfo)
        {
            this.HttpContext.Response.Headers.Append(PaginationHeaders.CURRENT_PAGE, pageInfo.PageNumber.ToString());
            this.HttpContext.Response.Headers.Append(PaginationHeaders.PER_PAGE, pageInfo.PageSize.ToString());
            this.HttpContext.Response.Headers.Append(PaginationHeaders.TOTAL_PAGES, pageInfo.PagesCount.ToString());
            this.HttpContext.Response.Headers.Append(PaginationHeaders.TOTAL_ENTRIES, pageInfo.TotalCount.ToString());
        }
    }
}
