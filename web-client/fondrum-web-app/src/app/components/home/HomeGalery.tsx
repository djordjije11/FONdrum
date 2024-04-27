import SwiperContainer, {
  SwiperSlideElement,
} from "../shared/swiper/SwpierContainer";
import { galeryImgs } from "./galeryImgs";

export default function HomeGalery() {
  const galeryImgages = galeryImgs;

  function createSwiperSlideGaleryImgs(): SwiperSlideElement[] {
    return galeryImgages.map((img, index) => ({
      id: index.toString(),
      component: (
        <div className="w-fit py-2 px-3">
          <img
            src={img}
            alt={`Galery ${img}`}
            className="h-48 w-96 border-4 border-solid border-blue-gray-800 rounded-sm overflow-hidden object-cover"
          />
        </div>
      ),
    }));
  }

  return (
    <div className="w-2/3 flex flex-col items-center gap-1">
      <h2 className="text-2xl text-blue-gray-100 font-custom--exo2">
        Galerija
      </h2>
      <div className="w-[1120px] flex justify-center">
        <SwiperContainer
          swiperSlideElements={createSwiperSlideGaleryImgs()}
          autoplayDelay={2000}
          slidesPerView={3}
        />
      </div>
    </div>
  );
}
