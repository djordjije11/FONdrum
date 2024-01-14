namespace FONdrum.Domain.Shared.Paginations
{
    public record PageInfo
    {
        public long TotalCount { get; init; }
        public int? PageSize { get; init; }
        public int? PageNumber { get; init; }

        public long? PagesCount => PageSize.HasValue ? (TotalCount + PageSize.Value - 1) / PageSize.Value : null;
        
        public PageInfo(long totalCount, int? pageSize, int? pageNumber)
        {
            if (totalCount < 0 || pageSize < 0 || pageNumber < 0)
                throw new ArgumentException($"Arguments {nameof(totalCount)}, {nameof(pageSize)}, {nameof(pageNumber)}" +
                    $" must be greater than or equal to 0.");

            TotalCount = totalCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public static PageInfo Empty(int? pageSize = null, int? pageNumber = null) => new PageInfo(0, pageSize, pageNumber);
    }
}
