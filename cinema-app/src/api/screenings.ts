import { api } from "./axios";
import { Screening, ScreeningCreateRequest, ScreeningFilter } from "../types";

export const getAllScreenings = async (
  filter?: ScreeningFilter,
): Promise<Screening[]> => {
  const response = await api.get<Screening[]>("/screenings", {
    params: filter,
  });
  return response.data;
};

export const getScreeningId = async (id: number): Promise<Screening> => {
  const response = await api.get<Screening>(`/screenings/${id}`);
  return response.data;
};

export const createScreening = async (
  request: ScreeningCreateRequest,
): Promise<Screening> => {
  const response = await api.post<Screening>("/screenings", request);
  return response.data;
};
export const deleteScreening = async (id: number) => {
  return await api.delete<void>(`/screenings/${id}`);
};
