import { useContext, useState } from "react";
import WineFilterSideBar from "./filter/WineFilterSideBar";
import { Wine } from "../../models/Wine";
import WineCard from "./WineCard";
import ShoppingCartContainer from "../order/ShoppingCartContainer";
import { OrderModel } from "../../models/Order";
import { _getDefaultPaged } from "../../models/shared/pagination/Paged";
import { PageQueryParams } from "../../models/shared/pagination/PageQueryParams";
import WinePagination from "./pagination/WinePagination";
import useFetchWinesEffect from "./hooks/useFetchWinesEffect";
import useChangePageQueryParamsOnFilterChangeEffect from "./hooks/useChangePageQueryParamsOnFilterChangeEffect";
import { OrderContext } from "../../App";
import { useNavigate } from "react-router-dom";
import { ORDER_PAGE } from "../router/AppRouter";

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
  const { order, setOrder } = useContext(OrderContext);
  const navigate = useNavigate();

  useFetchWinesEffect(
    setPagedWine,
    checkedWineStyleIds,
    checkedGrapeVarietyIds,
    pageQueryParams
  );

  useChangePageQueryParamsOnFilterChangeEffect(
    setPageQueryParams,
    checkedWineStyleIds,
    checkedGrapeVarietyIds
  );

  function addWineToOrder(wine: Wine) {
    setOrder((prev) => {
      const orderedWineItemResult = prev.findOrderItemByWine(wine);
      if (orderedWineItemResult === null) {
        return new OrderModel([...prev.items, { wine, amount: 1 }]);
      }
      return new OrderModel([
        ...prev.items.slice(0, orderedWineItemResult.index),
        {
          wine: orderedWineItemResult.orderItem.wine,
          amount: orderedWineItemResult.orderItem.amount + 1,
        },
        ...prev.items.slice(orderedWineItemResult.index + 1),
      ]);
    });
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
          <ShoppingCartContainer
            order={order}
            setOrder={setOrder}
            onClick={() => navigate(ORDER_PAGE)}
          />
        </div>
      </div>
      <div className="row-span-1 flex justify-end"></div>
    </div>
  );
}
