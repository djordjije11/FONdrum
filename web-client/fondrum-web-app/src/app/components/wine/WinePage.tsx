import { useEffect, useState } from "react";
import WineFilterSideBar from "./filter/WineFilterSideBar";
import { Wine } from "../../models/Wine";
import getWinesAsync from "../../services/request/wine/getWinesAsync";
import WineCard from "./WineCard";
import ShoppingCartContainer from "../order/ShoppingCartContainer";
import { OrderModel } from "../../models/Order";
import { _getDefaultPaged } from "../../models/shared/pagination/Paged";
import { PageQueryParams } from "../../models/shared/pagination/PageQueryParams";
import WinePagination from "./pagination/WinePagination";

export default function WinePage() {
  const [pagedWine, setPagedWine] = useState(_getDefaultPaged<Wine>());
  const [pageQueryParams, setPageQueryParams] = useState({
    pageNumber: 1,
    pageSize: 8,
  } as PageQueryParams);
  const [checkedWineStyleIds, setCheckedWineStyleIds] = useState(
    [] as string[]
  );
  const [checkedGrapeVarietyIds, setCheckedGrapeVarietyIds] = useState(
    [] as string[]
  );
  const [order, setOrder] = useState(new OrderModel());

  const fetchWinesEffect = () => {
    (async () => {
      setPagedWine(
        await getWinesAsync(
          checkedWineStyleIds,
          checkedGrapeVarietyIds,
          pageQueryParams
        )
      );
    })();
  };

  useEffect(fetchWinesEffect, [
    checkedWineStyleIds,
    checkedGrapeVarietyIds,
    pageQueryParams,
  ]);

  const changePageQueryParamsOnFilterChangeEffect = () => {
    (async () => {
      setPageQueryParams((prev) => ({ ...prev, pageNumber: 1 }));
    })();
  };

  useEffect(changePageQueryParamsOnFilterChangeEffect, [
    checkedWineStyleIds,
    checkedGrapeVarietyIds,
  ]);

  function addWineToOrder(wine: Wine) {
    const orderedWineItemResult = order.findOrderItemByWine(wine);
    if (orderedWineItemResult === null) {
      setOrder((prev) => new OrderModel([...prev.items, { wine, amount: 1 }]));
      return;
    }

    setOrder(
      (prev) =>
        new OrderModel([
          ...prev.items.slice(0, orderedWineItemResult.index),
          {
            wine: orderedWineItemResult.orderItem.wine,
            amount: orderedWineItemResult.orderItem.amount + 1,
          },
          ...prev.items.slice(orderedWineItemResult.index + 1),
        ])
    );
  }

  function isAddWineButtonDisabled(wine: Wine): boolean {
    return wine.stockQuantity <= order.getOrderItemAmountByWine(wine);
  }

  function WineCardsContainer(): React.JSX.Element {
    if (pagedWine.data.length === 0) {
      return <div className="w-11/12 pl-2"></div>;
    }

    return (
      <div className="flex justify-start gap-4 flex-wrap w-11/12 pl-2">
        {pagedWine.data.map((wine) => (
          <WineCard
            key={wine.id}
            wine={wine}
            handleAddClick={addWineToOrder}
            addDisabled={isAddWineButtonDisabled(wine)}
          />
        ))}
      </div>
    );
  }

  return (
    <div className="grid grid-rows-8 min-h-fit max-h-[720px]">
      <div className="row-span-7 grid grid-cols-12 h-[620px] mt-2">
        <div className="min-h-full col-span-2 flex justify-center">
          <WineFilterSideBar
            checkedWineStyleIds={checkedWineStyleIds}
            setCheckedWineStyleIds={setCheckedWineStyleIds}
            checkedGrapeVarietyIds={checkedGrapeVarietyIds}
            setCheckedGrapeVarietyIds={setCheckedGrapeVarietyIds}
          />
        </div>
        <div className="min-h-full col-span-7 flex justify-center">
          <WinePagination
            pageInfo={pagedWine.pageInfo}
            handlePageChange={(pageNumber) =>
              setPageQueryParams((prev) => ({ ...prev, pageNumber }))
            }
          >
            <WineCardsContainer />
          </WinePagination>
        </div>
        <div className="min-h-full col-span-3 flex justify-center px-8">
          <ShoppingCartContainer order={order} setOrder={setOrder} />
        </div>
      </div>
      <div className="row-span-1 flex justify-end"></div>
    </div>
  );
}
