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
        // Ovo treba samo ako se u dependencies za useFetchWinesEffect doda checkedWineStyleIds i checkedGrapeVarietyIds
        // if (prev.pageNumber === 1) {
        //   return prev;
        // }
        return { ...prev, pageNumber: 1 };
      });
    })();
  }, [checkedWineStyleIds, checkedGrapeVarietyIds, setPageQueryParams]);
}
