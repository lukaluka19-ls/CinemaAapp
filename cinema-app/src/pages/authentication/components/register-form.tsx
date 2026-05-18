import React, { useState } from "react";
import { LoginDTO, RegisterDTO } from "../../../types";
import { login, register } from "../../../api/auth";
import slika from "../../../img/slika.jpg";
import { Navigate } from "react-router-dom";

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

const handleSubmit = async () => {
    setLoading(true);
    setError("");
    try {
      await register({
        name: user.username,
        dateOfBirth: user.date,
        email: user.email,
        password: user.password,
      });
      Navigate("/login");
    } catch {
      setError("Registration failed. Email may already exist.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div
      className="flex flex-col items-end p-36 min-h-screen w-full bg-cover bg-center"
      style={{
        backgroundImage: `url('${slika}')`,
      }}
    >
      <div className="bg-white w-3/12 items-center p-10 rounded-3xl shadow-2xl border border-gray-50">
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
            className="w-full p-3 rounded-xl bg-white border border-black"
          />
          <input
            type="date"
            name="date"
            placeholder="Date of birth"
            value={user?.date}
            onChange={handleChange}
            className="w-full p-3 rounded-xl bg-white border border-black"
          />
          <input
            name="email"
            type="email"
            placeholder="Email"
            value={user?.email}
            onChange={handleChange}
            className="w-full p-3 rounded-xl bg-white border border-black"
          />
          <input
            name="password"
            type="password"
            placeholder="Password"
            value={user?.password}
            onChange={handleChange}
            className="w-full p-3 rounded-xl bg-white border border-black"
          />
          <button
            onClick={handleSubmit}
            className="w-full bg-black rounded-xl hover:bg-blue-700 text-white font-bold py-2"
          >
            Register
          </button>
          <div className="text-center">
            <h2>Already have an account?</h2>
            <a href="/login" className="text-black hover:text-blue-700">
              <h3>Login</h3>
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};
