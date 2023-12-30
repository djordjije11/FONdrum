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
    <div className="flex justify-around h-full">
      <WineFilterSideBar
        checkedWineStyleIds={checkedWineStyleIds}
        setCheckedWineStyleIds={setCheckedWineStyleIds}
        checkedGrapeVarietyIds={checkedGrapeVarietyIds}
        setCheckedGrapeVarietyIds={setCheckedGrapeVarietyIds}
      />
      <div>
        {wines.map((wine) => (
          <WineCard wine={wine} />
        ))}
      </div>
    </div>
  );
}
