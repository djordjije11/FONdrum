import { useEffect } from "react";
import { Wine } from "../../../models/Wine";
import { PageQueryParams } from "../../../models/shared/pagination/PageQueryParams";
import { Paged } from "../../../models/shared/pagination/Paged";
import getWinesAsync from "../../../services/request/wine/getWinesAsync";

export default function useFetchWinesOnFilterChangeEffect(
  setPagedWine: React.Dispatch<React.SetStateAction<Paged<Wine>>>,
  checkedWineStyleIds: string[],
  checkedGrapeVarietyIds: string[],
  pageQueryParams: PageQueryParams,
  setPageQueryParams: React.Dispatch<React.SetStateAction<PageQueryParams>>
) {
  useEffect(() => {
    (async () => {
      if (pageQueryParams.pageNumber === 1) {
        setPagedWine(
          await getWinesAsync(
            checkedWineStyleIds,
            checkedGrapeVarietyIds,
            pageQueryParams
          )
        );
        return;
      }
      setPageQueryParams((prev) => ({ ...prev, pageNumber: 1 }));
    })();
  }, [
    setPagedWine,
    checkedWineStyleIds,
    checkedGrapeVarietyIds,
    setPageQueryParams,
  ]);
}
