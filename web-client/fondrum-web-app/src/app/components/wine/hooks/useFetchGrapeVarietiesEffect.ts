import { useEffect } from "react";
import { GrapeVarietyCollection } from "../../../models/GrapeVariety";
import getGrapeVarietiesAsync from "../../../services/request/wine/getGrapeVarietiesAsync";

export default function useFetchGrapeVarietiesEffect(
  setGrapeVarietyColleciton: React.Dispatch<
    React.SetStateAction<GrapeVarietyCollection>
  >,
  setCheckedGrapeVarietyIds: React.Dispatch<React.SetStateAction<string[]>>,
  checkedWineStyleIds: string[]
) {
  useEffect(() => {
    (async () => {
      const grapeVarietyCollection = await getGrapeVarietiesAsync(
        checkedWineStyleIds
      );
      setGrapeVarietyColleciton(grapeVarietyCollection);
      setCheckedGrapeVarietyIds((prev) => {
        const curr = prev.filter(
          (cgv) =>
            grapeVarietyCollection.grapeVarieties.find(
              (gv) => gv.id === cgv
            ) !== undefined
        );
        if (curr.length === prev.length) {
          return prev;
        }
        return curr;
      });
    })();
  }, [
    checkedWineStyleIds,
    setCheckedGrapeVarietyIds,
    setGrapeVarietyColleciton,
  ]);
}
