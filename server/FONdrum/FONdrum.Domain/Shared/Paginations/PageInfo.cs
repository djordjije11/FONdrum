namespace FONdrum.Domain.Shared.Paginations
{
    public record PageInfo
    {
        public long TotalCount { get; init; }
        public int? PageSize { get; init; }
        public int? PageNumber { get; init; }

        public PageInfo(long totalCount, int? pageSize, int? pageNumber)
        {
            if (totalCount < 0 || pageSize < 0 || pageNumber < 0)
            {
                throw new ArgumentException();
            }

            TotalCount = totalCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public static PageInfo Empty(int? pageSize = null, int? pageNumber = null) => new PageInfo(0, pageSize, pageNumber);

        public long? PagesCount => PageSize.HasValue ? TotalCount / PageSize.Value : null;
    }
}
