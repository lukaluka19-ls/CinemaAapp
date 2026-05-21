import Navbar from "../../../components/Navbar";
import Footer from "../../../components/Footer";
import slika2 from "../../../img/slika2.jpg";
import slika3 from "../../../img/slika3.jpg";
import slika4 from "../../../img/slika4.jpg";
import slika5 from "../../../img/slika5.jpg";
import slika6 from "../../../img/slika6.jpg";
import slika8 from "../../../img/slika8.jpg";
import slika9 from "../../../img/slika9.jpg";
import slika10 from "../../../img/slika10.jpg";
import slika11 from "../../../img/slika11.jpg";

import { useState, useEffect } from "react";
const movies = [
  {
    title: "DareDevil",
    image: slika11,
  },
  {
    title: "Michael",
    image: slika10,
  },
  {
    title: "Sparta",
    image: slika9,
  },
  {
    title: "Punisher",
    image: slika8,
  },
  {
    title: "San Andreas",
    image: slika3,
  },
  {
    title: "Michael",
    image: slika2,
  },
  {
    title: "Joker",
    image: slika4,
  },
  {
    title: "John Wick",
    image: slika5,
  },
];

export const HomeForm = () => {
  const images = [
    slika11,
    slika10,
    slika9,
    slika8,
    slika6,
    slika3,
    slika2,
    slika4,
    slika5,
  ];
  const [currentImage, setCurrentImage] = useState(0);

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
        <div className="relative min-h-screen w-full overflow-hidden">
          <div className="absolute inset-0 bg-black"></div>
          <div className="relative z-10 p-10">
            <h1 className="text-white text-5xl font-bold mb-10">
              Popular Movies
            </h1>

            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-8">
              {movies.map((movie, index) => (
                <div
                  key={index}
                  className="bg-zinc-900/80 backdrop-blur-md rounded-3xl overflow-hidden shadow-2xl cursor-pointer hover:scale-105 transition duration-50 cursor-pointer"
                >
                  <img
                    src={movie.image}
                    alt={movie.title}
                    className="w-full h-[420px] object-cover"
                  />

                  <div className="p-5 flex justify-start">
                    <h2 className="text-white text-2xl font-semibold">
                      {movie.title} -
                    </h2>

                    <p className="text-red-700 mt-1 text-xl font-semibold font-sans pl-2">
                      NEW
                    </p>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
      <Footer />
    </div>
  );
};
