export type FilterSelectionProperty = {
  id: string;
  name: string;
};

export interface FilterSelectionProps<T extends FilterSelectionProperty> {
  title: string;
  typeName: string;
  valuesArray: T[];
  handleChecked: (id: string, checked: boolean) => void;
  totalCount: number;
}

export default function FilterSelection<T extends FilterSelectionProperty>(
  props: FilterSelectionProps<T>
) {
  const { title, typeName, valuesArray, handleChecked, totalCount } = props;

  function FilterFieldFill(): React.JSX.Element {
    const arr = Array.from(
      { length: totalCount - valuesArray.length },
      (_, i) => i
    );
    return (
      <div>
        {arr.map((e) => (
          <div key={e} className="h-7 flex gap-2 border-b py-4" />
        ))}
      </div>
    );
  }

  return (
    <div className="flex flex-col">
      <p className="text-lg mb-3">{title}</p>
      <div>
        <div>
          <fieldset className="flex flex-col border-solid border-gray-800 border-t">
            {valuesArray.map((element) => (
              <div
                key={element.id}
                className="h-7 flex gap-2 items-center border-solid border-gray-800 border-b py-4"
              >
                <input
                  type="checkbox"
                  className="h-4 w-4"
                  name={typeName}
                  id={element.id}
                  value={element.id}
                  onChange={(e) =>
                    handleChecked(e.target.value, e.target.checked)
                  }
                />
                <label htmlFor={element.id} className="text-center text-[15px]">
                  {element.name}
                </label>
              </div>
            ))}
          </fieldset>
        </div>
        <FilterFieldFill />
      </div>
    </div>
  );
}
