import React, { useState } from "react";
import { LoginDTO } from "../../../types";
import { login } from "../../../api/auth";
import { useNavigate } from "react-router-dom";
import slika from "../../../img/slika.jpg";
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

  const handleSubmit = async () => {
    await login(user)
      .then((res) => {
        // upisati u local storage
        localStorage.setItem("token", res.token);
        navigate("/");
      })
      .catch((err) => {
        console.log(err);
      })
      .finally(() => {
        console.log("login attempt finished");
      });

    // async/await ISTRAZITI

    // const response = await login(user);
    // if (response.token) {
    //     // upisati u local storage

    //     return;
    // }

    // clg
    // throw new Error("Login failed");
  };

  return (
    // <div className="object-cover">
    <div
      className="flex flex-col items-end p-36 min-h-screen w-full bg-cover bg-center"
      style={{
        backgroundImage: `url('${slika}')`,
      }}
    >
      <div className="bg-white w-3/12 items-center p-10 rounded-3xl shadow-2xl border border-gray-50">
        <h2 className="text-4xl font-serif text-black mb-6 text-center">
          Welcome back
        </h2>

        <div className="space-y-4 items-center">
          <input
            type="email"
            name="email"
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
            Login
          </button>
          <div className="text-center">
            <h2>Already have an account?</h2>
            <a href="/register" className="text-black hover:text-blue-700">
              <h3>Register</h3>
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};
