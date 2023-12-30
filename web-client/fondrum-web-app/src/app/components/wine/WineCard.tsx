import { Wine } from "../../models/Wine";

export interface WineCardProps {
  wine: Wine;
}

export default function WineCard(props: WineCardProps) {
  const { wine } = props;

  return (
    <div className="h-60 w-60">
      <img src={wine.imageUrl} alt="Vino" className="h-full w-full" />{" "}
      <span>
        {wine.name} - {wine.price}
      </span>
    </div>
  );
}
