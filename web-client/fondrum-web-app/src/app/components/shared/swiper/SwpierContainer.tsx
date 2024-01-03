import Swiper from "swiper";
import "swiper/css";
import { Autoplay } from "swiper/modules";
import { useEffect } from "react";

export interface SwiperSlideElement {
  id: string;
  component: React.JSX.Element;
}

interface SwiperContainerProps {
  swiperSlideElements: SwiperSlideElement[];
  autoplayDelay: number;
  slidesPerView: number;
}

export default function SwiperContainer(props: SwiperContainerProps) {
  const { swiperSlideElements, autoplayDelay, slidesPerView } = props;

  useEffect(() => {
    const swiper = new Swiper(".swiper", {
      modules: [Autoplay],
      loop: true,
      slidesPerView,
      centeredSlides: true,
      autoplay: {
        delay: autoplayDelay,
        disableOnInteraction: false,
        pauseOnMouseEnter: true,
      },
      grabCursor: true,
      keyboard: {
        enabled: true,
        onlyInViewport: false,
      },
    });

    return () => swiper.destroy();
  }, [autoplayDelay, slidesPerView]);

  return (
    <div className="swiper">
      <div className="swiper-wrapper p-1.5">
        {swiperSlideElements.map((swiperSlideElement) => (
          <div key={swiperSlideElement.id} className="swiper-slide">
            {swiperSlideElement.component}
          </div>
        ))}
      </div>
    </div>
  );
}
