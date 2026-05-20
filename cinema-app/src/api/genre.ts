import { GenreUpdateRequest, GenreCreateRequest, Genre } from "../types";

import { api } from "./axios";

export const getAllGenres = async () => {
  return await api.get<Genre[]>("/genres");
};

export const getGenre = async (id: number) => {
  return await api.get<Genre>(`/genres/${id}`);
};

export const createGenre = async (request: GenreCreateRequest) => {
  return await api.post<Genre>("/genres", request);
};

export const updateGenre = async (request: GenreUpdateRequest) => {
  return await api.put<Genre>(`/genres/${request.id}`, {
    name: request.name,
  });
};

export const deleteGenre = async (id: number) => {
  return await api.delete<void>(`/genres/${id}`);
};
