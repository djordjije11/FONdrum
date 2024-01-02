import { PageInfo, _defaultPageInfo } from "./PageInfo";

export type Paged<T> = {
  data: T[];
  pageInfo: PageInfo;
};

export function _getDefaultPaged<T>(): Paged<T> {
  return {
    data: [] as T[],
    pageInfo: _defaultPageInfo,
  };
}
