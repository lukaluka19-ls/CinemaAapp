import React, { useEffect, useState } from "react";
import { LoginDTO } from "../../../types";
import { login } from "../../../api/auth";
import { useNavigate } from "react-router-dom";

import { useAuth } from "../../../context/AuthContext";
import {BackgroundSlider} from "../../../components/Carousel";

interface Props {}

export const LoginForm = (props: Props) => {
  const navigate = useNavigate();

  const [user, setUser] = useState<LoginDTO>({
    password: "",
    email: "",
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

  const { login: authLogin } = useAuth(); //nije radilo jer nisam imao ni ovo
  const handleSubmit = async () => {
    try {
      const res = await login(user);
      authLogin(res.token);
      navigate("/");
    } catch (err) {
      console.log(err);
    }
  };
  return (
    <BackgroundSlider>
      <div className="relative z-10 flex flex-col items-end content-center justify-center min-h-screen w-full pb-16 pr-16">
        <div className="bg-white w-3/12 items-center p-10 rounded-3xl shadow-2xl border border-gray-50 bg-opacity-70">
          <h2 className="text-4xl font-medium font-serif text-black mb-6 text-center">
            Welcome back
          </h2>

          <div className="space-y-4 items-center">
            <input
              type="email"
              name="email"
              placeholder="Email"
              value={user?.email}
              onChange={handleChange}
              className="w-full p-3 rounded-xl bg-white border "
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
              Login
            </button>

            <div className="text-center flex flex-col text-pretty font-medium font-serif">
              <h2>Don't have an account?</h2>

              <a href="/register" className="text-black hover:text-blue-700">
                <h3>Register</h3>
              </a>
            </div>
          </div>
        </div>
      </div>
    </BackgroundSlider>
  );
};
