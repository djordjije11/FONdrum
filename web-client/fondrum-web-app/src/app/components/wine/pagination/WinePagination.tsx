import { PageInfo } from "../../../models/shared/pagination/PageInfo";
import LeftArrowIcon from "../../shared/icons/pagination/LeftArrowIcon";
import RightArrowIcon from "../../shared/icons/pagination/RightArrowIcon";

interface WinePaginationProps {
  pageInfo: PageInfo;
  handlePageChange: (pageNumber: number) => void;
  children: React.JSX.Element;
}

export default function WinePagination(props: WinePaginationProps) {
  const { pageInfo, handlePageChange, children } = props;

  function isPreviousDisabled(): boolean {
    return pageInfo.pageNumber <= 1;
  }

  function isNextDisabled(): boolean {
    return pageInfo.pageNumber >= pageInfo.totalPagesCount;
  }

  return (
    <>
      <div className="h-full flex items-center">
        <button
          onClick={() => handlePageChange(pageInfo.pageNumber - 1)}
          disabled={isPreviousDisabled()}
          className={`h-full rounded-l-full py-1 px-1 text-center bg-blue-gray-800 text-white border-2 border-blue-gray-600 shadow ${
            isPreviousDisabled() ? "" : "hover:bg-blue-gray-600"
          }`}
        >
          <LeftArrowIcon />
        </button>
      </div>
      {children}
      <div className="h-full flex items-center">
        <button
          onClick={() => handlePageChange(pageInfo.pageNumber + 1)}
          disabled={isNextDisabled()}
          className={`h-full rounded-r-full py-1 px-1 text-center bg-blue-gray-800 text-white border-2 border-blue-gray-600 shadow ${
            isNextDisabled() ? "" : "hover:bg-blue-gray-600"
          }`}
        >
          <RightArrowIcon />
        </button>
      </div>
    </>
  );
}
