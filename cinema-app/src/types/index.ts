export interface AuthUser {
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

export interface GenreCreateRequest {
  name: string;
}

export interface GenreUpdateRequest {
  id: number;
  name: string;
}

export interface Movie {
  id: number;
  name: string;
  originalName: string;
  duration: number;
  posterImageUrl: string | null;
  genreId: number;
  genreName: string;
  averageRating: number | null;
}

export interface MovieCreateRequest {
  name: string;
  originalName: string;
  duration: number;
  genreId: number;
  posterImage?: File;
}

export interface MovieUpdateRequest {
  name?: string;
  originalName?: string;
  duration?: number;
  genreId?: number;
  posterImage?: File;
}

export interface Screening {
  id: number;
  movieId: number;
  movieName: string;
  posterImageUrl: string | null;
  genreName: string;
  dateTime: string;
  ticketPrice: number;
  totalSeats: number;
  availableSeats: number;
  isPast: boolean;
  averageRating: number | null;
}

export interface ScreeningCreateRequest {
  movieId: number;
  dateTime: string;
  ticketPrice: number;
  totalSeats: number;
}

export interface ScreeningUpdateRequest {
  dateTime?: string;
  ticketPrice?: number;
  totalSeats?: number;
}

export interface ScreeningFilter {
  date?: string;
  genreId?: number;
  sortBy?: string;
  sortOrder?: string;
  page?: number;
  pageSize?: number;
}

type SeatStatus = "Available" | "Occupied" | "Selected";

export interface Seat {
  id: number;
  seatNumber: number;
  status: SeatStatus;
}

export interface SeatCreateRequest {
  screeningId: number;
  seatNumber: number;
}

export interface Reservation {
  id: number;
  uniqueCode: string;
  movieName: string;
  posterImageUrl: string | null;
  screeningDateTime: string;
  ticketPrice: number;
  totalPrice: number;
  discountApplied: boolean;
  seatNumbers: number[];
  isCanceled: boolean;
  isPast: boolean;
  rating: number | null;
}

export interface ReservationCreateRequest {
  screeningId: number;
  seatIds: number[];
  guestEmail?: string;
}

export interface ReservationDetail {
  id: number;
  uniqueCode: string;
  movieName: string;
  posterImageUrl: string | null;
  screeningDateTime: string;
  ticketPrice: number;
  totalPrice: number;
  discountApplied: boolean;
  seats: Seat[];
  isCanceled: boolean;
  rating: number | null;
}

export interface Rating {
  id: number;
  stars: number;
  movieName: string;
  createdAt: string;
}

export interface RatingCreateRequest {
  reservationId: number;
  stars: number;
}

export interface Consumer {
  id: number;
  name: string;
  email: string;
  dateOfBirth: string;
  isBlocked: boolean;
  isVerified: boolean;
}

export interface ConsumerList {
  id: number;
  name: string;
  email: string;
  isBlocked: boolean;
  isVerified: boolean;
}

export interface PagedResponse<T> {
  items: T[];
  totalCount: number;
  page: number;
  pageSize: number;
  totalPages: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
}

export interface ApiResponse<T> {
  success: boolean;
  message: string | null;
  data: T | null;
}

export interface ErrorResponse {
  statusCode: number;
  message: string;
}
