import { Rating, RatingCreateRequest } from "../types";
import { api } from "./axios";

export const getAllratings = async () => {
  return await api.get<Rating>("/ratings");
};

export const getRating = async (id: number) => {
  return await api.get<Rating>(`/ratings/${id}`);
};

export const createGenre = async (request: RatingCreateRequest) => {
  return await api.post<Rating>("/ratings", request);
};

export const deleteRating = async (id: number) => {
  return await api.delete<void>(`/ratings/${id}`);
};
