export interface User {
  id: number;
  name: string;
  email: string;
  role: string;
}

export interface AuthResponse {
  token: string;
  email: string;
  role: string;
}

export interface LoginDTO {
  email: string;
  password: string;
}

export interface RegisterDTO {
  name: string;
  dateOfBirth: string;
  email: string;
  password: string;
}

export interface Genre {
  id: number;
  name: string;
}

export interface Movie {
  id: number;
  name: string;
  originalName: string;
  duration: number;
  posterImageUrl: string;
  genreName: string;
  averageRating: number | null;
}

export interface Screening {
  id: number;
  movieName: string;
  posterImageUrl: string;
  genreName: string;
  dateTime: string;
  ticketPrice: number;
  availableSeats: number;
  isPast: boolean;
  averageRating: number | null;
}

type Status = "Available" | "Occupied";

export interface Seat {
  id: number;
  seatNumber: number;
  status: Status; // "Available", "Occupied"
}

export interface Reservation {
  id: number;
  uniqueCode: string;
  movieName: string;
  screeningDateTime: string;
  totalPrice: number;
  isPast: boolean;
  isCanceled: boolean;
  rating: number | null;
}

export interface LoginUser {
  username: string;
  password: string;
}
