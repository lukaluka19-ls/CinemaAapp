import Navbar from "../../../components/Navbar";
import Footer from "../../../components/Footer";
import { MovieGrid } from "./MovieGrid";
import slika2 from "../../../img/slika2.jpg";
import slika3 from "../../../img/slika3.jpg";
import slika4 from "../../../img/slika4.jpg";
import slika5 from "../../../img/slika5.jpg";
import slika6 from "../../../img/slika6.jpg";
import slika8 from "../../../img/slika8.jpg";
import slika9 from "../../../img/slika9.jpg";
import slika10 from "../../../img/slika10.jpg";
import slika11 from "../../../img/slika11.jpg";

const movies = [
    { title: "DareDevil", image: slika11 },
    { title: "Michael", image: slika10 },
    { title: "Sparta", image: slika9 },
    { title: "Punisher", image: slika8 },
    { title: "San Andreas", image: slika3 },
    { title: "Michael", image: slika2 },
    { title: "Joker", image: slika4 },
    { title: "John Wick", image: slika5 },
];

export const Home = () => {
    return (
        <div>
            <Navbar />
            <div className="min-h-screen w-full bg-black">
                <div className="p-10">
                    <h1 className="text-white text-5xl font-bold mb-10">
                        Popular Movies
                    </h1>
                    <MovieGrid
                        movies={movies}
                        onMovieClick={(movie) => console.log(movie.title)}
                    />
                </div>
            </div>
            <Footer />
        </div>
    );
};