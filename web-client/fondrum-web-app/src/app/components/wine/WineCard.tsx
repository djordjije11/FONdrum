import { Wine } from "../../models/Wine";

export interface WineCardProps {
  wine: Wine;
  handleAddClick: (wine: Wine) => void;
}

export default function WineCard(props: WineCardProps) {
  const { wine, handleAddClick } = props;

  return (
    <div className="w-52 h-[300px] flex flex-col bg-gray-50 border-4 border-blue-gray-800 p-4 rounded-lg gap-1">
      <img
        src={wine.imageUrl}
        alt="Vino"
        className="border border-blue-gray-800 border-solid"
      />
      <div className="flex justify-center p-2">{wine.name}</div>
      <div className="flex justify-between items-center">
        <span>{wine.wineStyle}</span>
        <span>{wine.price} din</span>
      </div>
      <div className="flex justify-between items-center">
        <span>{wine.grapeVariety}</span>
        <button
          onClick={() => handleAddClick(wine)}
          className="h-6 bg-white hover:bg-gray-100 text-blue-gray-800 font-semibold px-4 pb-4 border-2 border-blue-gray-600 rounded shadow"
        >
          +
        </button>
      </div>
    </div>
  );
}
