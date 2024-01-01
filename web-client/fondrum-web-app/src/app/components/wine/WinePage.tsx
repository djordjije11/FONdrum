import { useEffect, useState } from "react";
import WineFilterSideBar from "./filter/WineFilterSideBar";
import { Wine } from "../../models/Wine";
import getWinesAsync from "../../services/request/wine/getWinesAsync";
import WineCard from "./WineCard";

export default function WinePage() {
  const [wines, setWines] = useState([] as Wine[]);
  const [checkedWineStyleIds, setCheckedWineStyleIds] = useState(
    [] as string[]
  );
  const [checkedGrapeVarietyIds, setCheckedGrapeVarietyIds] = useState(
    [] as string[]
  );

  const fetchWinesEffect = () => {
    (async () => {
      setWines(
        await getWinesAsync(checkedWineStyleIds, checkedGrapeVarietyIds)
      );
    })();
  };

  useEffect(fetchWinesEffect, [checkedWineStyleIds, checkedGrapeVarietyIds]);

  return (
    <div className="grid grid-cols-12 h-full mt-2">
      <div className="col-span-2 flex justify-center">
        <WineFilterSideBar
          checkedWineStyleIds={checkedWineStyleIds}
          setCheckedWineStyleIds={setCheckedWineStyleIds}
          checkedGrapeVarietyIds={checkedGrapeVarietyIds}
          setCheckedGrapeVarietyIds={setCheckedGrapeVarietyIds}
        />
      </div>
      <div className="col-span-7 flex gap-4 flex-wrap">
        {wines.map((wine) => (
          <WineCard key={wine.id} wine={wine} />
        ))}
      </div>
      <div className="col-span-3"></div>
    </div>
  );
}
