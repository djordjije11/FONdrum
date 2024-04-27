import { HOME_PAGE, ORDER_PAGE, WINE_PAGE } from "../router/AppRouter";
import HomeIcon from "../shared/icons/header/HomeIcon";
import ShopIcon from "../shared/icons/header/ShopIcon";
import WineIcon from "../shared/icons/header/WineIcon";
import FONdrumLogo from "../shared/logo/FONdrumLogo";
import Nav from "./Nav";
import NavContainer from "./NavContainer";

export default function HeaderNav() {
  return (
    <div className="lg:h-20 md:h-16">
      <nav className="fixed top-0 z-1 flex-no-wrap flex w-full items-center justify-between bg-black py-2 shadow-md shadow-black/5 dark:bg-neutral-600 dark:shadow-black/10 lg:flex-wrap lg:justify-start lg:py-4">
        <div className="flex w-full h-10 flex-wrap items-center justify-between pl-6 pr-6">
          <div className="flex items-center mx-2">
            <NavContainer url={HOME_PAGE}>
              <>
                <span>O nama</span>
                <HomeIcon className="h-5" />
              </>
            </NavContainer>
            <NavContainer url={WINE_PAGE}>
              <>
                <span>Katalog</span>
                <WineIcon className="h-5 text-white" />
              </>
            </NavContainer>
            <NavContainer url={ORDER_PAGE}>
              <>
                <span>Moja korpa</span>
                <ShopIcon className="h-5 text-white" />
              </>
            </NavContainer>
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
