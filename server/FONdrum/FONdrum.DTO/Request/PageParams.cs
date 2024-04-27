using Microsoft.AspNetCore.Mvc;

namespace FONdrum.DTO.Request
{
    public record PageParams
    {
        [BindProperty(Name = "page_size")]
        public int PageSize { get; init; } = 10;
        [BindProperty(Name = "page_number")]
        public int PageNumber { get; init; } = 1;
    }
}
