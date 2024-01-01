export type GrapeVariety = {
  id: string;
  name: string;
};

export type GrapeVarietyCollection = {
  grapeVarieties: GrapeVariety[];
  totalCount: number;
};
