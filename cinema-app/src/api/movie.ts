import { api } from "./axios";
import { Movie } from "../types";

export const getAllMovies = async () => {
  const response = await api.get("/movies");

  return response.data;
};

export const getMovie = async (id: number) => {
  const response = await api.get(`/movies/${id}`);

  return response.data;
};

export const addMovie = async (
  name: string,
  originalName: string,
  duration: number,
  posterImageURL: string,
  genreName: string,
  averageRating: number,
) => {
  await api.post("/movies", {
    name,
    originalName,
    duration,
    posterImageURL,
    genreName,
    averageRating,
  });
};
