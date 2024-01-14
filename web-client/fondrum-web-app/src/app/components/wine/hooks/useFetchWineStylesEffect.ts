import { useEffect } from "react";
import { WineStyleCollection } from "../../../models/WineStyle";
import getWineStylesAsync from "../../../services/request/wine/getWineStylesAsync";

export default function useFetchWineStylesEffect(
  setWineStyleCollection: React.Dispatch<
    React.SetStateAction<WineStyleCollection>
  >,
  checkedGrapeVarietyIds: string[]
) {
  useEffect(() => {
    (async () => {
      const wineStyleCollection = await getWineStylesAsync(
        checkedGrapeVarietyIds
      );
      setWineStyleCollection(wineStyleCollection);
    })();
  }, [checkedGrapeVarietyIds, setWineStyleCollection]);
}
