using FONdrum.Domain.Shared.Paginations;
using FONdrum.Domain.Shared.Results;
using FONdrum.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace FONdrum.API.Controllers.Abstractions
{
    [ApiController]
    public abstract class AbstractController : ControllerBase
    {
        public const string PAGINATION_CURRENT_PAGE = "X-Pagination-Current-Page";
        public const string PAGINATION_PER_PAGE = "X-Pagination-Per-Page";
        public const string PAGINATION_TOTAL_PAGES = "X-Pagination-Total-Pages";
        public const string PAGINATION_TOTAL_ENTRIES = "X-Pagination-Total-Entries";

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
            this.HttpContext.Response.Headers.Append(PAGINATION_CURRENT_PAGE, pageInfo.PageNumber.ToString());
            this.HttpContext.Response.Headers.Append(PAGINATION_PER_PAGE, pageInfo.PageSize.ToString());
            this.HttpContext.Response.Headers.Append(PAGINATION_TOTAL_PAGES, pageInfo.PagesCount.ToString());
            this.HttpContext.Response.Headers.Append(PAGINATION_TOTAL_ENTRIES, pageInfo.TotalCount.ToString());
        }
    }
}
