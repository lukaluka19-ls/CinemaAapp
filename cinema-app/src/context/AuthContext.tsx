import { createContext, useContext, useEffect, useState } from "react";

interface AuthContextType {
  isAuthenticated: boolean;
  role: string | null;
  token: string | null;
  logout: () => void;
  login: (token: string) => void;
}

// const login = (token: string) =>

const AuthContext = createContext<AuthContextType | undefined>(undefined); //kreiranje konteksta

interface Props {
  children: React.ReactNode;
}

export const AuthProvider = ({ children }: Props) => {
  const [token, setToken] = useState<string | null>(
    localStorage.getItem("token"),
  ); //koristimo kako bismo je pozvali naknadno i stavljamo je u app.tsx

  const [role, setRole] = useState<string | null>(null);

  useEffect(() => {
    if (token) {
      try {
        const payload = JSON.parse(atob(token.split(".")[1]));

        setRole(
          payload.role ||
            payload[
              "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" //trazi microsoft format claimsa koji ima u .Netu uzeto sa gpt iskreno
            ],
        );
      } catch {
        logout();
      }
    }
  }, [token]); //ceo ovaj tyrcatch gpt generated

  const logout = () => {
    localStorage.removeItem("token"); //brise token iz local storage da bi korisnik mogao da baci redirect na main page

    setToken(null); //setuje vrednost tokena na null

    setRole(null); //setuje vrednost rola na null
  };

  const login = (token: string) => {
    localStorage.setItem("token", token); //nakndadno dodato
    setToken(token);
  };

  return (
    <AuthContext.Provider
      value={{ isAuthenticated: !!token, role, token, logout, login }} //pozivanje
    >
      {children}
    </AuthContext.Provider> //Snabdevanje komponenti podacima (((Provider Return)))
  );
};
export const useAuth = () => {
  const context = useContext(AuthContext);

  if (!context) {
    throw new Error("App.tsx error");
  }
  return context;
};
