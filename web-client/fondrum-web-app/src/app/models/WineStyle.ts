export type WineStyle = {
  id: string;
  name: string;
};

export type WineStyleCollection = {
  wineStyles: WineStyle[];
  totalCount: number;
};
