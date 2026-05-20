import { Seat, SeatCreateRequest } from "../types";
import { api } from "./axios";

export const getAllSeats = async () => {
  return await api.get<Seat[]>("/seats");
};

export const getSeat = async (id: number) => {
  return await api.get<Seat>(`/seats/${id}`);
};

export const createGenre = async (request: SeatCreateRequest) => {
  return await api.post<Seat>("/seats", request);
};

export const deleteSeat = async (id: number) => {
  return await api.delete<void>(`/seats/${id}`);
};
