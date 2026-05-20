import { api } from "./axios";
import {
  GetReservationResponse,
  Reservation,
  ReservationRequest,
} from "../types";

export const getAllReservations = async () => {
  return await api.get<GetReservationResponse[]>("/reservations");
};

export const getReservation = async (id: number) => {
  return await api.get(`/reservations/${id}`);
};

export const createReservation = async (request: ReservationRequest) => {
  await api.post("/reservations", {});
};

export const deleteReservations = async (id: number) => {
  return await api.delete<void>(`/reservations/${id}`);
};
