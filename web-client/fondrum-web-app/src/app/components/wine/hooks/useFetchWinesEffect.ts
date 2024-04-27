import { useEffect } from "react";
import { PageQueryParams } from "../../../models/shared/pagination/PageQueryParams";
import getWinesAsync from "../../../services/request/wine/getWinesAsync";
import { Paged } from "../../../models/shared/pagination/Paged";
import { Wine } from "../../../models/Wine";

export default function useFetchWinesEffect(
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
