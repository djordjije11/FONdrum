import { Wine } from "../../../models/Wine";
import { API_BASE_URL } from "../apiUrl";
import { createFilterByWineStylesQueryParams } from "./getGrapeVarietiesAsync";
import { createFilterByGrapeVarietiesQueryParams } from "./getWineStylesAsync";

const GET_WINES_URL = `${API_BASE_URL}/wine`;

function createWineQueryParams(
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
  grapeVarietyIds: string[]
): Promise<Wine[]> {
  const response = await fetch(
    `${GET_WINES_URL}?${createWineQueryParams(wineStyleIds, grapeVarietyIds)}`
  );
  return await response.json();
}
