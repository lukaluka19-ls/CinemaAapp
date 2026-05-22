import { useEffect, useState } from "react";
import { Reservation } from "../../types";
import { cancelReservation, getMyReservations } from "../../api/reservations";

export const MyResrervationsPage = () => {
  const [reservations, setReservations] = useState<Reservation[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getMyReservations()
      .then(setReservations)
      .finally(() => setLoading(false));
  }, []);

  const handleCancel = async (id: number) => {
        if (!window.confirm("Are you sure you want to cancel this reservation?")) return;
        try {
            await cancelReservation(id);
            setReservations(prev =>
                prev.map(r => r.id === id ? { ...r, isCanceled: true } : r)
            );
        } catch {
            alert("Cancel failed.");
        }
    };

    if (loading)
    return (
      <div className="flex items-center justify-center min-h-screen bg-gray-900">
        <p className="text-white text-xl">Loading...</p>
      </div>
    );
};


