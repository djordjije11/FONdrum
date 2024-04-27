import AboutUs from "./AboutUs";
import HomeGalery from "./HomeGalery";

export default function HomePage() {
  return (
    <div className="grid grid-flow-col grid-rows-9">
      <div className="row-span-1 w-full flex justify-center items-start">
        <h1 className="text-3xl text-blue-gray-100 font-custom--exo2 border border-t-0 border-solid p-4 rounded-lg">
          Dobrodošli u FONdrum!
        </h1>
      </div>
      <div className="row-span-4 w-full flex justify-center py-6">
        <HomeGalery />
      </div>
      <div className="row-span-4 max-h-fit w-full flex justify-center">
        <AboutUs />
      </div>
    </div>
  );
}
