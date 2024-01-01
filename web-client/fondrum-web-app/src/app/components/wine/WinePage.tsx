import { useEffect, useState } from "react";
import WineFilterSideBar from "./filter/WineFilterSideBar";
import { Wine } from "../../models/Wine";
import getWinesAsync from "../../services/request/wine/getWinesAsync";
import WineCard from "./WineCard";
import ShoppingCartContainer from "../order/ShoppingCartContainer";
import { Order } from "../../models/Order";
import { OrderItem } from "../../models/OrderItem";

export default function WinePage() {
  const [wines, setWines] = useState([] as Wine[]);
  const [checkedWineStyleIds, setCheckedWineStyleIds] = useState(
    [] as string[]
  );
  const [checkedGrapeVarietyIds, setCheckedGrapeVarietyIds] = useState(
    [] as string[]
  );
  const [order, setOrder] = useState({ items: [] as OrderItem[] } as Order);

  const fetchWinesEffect = () => {
    (async () => {
      setWines(
        await getWinesAsync(checkedWineStyleIds, checkedGrapeVarietyIds)
      );
    })();
  };

  useEffect(fetchWinesEffect, [checkedWineStyleIds, checkedGrapeVarietyIds]);

  function addWineToOrder(wine: Wine) {
    const orderedWineItemIndex = order.items.findIndex(
      (i) => i.wine.id === wine.id
    );

    if (orderedWineItemIndex === -1) {
      setOrder((prev) => ({ items: [...prev.items, { wine, amount: 1 }] }));
      return;
    }

    const orderedWineItem = order.items.at(orderedWineItemIndex);
    if (orderedWineItem === undefined) {
      throw new Error();
    }

    setOrder((prev) => ({
      items: [
        ...prev.items.slice(0, orderedWineItemIndex),
        { wine: orderedWineItem.wine, amount: orderedWineItem.amount + 1 },
        ...prev.items.slice(orderedWineItemIndex + 1),
      ],
    }));
    // setOrder((prev) => ({
    //   items: [
    //     ...prev.items.filter((i) => i.wine.id !== orderedWineItem.wine.id),
    //     { wine: orderedWineItem.wine, amount: orderedWineItem.amount + 1 },
    //   ],
    // }));
  }

  return (
    <div className="grid grid-rows-8 h-fit">
      <div className="row-span-7 grid grid-cols-12 h-[620px] mt-2">
        <div className="col-span-2 flex justify-center">
          <WineFilterSideBar
            checkedWineStyleIds={checkedWineStyleIds}
            setCheckedWineStyleIds={setCheckedWineStyleIds}
            checkedGrapeVarietyIds={checkedGrapeVarietyIds}
            setCheckedGrapeVarietyIds={setCheckedGrapeVarietyIds}
          />
        </div>
        <div className="col-span-7 flex justify-center">
          <div className="flex justify-start gap-4 flex-wrap w-11/12 pl-1">
            {wines.map((wine) => (
              <WineCard
                key={wine.id}
                wine={wine}
                handleAddClick={addWineToOrder}
              />
            ))}
          </div>
        </div>
        <div className="col-span-3 flex justify-center px-8">
          <ShoppingCartContainer order={order} />
        </div>
      </div>
      <div className="row-span-1">Pagination</div>
    </div>
  );
}
