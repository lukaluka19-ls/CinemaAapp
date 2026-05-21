import { useEffect, useState } from "react";
import { Reservation } from "../../types";
import { getMyReservations } from "../../api/reservations";

export const MyResrervationsPage = () => {
  const [reservations, setReservations] = useState<Reservation[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getMyReservations()
      .then(setReservations)
      .finally(() => setLoading(false));
  }, []);
};
