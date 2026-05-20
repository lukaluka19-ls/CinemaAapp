import { api } from "./axios";
import { Reservation } from "../types";

export const getAllReservations = async () => {
  const response = await api.get("/reservations");

  return response.data;
};

export const getReservation = async (id: number) => {
  const response = await api.get(`/reservations/${id}`);

  return response.data;
};

export const createReservation = async (
  screeningId: number,
  seatIds: number,
) => {
  await api.post("/reservations", {
    screeningId,
    seatIds,
  });
};

export const deleteReservations = async (id: number) => {
  await api.delete(`/reservations/${id}`);
};
