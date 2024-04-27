export type PageQueryParams = {
  pageSize: number;
  pageNumber: number;
};

export function createPageQuery(pageQueryParams: PageQueryParams): string {
  return `page_size=${pageQueryParams.pageSize}&page_number=${pageQueryParams.pageNumber}`;
}
