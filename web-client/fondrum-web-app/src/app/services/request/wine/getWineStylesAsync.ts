import { WineStyleCollection } from "../../../models/WineStyle";
import { API_BASE_URL } from "../apiUrl";

const GET_WINE_STYLES_URL = `${API_BASE_URL}/wine/style`;

export function createFilterByGrapeVarietiesQueryParams(
  grapeVarietyIds: string[]
): string {
  return grapeVarietyIds.map((id) => `varietyId=${id}`).join("&");
}

export default async function getWineStylesAsync(
  grapeVarietyIds: string[]
): Promise<WineStyleCollection> {
  const response = await fetch(
    `${GET_WINE_STYLES_URL}?${createFilterByGrapeVarietiesQueryParams(
      grapeVarietyIds
    )}`
  );
  return await response.json();
}
