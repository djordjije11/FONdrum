import { Paged } from "../../../models/shared/pagination/Paged";
import {
  createPageQuery,
  PageQueryParams,
} from "../../../models/shared/pagination/PageQueryParams";
import { Wine } from "../../../models/Wine";
import { API_BASE_URL } from "../apiUrl";
import { getPageInfo } from "../responseHeaders";
import { createFilterByWineStylesQueryParams } from "./getGrapeVarietiesAsync";
import { createFilterByGrapeVarietiesQueryParams } from "./getWineStylesAsync";

const GET_WINES_URL = `${API_BASE_URL}/wine`;

function createWineQuery(
  wineStyleIds: string[],
  grapeVarietyIds: string[]
): string {
  const filters: string[] = [];
  const filterByWineStyleQueryParams =
    createFilterByWineStylesQueryParams(wineStyleIds);
  if (filterByWineStyleQueryParams) {
    filters.push(filterByWineStyleQueryParams);
  }
  const filterByGrapeVarietiesQueryParams =
    createFilterByGrapeVarietiesQueryParams(grapeVarietyIds);
  if (filterByGrapeVarietiesQueryParams) {
    filters.push(filterByGrapeVarietiesQueryParams);
  }
  return filters.join("&");
}

export default async function getWinesAsync(
  wineStyleIds: string[],
  grapeVarietyIds: string[],
  pageQueryParams: PageQueryParams
): Promise<Paged<Wine>> {
  const queryParams: string[] = [
    createPageQuery(pageQueryParams),
    createWineQuery(wineStyleIds, grapeVarietyIds),
  ];
  const query: string = queryParams.join("&");
  const response = await fetch(`${GET_WINES_URL}?${query}`);
  const data = await response.json();
  const pageInfo = getPageInfo(response.headers);
  return {
    data,
    pageInfo,
  };
}
