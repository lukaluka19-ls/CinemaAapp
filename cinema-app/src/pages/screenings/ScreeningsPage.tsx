import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getAllScreenings } from "../../api/screenings";
import { Screening, ScreeningFilter } from "../../types";

export const ScreeningsPage = () => {
  const [screenings, setScreenings] = useState<Screening[]>([]);
  const [filter, setFilter] = useState<ScreeningFilter>({});
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    getAllScreenings(filter)
      .then(setScreenings)
      .finally(() => setLoading(false));
  }, [filter]);

  if (loading)
    return (
      <div className="flex items-center justify-center min-h-screen bg-gray-900">
        <p className="text-white text-xl">Loading...</p>
      </div>
    );

  // return (
  //   <div className="min-h-screen bg-gray-900 p-8">
  //     <h1 className="text-3xl font-bold text-white mb-8">
  //       Available Screenings
  //     </h1>

  //     <div className="flex gap-4 mb-6">
  //       <input
  //         type="date"
  //         onChange={(e) => setFilter((f) => ({ ...f, date: e.target.value }))}
  //         className="p-2 rounded bg-gray-700 text-white border border-gray-600"
  //       />
  //       <select
  //         onChange={(e) => setFilter((f) => ({ ...f, sortBy: e.target.value }))}
  //         className="p-2 rounded bg-gray-700 text-white border border-gray-600"
  //       >
  //         <option value="date">Sort by Date</option>
  //         <option value="name">Sort by Name</option>
  //       </select>
  //       <select
  //         onChange={(e) =>
  //           setFilter((f) => ({ ...f, sortOrder: e.target.value }))
  //         }
  //         className="p-2 rounded bg-gray-700 text-white border border-gray-600"
  //       >
  //         <option value="asc">Ascending</option>
  //         <option value="desc">Descending</option>
  //       </select>
  //     </div>

  //     <div className="space-y-4">
  //       {screenings.map((screening) => (
  //         <div
  //           key={screening.id}
  //           className="bg-gray-800 rounded-xl p-4 flex items-center gap-6 hover:bg-gray-700 transition cursor-pointer"
  //           onClick={() => navigate(`/screenings/${screening.id}`)}
  //         >
  //           {screening.posterImageUrl ? (
  //             <img
  //               src={screening.posterImageUrl}
  //               alt={screening.movieName}
  //               className="w-16 h-20 object-cover rounded"
  //             />
  //           ) : (
  //             <div className="w-16 h-20 bg-gray-600 rounded flex items-center justify-center">
  //               <span className="text-gray-400 text-2xl"></span>
  //             </div>
  //           )}

  //           <div className="flex-1">
  //             <h2 className="text-white text-xl font-bold">
  //               {screening.movieName}
  //             </h2>
  //             <p className="text-gray-400">{screening.genreName}</p>
  //             <p className="text-gray-400">
  //               {new Date(screening.dateTime).toLocaleString()}
  //             </p>
  //             {screening.averageRating && (
  //               <p className="text-yellow-400">
  //                  {screening.averageRating.toFixed(1)}
  //               </p>
  //             )}
  //           </div>

  //           <div className="text-right">
  //             <p className="text-white text-2xl font-bold">
  //               ${screening.ticketPrice}
  //             </p>
  //             <p className="text-gray-400">
  //               {screening.availableSeats} seats left
  //             </p>
  //             <button
  //               disabled={screening.isPast || screening.availableSeats === 0}
  //               className="mt-2 bg-blue-600 hover:bg-blue-700 disabled:bg-gray-600 disabled:cursor-not-allowed text-white px-4 py-2 rounded-lg transition"
  //             >
  //               {screening.isPast
  //                 ? "Past"
  //                 : screening.availableSeats === 0
  //                   ? "Full"
  //                   : "Reserve"}
  //             </button>
  //           </div>
  //         </div>
  //       ))}
  //     </div>
  //   </div>
  // );
};
