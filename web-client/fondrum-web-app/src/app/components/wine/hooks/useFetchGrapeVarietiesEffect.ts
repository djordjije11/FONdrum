import { useEffect } from "react";
import { GrapeVarietyCollection } from "../../../models/GrapeVariety";
import getGrapeVarietiesAsync from "../../../services/request/wine/getGrapeVarietiesAsync";

export default function useFetchGrapeVarietiesEffect(
  setGrapeVarietyColleciton: React.Dispatch<
    React.SetStateAction<GrapeVarietyCollection>
  >,
  checkedWineStyleIds: string[]
) {
  useEffect(() => {
    (async () => {
      setGrapeVarietyColleciton(
        await getGrapeVarietiesAsync(checkedWineStyleIds)
      );
    })();
  }, [checkedWineStyleIds, setGrapeVarietyColleciton]);
}
