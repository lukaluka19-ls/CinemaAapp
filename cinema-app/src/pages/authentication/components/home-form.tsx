import Navbar from "../../../components/Navbar";
import slika2 from "../../../img/slika2.jpg";
import slika3 from "../../../img/slika3.jpg";
import slika4 from "../../../img/slika4.jpg";
import slika5 from "../../../img/slika5.jpg";
import { useState, useEffect } from "react";

export const HomeForm = () => {
  const images = [slika3, slika2, slika4, slika5];
  const [currentImage, setCurrentImage] = useState(0);

  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentImage((prev) => (prev + 1) % images.length);
    }, 4000);

    return () => clearInterval(interval);
  }, []);

  return (
    <div>
      <Navbar />
      <div className="relative min-h-screen w-full overflow-hidden">
        {images.map((image, index) => (
          <div
            key={index}
            className={`absolute inset-0 bg-cover bg-center transition-opacity duration-1000 ${
              index === currentImage ? "opacity-100" : "opacity-0"
            }`}
            style={{
              backgroundImage: `url('${image}')`,
            }}
          />
        ))}
      </div>
    </div>
  );
};
