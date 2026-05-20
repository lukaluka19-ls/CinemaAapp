import { useAuth } from "../context/AuthContext";
import React from "react";
import { Link, useNavigate } from "react-router-dom";

const Navbar: React.FC = () => {
  const auth = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    auth?.logout();
    navigate("/");
  };

  return (
    <nav className="w-full bg-black text-white px-6 py-4 flex items-center justify-between shadow-md font-bold px-10">
      <div className="flex items-center gap-7">
        <Link
          to="/"
          className="text-white text-2xl font-bold tracking-tight hover:opacity-80 transition-opacity"
        >
          CinemaApp<span className="text-red-500  ">.</span>
        </Link>
        {/* <Link to="/" className="hover:text-gray-300">
          Home
        </Link> */}
        {/* <Link to="/movies" className="hover:text-gray-300">
          Movies
        </Link> */}
        {auth?.role === "Consumer" && (
          <Link to="/reservations" className="hover:text-gray-300">
            My Reservations
          </Link>
        )}
        {auth?.role === "Consumer" && (
          <Link to="/screenings" className="hover:text-gray-300">
            Available Screenings
          </Link>
        )}
        {auth?.role === "Admin" && (
          <Link to="/admin" className="hover:text-gray-300">
            Admin
          </Link>
        )}
      </div>
      <div className="flex items-center gap-4">
        {!auth?.isAuthenticated ? (
          <>
            <Link to="/login" className="hover:text-gray-300">
              Login
            </Link>
            <Link to="/register" className="hover:text-gray-300">
              Register
            </Link>
          </>
        ) : (
          <>
            <span className="text text-red-600 font-bold">
              {auth.role ?? "User"}
            </span>

            <button
              onClick={handleLogout}
              className="bg-red-600 hover:bg-red-700 px-3 py-1 rounded"
            >
              Logout
            </button>
          </>
        )}
      </div>
    </nav>
  );
};
export default Navbar;
