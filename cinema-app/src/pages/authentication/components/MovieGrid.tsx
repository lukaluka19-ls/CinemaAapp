import { MovieCard } from "./MovieCard";

interface Movie{
    title: string;
    image: string;
}

interface Props{
    movies: Movie[];
    onMovieClick?: (movie:Movie) => void
}

export const MovieGrid = ({movies, onMovieClick}:Props) =>{
    return (
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-8">
            {movies.map((movie, index) => (
                <MovieCard
                    key={index}
                    title={movie.title}
                    image={movie.image}
                    onClick={() => onMovieClick?.(movie)}
                />
            ))}
        </div>
    );
} 