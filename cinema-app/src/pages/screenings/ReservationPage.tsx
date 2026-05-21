import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getScreeningId } from "../../api/screenings";
import { getSeatsByScreeningId } from "../../api/seats";
import { createReservation } from "../../api/reservations";
import { Screening, Seat } from "../../types";
import { useAuth } from "../../context/AuthContext";

export const ReservationPage = () => {
  const { id } = useParams<{ id: string }>();
  const [screening, setScreening] = useState<Screening | null>(null);
  const [seats, setSeats] = useState<Seat[]>([]);
  const [selectedSeats, setSelectedSeats] = useState<number[]>([]);
  const [guestEmail, setGuestEmail] = useState("");
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");
  const { user } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    if (!id) return;
    Promise.all([getScreeningId(Number(id)), getSeatsByScreeningId(Number(id))])
      .then(([screeningData, seatsData]) => {
        setScreening(screeningData);
        setSeats(seatsData);
      })
      .finally(() => setLoading(false));
  }, [id]);

  const toggleSeat = (seat: Seat) => {
    if (seat.status === "Occupied") return;
    setSelectedSeats((prev) =>
      prev.includes(seat.id)
        ? prev.filter((s) => s !== seat.id)
        : [...prev, seat.id],
    );
  };

  const getSeatColor = (seat: Seat) => {
    if (seat.status === "Occupied") return "bg-red-500 cursor-not-allowed";
    if (selectedSeats.includes(seat.id)) return "bg-white cursor-pointer";
    return "bg-green-500 cursor-pointer hover:bg-green-400";
  };

  const totalPrice = () => {
    if (!screening) return 0;
    const base = selectedSeats.length * screening.ticketPrice;
    return user ? base * 0.95 : base;
  };

  const handleReserve = async () => {
    if (selectedSeats.length === 0) {
      setError("Please select at least one seat.");
      return;
    }
    if (!user && !guestEmail) {
      setError("Please enter your email.");
      return;
    }
    try {
      const result = await createReservation({
        screeningId: Number(id),
        seatIds: selectedSeats,
        guestEmail: user ? undefined : guestEmail,
      });
      setSuccess(`Reservation successful! Code: ${result.uniqueCode}`);
      setTimeout(() => navigate("/my-reservations"), 2000);
    } catch {
      setError("Reservation failed. Please try again.");
    }
  };

  if (loading)
    return (
      <div className="flex items-center justify-center min-h-screen bg-gray-900">
        <p className="text-white text-xl">Loading...</p>
      </div>
    );

  if (!screening)
    return (
      <div className="flex items-center justify-center min-h-screen bg-gray-900">
        <p className="text-white text-xl">Screening not found.</p>
      </div>
    );
};
