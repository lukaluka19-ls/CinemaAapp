import React, { useEffect, useState } from "react";
import { LoginDTO, RegisterDTO } from "../../../types";
import { login, register } from "../../../api/auth";
import slika2 from "../../../img/slika2.jpg";
import slika3 from "../../../img/slika3.jpg";
import slika4 from "../../../img/slika4.jpg";
import slika5 from "../../../img/slika5.jpg";
import { Navigate, useNavigate } from "react-router-dom";

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

  const images = [slika3, slika2, slika4, slika5];
  const [currentImage, setCurrentImage] = useState(0);

  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentImage((prev) => (prev + 1) % images.length);
    }, 4000);

    return () => clearInterval(interval);
  }, []);

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
    <div className="relative min-h-screen w-full overflow-hidden">
      {images.map((image, index) => (
        <div
          key={index}
          className={`absolute inset-0 bg-cover bg-center transition-opacity duration-1000 ${
            index === currentImage ? "opacity-100" : "opacity-0"
          }`}
          style={{
            backgroundImage: `url('${image}')`,
          }}
        />
      ))}

      <div className="relative z-10 flex flex-col items-end p-36 min-h-screen w-full font-serif">
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
                <button onClick={login}>
                  <h3>Login</h3>
                </button>
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
