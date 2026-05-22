import { api } from "./axios";
import {
  Reservation,
  ReservationCreateRequest,
  ReservationDetail,
} from "../types";

export const getReservationById = async (
  id: number,
) => {
  const response = await api.get<ReservationDetail>(`/reservations/${id}`);
  return response.data;
};

export const getMyReservations = async () => {
  const reposne = await api.get<Reservation[]>(`/reservations/my`);
  return reposne.data;
};

export const createReservation = async (
  dto: ReservationCreateRequest,
) => {
  const response = await api.post<Reservation>("/reservations", dto);
  return response.data;
};

export const cancelReservation = async (id: number) => {
  await api.delete<void>(`/response/${id}`);
};
