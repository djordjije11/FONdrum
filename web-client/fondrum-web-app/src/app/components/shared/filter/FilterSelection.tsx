export type FilterSelectionProperty = {
  id: string;
  name: string;
};

export interface FilterSelectionProps<T extends FilterSelectionProperty> {
  title: string;
  typeName: string;
  valuesArray: T[];
  handleChecked: (id: string, checked: boolean) => void;
}

export default function FilterSelection<T extends FilterSelectionProperty>(
  props: FilterSelectionProps<T>
) {
  const { title, typeName, valuesArray, handleChecked } = props;
  return (
    <div>
      <p>{title}</p>
      <fieldset className="flex flex-col">
        {valuesArray.map((element) => (
          <div key={element.id}>
            <label htmlFor={element.id}>{element.name}</label>
            <input
              type="checkbox"
              name={typeName}
              id={element.id}
              value={element.id}
              onChange={(e) => handleChecked(e.target.value, e.target.checked)}
            />
          </div>
        ))}
      </fieldset>
    </div>
  );
}
