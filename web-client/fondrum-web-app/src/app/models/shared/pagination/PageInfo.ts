export type PageInfo = {
  totalItemsCount: number;
  totalPagesCount: number;
  pageSize: number;
  pageNumber: number;
};

export const _defaultPageInfo: PageInfo = {
  pageNumber: 1,
  pageSize: 8,
  totalItemsCount: 0,
  totalPagesCount: 0,
};
