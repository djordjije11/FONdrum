import { useEffect } from "react";
import { Wine } from "../../../models/Wine";
import { PageQueryParams } from "../../../models/shared/pagination/PageQueryParams";
import { Paged } from "../../../models/shared/pagination/Paged";
import getWinesAsync from "../../../services/request/wine/getWinesAsync";

export default function useFetchWinesOnPageQueryParamsChangeEffect(
  setPagedWine: React.Dispatch<React.SetStateAction<Paged<Wine>>>,
  checkedWineStyleIds: string[],
  checkedGrapeVarietyIds: string[],
  pageQueryParams: PageQueryParams
) {
  useEffect(() => {
    (async () => {
      setPagedWine(
        await getWinesAsync(
          checkedWineStyleIds,
          checkedGrapeVarietyIds,
          pageQueryParams
        )
      );
    })();
  }, [pageQueryParams, setPagedWine]);
}
