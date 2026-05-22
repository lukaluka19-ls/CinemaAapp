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
  return (
    <div
      className="min-h-screen bg-cover bg-center relative"
      style={{
        backgroundImage: screening.posterImageUrl
          ? `url(${screening.posterImageUrl})`
          : undefined,
      }}
    >
      <div className="absolute inset-0 bg-black bg-opacity-70" />

      <div className="relative z-10 flex flex-col items-center p-8">
        <h1 className="text-4xl font-bold text-white mb-2">
          {screening.movieName}
        </h1>
        <p className="text-gray-300 mb-8">
          {new Date(screening.dateTime).toLocaleString()} •{" "}
          {screening.genreName}
        </p>

        <div className="flex gap-12 w-full max-w-6xl">
          <div className="flex-1">
            <h2 className="text-white text-xl font-bold mb-4 text-center">
              Seats
            </h2>

            <div className="w-full h-2 bg-white rounded-full mb-6 opacity-50" />
            <p className="text-center text-gray-400 mb-6 text-sm">SCREEN</p>

            <div className="grid grid-cols-10 gap-2">
              {seats.map((seat) => (
                <button
                  key={seat.id}
                  onClick={() => toggleSeat(seat)}
                  disabled={seat.status === "Occupied"}
                  className={`w-8 h-8 rounded-md text-xs font-bold text-black transition ${getSeatColor(seat)}`}
                >
                  {seat.seatNumber}
                </button>
              ))}
            </div>

            <div className="flex gap-6 mt-6 justify-center">
              <div className="flex items-center gap-2">
                <div className="w-4 h-4 bg-green-500 rounded" />
                <span className="text-gray-300 text-sm">Vacant</span>
              </div>
              <div className="flex items-center gap-2">
                <div className="w-4 h-4 bg-red-500 rounded" />
                <span className="text-gray-300 text-sm">Occupied</span>
              </div>
              <div className="flex items-center gap-2">
                <div className="w-4 h-4 bg-white rounded" />
                <span className="text-gray-300 text-sm">Selected</span>
              </div>
            </div>
          </div>

          <div className="bg-black bg-opacity-60 rounded-2xl p-6 w-72 h-fit">
            <h2 className="text-white text-xl font-bold mb-4">
              {screening.movieName}
            </h2>
            <div className="space-y-2 text-gray-300 text-sm mb-6">
              <p>Movie genre: {screening.genreName}</p>
              <p>Selected seats: {selectedSeats.length}</p>
              <p>Price per seat: {screening.ticketPrice}RSD</p>
              {user && <p className="text-green-400">5% discount applied!</p>}
              <p className="text-white text-lg font-bold mt-4">
                Final price: {totalPrice().toFixed(2)}RSD
              </p>
            </div>

            {!user && (
              <input
                type="email"
                placeholder="Your email (guest)"
                value={guestEmail}
                onChange={(e) => setGuestEmail(e.target.value)}
                className="w-full p-2 rounded bg-gray-700 text-white border border-gray-600 mb-4"
              />
            )}

            {error && <p className="text-red-400 text-sm mb-2">{error}</p>}
            {success && (
              <p className="text-green-400 text-sm mb-2">{success}</p>
            )}

            <div className="flex gap-2">
              <button
                onClick={() => navigate(-1)}
                className="flex-1 bg-gray-600 hover:bg-gray-500 text-white py-2 rounded-lg transition"
              >
                Back
              </button>
              <button
                onClick={handleReserve}
                disabled={selectedSeats.length === 0}
                className="flex-1 bg-blue-600 hover:bg-blue-700 disabled:bg-gray-600 disabled:cursor-not-allowed text-white py-2 rounded-lg transition"
              >
                Reserve
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
