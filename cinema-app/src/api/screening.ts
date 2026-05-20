import { api } from "./axios";
import { Screening, ScreeningCreateRequest } from "../types";

export const getAllScreenings = async () => {
  return await api.get<Screening[]>("/screenings");
};

export const getScreening = async (id: number) => {
  return await api.get<Screening>(`/screenings/${id}`);
};

export const createScreening = async (request: ScreeningCreateRequest) => {
  return await api.post<Screening>("/screenings", request);
};
export const deleteScreening = async (id: number) => {
  return await api.delete<void>(`/screenings/${id}`);
};
