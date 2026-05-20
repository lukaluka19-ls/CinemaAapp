import {
  GenreUpdateRequest,
  GenreResponse,
  GenreRequest,
  GenreResponseID,
} from "../types";

import { api } from "./axios";

export const getAllGenres = async () => {
  return await api.get<GenreResponse[]>("/genres");
};

export const getGenre = async (id: number) => {
  return await api.get<GenreResponseID>(`/genres/${id}`);
};

export const createGenre = async (request: GenreRequest) => {
  return await api.post<GenreResponse>("/genres", request);
};

export const updateGenre = async (request: GenreUpdateRequest) => {
  return await api.put<GenreResponse>(`/genres/${request.id}`, {
    name: request.name,
  });
};

export const deleteGenre = async (id: number) => {
  return await api.delete<void>(`/genres/${id}`);
};
