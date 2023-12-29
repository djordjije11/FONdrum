import { useEffect, useState } from "react";
import { WineStyle } from "../../../models/WineStyle";
import getWineStylesAsync from "../../../services/request/wine/getWineStylesAsync";
import FilterSelection from "./FilterSelection";
import getGrapeVarietiesAsync from "../../../services/request/wine/getGrapeVarietiesAsync";
import { GrapeVariety } from "../../../models/GrapeVariety";

interface FilterSideBarProps {
  checkedWineStyleIds: string[];
  setCheckedWineStyleIds: React.Dispatch<React.SetStateAction<string[]>>;
  checkedGrapeVarietyIds: string[];
  setCheckedGrapeVarietyIds: React.Dispatch<React.SetStateAction<string[]>>;
}

export default function FilterSideBar(props: FilterSideBarProps) {
  const {
    checkedWineStyleIds,
    setCheckedWineStyleIds,
    checkedGrapeVarietyIds,
    setCheckedGrapeVarietyIds,
  } = props;

  const [wineStyles, setWineStyles] = useState([] as WineStyle[]);
  const [grapeVarieties, setGrapeVarieties] = useState([] as GrapeVariety[]);

  const fetchWineStylesEffect = () => {
    (async () => {
      const wineStyles = await getWineStylesAsync(checkedGrapeVarietyIds);
      setWineStyles(wineStyles);
    })();
  };

  const fetchGrapeVarietiesEffect = () => {
    (async () => {
      setGrapeVarieties(await getGrapeVarietiesAsync(checkedWineStyleIds));
    })();
  };

  useEffect(fetchWineStylesEffect, [checkedGrapeVarietyIds]);
  useEffect(fetchGrapeVarietiesEffect, [checkedWineStyleIds]);

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
    <div className="bg-gray-200 min-h-[720px] min-w-[240px] h-full rounded-md">
      <div>
        <FilterSelection
          title="Wine styles"
          typeName="wine-style"
          valuesArray={wineStyles}
          handleChecked={handleWineStyleChecked}
        />
      </div>
      <div>
        <FilterSelection
          title="Grape varieties"
          typeName="grape-variety"
          valuesArray={grapeVarieties}
          handleChecked={handleGrapeVarietiesChecked}
        />
      </div>
    </div>
  );
}
