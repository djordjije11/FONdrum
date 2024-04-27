import { PageInfo } from "../../models/shared/pagination/PageInfo";

const PAGINATION_CURRENT_PAGE_HEADER = "X-Pagination-Current-Page";
const PAGINATION_PER_PAGE_HEADER = "X-Pagination-Per-Page";
const PAGINATION_TOTAL_PAGES_HEADER = "X-Pagination-Total-Pages";
const PAGINATION_TOTAL_ENTRIES_HEADER = "X-Pagination-Total-Entries";

export function getPageInfo(headers: Headers): PageInfo {
  return {
    pageNumber: Number(headers.get(PAGINATION_CURRENT_PAGE_HEADER)),
    pageSize: Number(headers.get(PAGINATION_PER_PAGE_HEADER)),
    totalItemsCount: Number(headers.get(PAGINATION_TOTAL_ENTRIES_HEADER)),
    totalPagesCount: Number(headers.get(PAGINATION_TOTAL_PAGES_HEADER)),
  };
}
