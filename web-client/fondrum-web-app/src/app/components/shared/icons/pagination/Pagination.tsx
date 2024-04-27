import { PageInfo } from "../../../../models/shared/pagination/PageInfo";

interface PaginationProps {
  pageInfo: PageInfo;
  handlePageChange: (pageNumber: number) => void;
}

export default function Pagination(props: PaginationProps) {
  const { pageInfo, handlePageChange } = props;

  function isPreviousDisabled(): boolean {
    return pageInfo.pageNumber === 1;
  }

  function isNextDisabled(): boolean {
    return pageInfo.pageNumber === pageInfo.totalPagesCount;
  }

  return (
    <div className="w-96 flex justify-end items-center">
      <button
        onClick={() => handlePageChange(pageInfo.pageNumber - 1)}
        disabled={isPreviousDisabled()}
        className={`py-1 px-2 text-center bg-blue-gray-800 text-white border-2 border-blue-gray-600 rounded shadow ${
          isPreviousDisabled() ? "" : "hover:bg-blue-gray-600"
        }`}
      >
        <LeftArrowIcon />
      </button>
      <button
        onClick={() => handlePageChange(pageInfo.pageNumber + 1)}
        disabled={isNextDisabled()}
        className={`py-1 px-2 text-center bg-blue-gray-800 text-white border-2 border-blue-gray-600 rounded shadow ${
          isNextDisabled() ? "" : "hover:bg-blue-gray-600"
        }`}
      >
        <RightArrowIcon />
      </button>
    </div>
  );
}

function LeftArrowIcon(): React.JSX.Element {
  return (
    <>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        strokeWidth="1.5"
        stroke="currentColor"
        className="w-6 h-6"
      >
        <path
          strokeLinecap="round"
          strokeLinejoin="round"
          d="M6.75 15.75 3 12m0 0 3.75-3.75M3 12h18"
        />
      </svg>
    </>
  );
}

function RightArrowIcon(): React.JSX.Element {
  return (
    <>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        strokeWidth="1.5"
        stroke="currentColor"
        className="w-6 h-6"
      >
        <path
          strokeLinecap="round"
          strokeLinejoin="round"
          d="M17.25 8.25 21 12m0 0-3.75 3.75M21 12H3"
        />
      </svg>
    </>
  );
}
