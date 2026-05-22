import { api } from "./axios";
import { Movie, MovieCreateRequest, MovieUpdateRequest } from "../types";

export const getAllMovies = async () => {
  return await api.get<Movie[]>("/movies");
};

export const getGenre = async (id: number) => {
  return await api.get<Movie>(`/movies/${id}`);
};

export const createGenre = async (request: MovieCreateRequest) => {
  return await api.post<Movie>("/movies", request);
};

// export const updateGenre = async (request: MovieUpdateRequest) => {
//   return await api.put<Movie>(`/movies/${request.id}`, {
//     name: request.name,
//   });
// };

export const deleteGenre = async (id: number) => {
  return await api.delete<void>(`/movies/${id}`);
};
