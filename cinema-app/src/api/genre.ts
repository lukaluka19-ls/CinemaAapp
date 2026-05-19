import { Genre } from "../types";
import { api } from "./axios";

export const getAllGenres = async () => {
  const response = await api.get("/genres");

  return response.data;
};

export const getGenre = async (id: number) => {
  const response = await api.get(`/genres/${id}`);
  return response;
};

export const createGenre = async (name: string) => {
  await api.post("/genres", {
    name,
  });
};

export const updateGenre = async (id: number, name: string) => {
  await api.put(`/genres/${id}`, {
    name,
  });
};

export const deleteGenre = async (id: number) => {
  await api.delete(`/genres/${id}`);
};
