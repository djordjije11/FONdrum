import { HOME_PAGE, WINE_PAGE } from "../router/AppRouter";
import HomeIcon from "../shared/icons/home/HomeIcon";
import ShopIcon from "../shared/icons/home/ShopIcon";
import FONdrumLogo from "../shared/logo/FONdrumLogo";
import Nav from "./Nav";

export default function HeaderNav() {
  return (
    <div className="lg:h-20 md:h-16">
      <nav className="fixed top-0 z-1 flex-no-wrap flex w-full items-center justify-between bg-black py-2 shadow-md shadow-black/5 dark:bg-neutral-600 dark:shadow-black/10 lg:flex-wrap lg:justify-start lg:py-4">
        <div className="flex w-full h-10 flex-wrap items-center justify-between pl-6 pr-6">
          <div className="flex items-center justify-start h-full w-48">
            <Nav url={HOME_PAGE}>
              <div className="flex gap-2 items-center">
                <span>Home page</span>
                <HomeIcon className="h-5" />
              </div>
            </Nav>
          </div>
          <div className="flex items-center h-full border border-solid border-gray-200 hover:bg-gray-700">
            <Nav url={WINE_PAGE}>
              <div className="h-full flex flex-row gap-2 items-center">
                <ShopIcon className="h-5 text-white" />
                <span>Go shop now!</span>
                <ShopIcon className="h-5 text-white" />
              </div>
            </Nav>
          </div>
          <div className="flex items-center justify-between h-full w-48">
            <Nav url={HOME_PAGE}>
              <div className="text-lg underline">
                <span className="font-custom--exo2">FON</span>
                <span className="font-custom--exo2 italic">DRUM</span>
              </div>
            </Nav>
            <FONdrumLogo />
          </div>
        </div>
      </nav>
    </div>
  );
}
