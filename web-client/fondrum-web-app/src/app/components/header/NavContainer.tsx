import Nav from "./Nav";

interface NavProps {
  url: string;
  children: JSX.Element;
}

export default function NavContainer(props: NavProps) {
  const { url, children } = props;

  return (
    <div className="flex items-center justify-start h-full p-2 rounded-2xl hover:bg-gray-700">
      <Nav url={url}>
        <div className="flex gap-2 items-center">{children}</div>
      </Nav>
    </div>
  );
}
