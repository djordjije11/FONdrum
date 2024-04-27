namespace FONdrum.Domain.Shared.Paginations
{
    public record Paged<TEntity>
    {
        public IList<TEntity> Data { get; init; }
        public PageInfo PageInfo { get; init; }

        public Paged(IList<TEntity> data, PageInfo pageInfo)
        {
            if (data == null)
            {
                throw new ArgumentException();
            }

            Data = data;
            PageInfo = pageInfo;
        }

        public Paged(IList<TEntity> data, long totalCount, int? pageSize, int? pageNumber) 
            : this(data, new(totalCount, pageSize, pageNumber))
        {
        }

        public static Paged<TEntity> Of(IList<TEntity> data, PageInfo pageInfo)
            => new(data, pageInfo);

        public static Paged<TEntity> Empty(int? pageSize = null, int? pageNumber = null) 
            => new(new List<TEntity>(), PageInfo.Empty(pageSize, pageNumber));
    }
}
