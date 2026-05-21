import { Seat, SeatCreateRequest } from "../types";
import { api } from "./axios";

export const getSeatsByScreeningId = async (
  screeningId: number,
): Promise<Seat[]> => {
  const response = await api.get<Seat[]>(`/seats/${screeningId}`);
  return response.data;
};
