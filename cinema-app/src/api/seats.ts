import { Seat, SeatCreateRequest } from "../types";
import { api } from "./axios";

export const getSeatsByScreeningId = async (screeningId: number) => {
    const response = await api.get<Seat[]>(`/seats/screening/${screeningId}`);
    return response.data;
};
