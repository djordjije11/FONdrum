import { useEffect } from "react";
import { WineStyleCollection } from "../../../models/WineStyle";
import getWineStylesAsync from "../../../services/request/wine/getWineStylesAsync";

export default function useFetchWineStylesEffect(
  setWineStyleCollection: React.Dispatch<
    React.SetStateAction<WineStyleCollection>
  >,
  setCheckedWineStyleIds: React.Dispatch<React.SetStateAction<string[]>>,
  checkedGrapeVarietyIds: string[]
) {
  useEffect(() => {
    (async () => {
      const wineStyleCollection = await getWineStylesAsync(
        checkedGrapeVarietyIds
      );
      setWineStyleCollection(wineStyleCollection);
      setCheckedWineStyleIds((prev) => {
        const curr = prev.filter(
          (cws) =>
            wineStyleCollection.wineStyles.find((ws) => ws.id === cws) !==
            undefined
        );
        if (curr.length === prev.length) {
          return prev;
        }
        return curr;
      });
    })();
  }, [checkedGrapeVarietyIds, setCheckedWineStyleIds, setWineStyleCollection]);
}
