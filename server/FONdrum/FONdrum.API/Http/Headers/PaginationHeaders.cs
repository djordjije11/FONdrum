namespace FONdrum.API.Http.Headers
{
    public static class PaginationHeaders
    {
        public const string CURRENT_PAGE = "X-Pagination-Current-Page";
        public const string PER_PAGE = "X-Pagination-Per-Page";
        public const string TOTAL_PAGES = "X-Pagination-Total-Pages";
        public const string TOTAL_ENTRIES = "X-Pagination-Total-Entries";

        public static string[] Get() => [ CURRENT_PAGE, PER_PAGE, TOTAL_PAGES, TOTAL_ENTRIES ];
    }
}
