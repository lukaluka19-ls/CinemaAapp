import React, { useEffect, useState } from "react";
import { LoginDTO, RegisterDTO } from "../../../types";
import { login, register } from "../../../api/auth";

import { Navigate, useNavigate } from "react-router-dom";
import { BackgroundSlider } from "../../../components/Carousel";

interface Props {}

interface RegisterUser {
  username: string;
  date: string;
  password: string;
  email: string;
}

export const RegisterForm = (props: Props) => {
  const [user, setUser] = useState<RegisterUser>({
    email: "",
    password: "",
    username: "",
    date: "",
  });

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value, title } = event.target;
    console.log(name, value);

    setUser((prevUser) => {
      return {
        ...prevUser!,
        [name]: value,
      };
    });
  };

  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async () => {
    setLoading(true);
    setError("");
    try {
      await register({
        name: user.username,
        dateOfBirth: user.date + "T00:00:00Z",
        email: user.email,
        password: user.password,
      });
      navigate("/login");
    } catch {
      setError("Registration failed. Email may already exist.");
    } finally {
      setLoading(false);
    }
  };

  const login = async () => navigate("/login");

  return (
    <BackgroundSlider>
      <div className="relative min-h-screen w-full overflow-hidden">
        <div className="relative z-10 flex flex-col items-end content-center justify-center min-h-screen w-full pb-16 pr-16">
          <div className="bg-white w-3/12 items-center p-10 rounded-3xl shadow-2xl border border-gray-50 bg-opacity-70">
            <h2 className="text-4xl font-serif text-black mb-6 text-center">
              Register
            </h2>

            <div className="space-y-4 items-center flex flex-col">
              <input
                type="text"
                name="username"
                placeholder="Username"
                value={user?.username}
                onChange={handleChange}
                className="w-full p-3 rounded-xl bg-white border"
              />
              <input
                type="date"
                name="date"
                placeholder="Date of birth"
                value={user?.date}
                onChange={handleChange}
                className="w-full p-3 rounded-xl bg-white border"
              />
              <input
                name="email"
                type="email"
                placeholder="Email"
                value={user?.email}
                onChange={handleChange}
                className="w-full p-3 rounded-xl bg-white border"
              />
              <input
                name="password"
                type="password"
                placeholder="Password"
                value={user?.password}
                onChange={handleChange}
                className="w-full p-3 rounded-xl bg-white border"
              />
              <button
                onClick={handleSubmit}
                className="w-full rounded-2xl bg-blue-700 hover:bg-blue-800 text-white font-bold py-2"
              >
                Register
              </button>
              <div className="text-center flex flex-col font-medium font-serif">
                <h2>Already have an account?</h2>
                <a href="/login" className="text-black hover:text-blue-700">
                  <button onClick={login}>
                    <h3>Login</h3>
                  </button>
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </BackgroundSlider>
  );
};
