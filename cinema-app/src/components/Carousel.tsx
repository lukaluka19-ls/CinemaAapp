import React, { useEffect, useState } from "react";
import slika2 from "../img/slika2.jpg";
import slika3 from "../img/slika3.jpg";
import slika4 from "../img/slika4.jpg";
import slika5 from "../img/slika5.jpg";
import slika6 from "../img/slika6.jpg";
import slika8 from "../img/slika8.jpg";
import slika9 from "../img/slika9.jpg";
import slika10 from "../img/slika10.jpg";
import slika11 from "../img/slika11.jpg";

interface Props {
  children: React.ReactNode;
}

const images = [
  slika2,
  slika3,
  slika4,
  slika5,
  slika6,
  slika8,
  slika9,
  slika10,
  slika11,
];

const BackgroundSlider: React.FC<Props> = ({ children }) => {
  const [currentImage, setCurrentImage] = useState(0);

  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentImage((prev) => (prev + 1) % images.length);
    }, 3000);

    return () => clearInterval(interval);
  }, []);

  return (
    <div className="relative min-h-screen w-full overflow-hidden">
      {images.map((image, index) => (
        <div
          key={index}
          className={`absolute inset-0 bg-cover bg-center transition-opacity duration-1000 ${
            index === currentImage ? "opacity-100" : "opacity-0"
          }`}
          style={{
            backgroundImage: `url(${image})`,
          }}
        />
      ))}

      <div className="relative z-10">{children}</div>
    </div>
  );
};

export default BackgroundSlider;
