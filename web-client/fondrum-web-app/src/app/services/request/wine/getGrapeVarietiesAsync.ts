import { GrapeVarietyCollection } from "../../../models/GrapeVariety";
import { API_BASE_URL } from "../apiUrl";

const GET_GRAPE_VARIETIES_URL = `${API_BASE_URL}/wine/variety`;

export function createFilterByWineStylesQueryParams(
  wineStyleIds: string[]
): string {
  return wineStyleIds.map((id) => `styleId=${id}`).join("&");
}

export default async function getGrapeVarietiesAsync(
  wineStyleIds: string[]
): Promise<GrapeVarietyCollection> {
  const response = await fetch(
    `${GET_GRAPE_VARIETIES_URL}?${createFilterByWineStylesQueryParams(
      wineStyleIds
    )}`
  );
  return await response.json();
}
