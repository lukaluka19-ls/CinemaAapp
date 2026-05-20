import { api } from "./axios";
import {
  Reservation,
  ReservationCreateRequest,
  ReservationDetail,
} from "../types";

export const getAllReservations = async () => {
  return await api.get<Reservation[]>("/reservations");
};

export const getReservation = async (request: ReservationDetail) => {
  return await api.get<Reservation>(`/reservations/${request}`);
};

export const createGenre = async (request: ReservationCreateRequest) => {
  return await api.post<Reservation>("/reservations", request);
};

export const deleteReservations = async (id: number) => {
  return await api.delete<void>(`/reservations/${id}`);
};
