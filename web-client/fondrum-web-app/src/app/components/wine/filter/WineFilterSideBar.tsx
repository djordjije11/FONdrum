import { useState } from "react";
import { WineStyle, WineStyleCollection } from "../../../models/WineStyle";
import FilterSelection from "../../shared/filter/FilterSelection";
import {
  GrapeVariety,
  GrapeVarietyCollection,
} from "../../../models/GrapeVariety";
import useFetchWineStylesEffect from "../hooks/useFetchWineStylesEffect";
import useFetchGrapeVarietiesEffect from "../hooks/useFetchGrapeVarietiesEffect";

interface FilterSideBarProps {
  checkedWineStyleIds: string[];
  setCheckedWineStyleIds: React.Dispatch<React.SetStateAction<string[]>>;
  checkedGrapeVarietyIds: string[];
  setCheckedGrapeVarietyIds: React.Dispatch<React.SetStateAction<string[]>>;
}

export default function WineFilterSideBar(props: FilterSideBarProps) {
  const {
    checkedWineStyleIds,
    setCheckedWineStyleIds,
    checkedGrapeVarietyIds,
    setCheckedGrapeVarietyIds,
  } = props;

  const [wineStyleCollection, setWineStyleCollection] = useState({
    wineStyles: [] as WineStyle[],
  } as WineStyleCollection);
  const [grapeVarietyCollection, setGrapeVarietyColleciton] = useState({
    grapeVarieties: [] as GrapeVariety[],
  } as GrapeVarietyCollection);

  useFetchWineStylesEffect(
    setWineStyleCollection,
    setCheckedWineStyleIds,
    checkedGrapeVarietyIds
  );
  useFetchGrapeVarietiesEffect(
    setGrapeVarietyColleciton,
    setCheckedGrapeVarietyIds,
    checkedWineStyleIds
  );

  function handleWineStyleChecked(id: string, checked: boolean) {
    if (checked) {
      setCheckedWineStyleIds((prev) => [...prev, id]);
    } else {
      setCheckedWineStyleIds((prev) => prev.filter((wsId) => wsId !== id));
    }
  }

  function handleGrapeVarietiesChecked(id: string, checked: boolean) {
    if (checked) {
      setCheckedGrapeVarietyIds((prev) => [...prev, id]);
    } else {
      setCheckedGrapeVarietyIds((prev) => prev.filter((gvId) => gvId !== id));
    }
  }

  return (
    <div className="bg-gray-50 rounded-lg w-fit h-fit p-10 flex flex-col gap-8 border-2 border-blue-gray-800">
      {false ||
      (wineStyleCollection.wineStyles.length === 0 &&
        grapeVarietyCollection.grapeVarieties.length === 0) ? (
        <div className="h-[440px] w-[120px]" />
      ) : (
        <>
          <div>
            <FilterSelection
              title="Wine styles"
              typeName="wine-style"
              valuesArray={wineStyleCollection.wineStyles}
              handleChecked={handleWineStyleChecked}
              totalCount={wineStyleCollection.totalCount}
            />
          </div>
          <div>
            <FilterSelection
              title="Grape varieties"
              typeName="grape-variety"
              valuesArray={grapeVarietyCollection.grapeVarieties}
              handleChecked={handleGrapeVarietiesChecked}
              totalCount={grapeVarietyCollection.totalCount}
            />
          </div>
        </>
      )}
    </div>
  );
}
