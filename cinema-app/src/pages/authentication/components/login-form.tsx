import React, { useEffect, useState } from "react";
import { LoginDTO } from "../../../types";
import { login } from "../../../api/auth";
import { useNavigate } from "react-router-dom";
import slika2 from "../../../img/slika2.jpg";
import slika3 from "../../../img/slika3.jpg";
import slika4 from "../../../img/slika4.jpg";
import slika5 from "../../../img/slika5.jpg";
import { useAuth } from "../../../context/AuthContext";

interface Props {}

export const LoginForm = (props: Props) => {
  const navigate = useNavigate();

  const [user, setUser] = useState<LoginDTO>({
    password: "",
    email: "",
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

      <div className="relative z-10 flex flex-col items-end p-36 min-h-screen w-full">
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
    </div>
  );
};

// import { Link, useNavigate } from "react-router-dom";
// import React from "react";

// export const NavbarForm = (props: Props) => {
//   const { isAuthenticated, role, logout };

//   const navigate = useNavigate();

//   const handleLogout = () => {
//     logout();
//     navigate("/login");
//   };
// };

// return (
//   <>
//     <nav className="">
//       <Link></Link>
//       <div className="Navigacioni">
//         <Link>MyReservations</Link>
//         <Link>Admin</Link>
//         <Link>Logout</Link>
//         <Link>Login</Link>
//         <Link>Register</Link>
//       </div>
//     </nav>
//   </>
// );
