import { useEffect } from "react";
import { PageQueryParams } from "../../../models/shared/pagination/PageQueryParams";

export default function useChangePageQueryParamsOnFilterChangeEffect(
  setPageQueryParams: React.Dispatch<React.SetStateAction<PageQueryParams>>,
  checkedWineStyleIds: string[],
  checkedGrapeVarietyIds: string[]
) {
  useEffect(() => {
    (async () => {
      setPageQueryParams((prev) => {
        return { ...prev, pageNumber: 1 };
      });
    })();
  }, [checkedWineStyleIds, checkedGrapeVarietyIds, setPageQueryParams]);
}
