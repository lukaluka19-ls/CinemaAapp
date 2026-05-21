import { api } from "./axios";
import {
  Reservation,
  ReservationCreateRequest,
  ReservationDetail,
} from "../types";

export const getReservationById = async (
  id: number,
): Promise<ReservationDetail> => {
  const response = await api.get<ReservationDetail>(`/reservations/${id}`);
  return response.data;
};

export const getMyReservations = async (): Promise<Reservation[]> => {
  const reposne = await api.get<Reservation[]>(`/reservations/my`);
  return reposne.data;
};

export const createReservation = async (
  dto: ReservationCreateRequest,
): Promise<Reservation> => {
  const response = await api.post<Reservation>("/reservations", dto);
  return response.data;
};

export const cancleReservation = async (id: number): Promise<void> => {
  await api.delete<void>(`/response/${id}`);
};
