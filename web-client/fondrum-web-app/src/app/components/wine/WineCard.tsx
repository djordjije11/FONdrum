import { Wine } from "../../models/Wine";

export interface WineCardProps {
  wine: Wine;
  handleAddClick: (wine: Wine) => void;
  addDisabled: boolean;
}

export default function WineCard(props: WineCardProps) {
  const { wine, handleAddClick, addDisabled } = props;

  return (
    <div className="w-52 h-[300px] flex flex-col bg-gray-50 border-4 border-blue-gray-800 p-4 rounded-lg gap-1">
      <img
        src={wine.imageUrl}
        alt="Vino"
        className="border border-blue-gray-800 border-solid rounded-sm"
      />
      <div className="flex justify-center p-2">{wine.name}</div>
      <div className="flex justify-between items-center">
        <span>{wine.wineStyle}</span>
        <span>{wine.price} €</span>
      </div>
      <div className="flex justify-between items-center">
        <span>{wine.grapeVariety}</span>
        <button
          disabled={addDisabled}
          onClick={() => handleAddClick(wine)}
          className={`h-6 bg-white text-blue-gray-800 font-semibold text-sm px-3 border-2 border-blue-gray-600 rounded shadow ${
            addDisabled ? "" : "hover:bg-gray-100"
          }`}
        >
          +
        </button>
      </div>
    </div>
  );
}
