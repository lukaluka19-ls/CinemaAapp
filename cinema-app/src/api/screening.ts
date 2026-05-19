import { api } from "./axios";
import { Screening } from "../types";

export const getAllScreenings = async () => {
  const response = await api.get("/movieScreenings");

  return response.data;
};

export const getScreening = async (id: number) => {
  const response = await api.get(`/movieScreenings/${id}`);

  return response.data;
};

export const createScreening = async (
  movieId: number,
  genreName: string,
  dateTime: string,
  totalSeats: number,
  ticketPrice: number,
  availableSeats: boolean,
  rating: number | null,
) => {
  await api.post("/genres", {
    movieId,
    genreName,
    dateTime,
    ticketPrice,
    totalSeats,
    availableSeats,
    rating,
  });
};
