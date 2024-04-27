import { url } from "inspector";
import { useNavigate } from "react-router-dom";

export interface NavProps {
  children: React.JSX.Element;
  url?: string;
}

export default function Nav(props: NavProps) {
  const navigate = useNavigate();

  function handleClick() {
    if (!props.url) {
      return;
    }
    navigate(props.url);
  }

  return (
    <a
      className="h-full flex items-center text-neutral-500 text-white transition duration-200 hover:text-neutral-700 hover:ease-in-out focus:text-neutral-700 disabled:text-black/30 motion-reduce:transition-none dark:text-neutral-200 dark:hover:text-neutral-300 dark:focus:text-neutral-300 lg:px-2 [&.active]:text-black/90 dark:[&.active]:text-zinc-400 hover:cursor-pointer"
      onClick={handleClick}
    >
      {props.children}
    </a>
  );
}
