import { createContext, useContext, useEffect, useState } from "react";
import { jwtDecode } from "jwt-decode";
import { AuthUser } from "../types";
import { Token } from "typescript";

interface AuthContextType {
  isAuthenticated: boolean;
  user: AuthUser | null;
  logout: () => void;
  login: (token: string) => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined); //kreiranje konteksta

interface Props {
  children: React.ReactNode;
}

export const AuthProvider = ({ children }: Props) => {
  const [user, setUser] = useState<AuthUser | null>(() => {
    const token = localStorage.getItem("token");
    if (!token) return null;
    return jwtDecode<AuthUser>(token);
  });

  const logout = () => {
    localStorage.removeItem("token");
    setUser(null);
  };

  const login = (token: string) => {
    const decoded = jwtDecode<AuthUser>(token);
    setUser(decoded);
    localStorage.setItem("token", token); //nakndadno dodato
  };

  return (
    <AuthContext.Provider
      value={{
        user,
        login,
        logout,
        isAuthenticated: !!user, //povezivanje
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
export const useAuth = () => {
  const context = useContext(AuthContext);

  if (!context) {
    throw new Error("App.tsx error");
  }
  return context;
};

interface AuthContextType {
  user: AuthUser | null;
  login: (token: string) => void;
  logout: () => void;
  isAuthenticated: boolean;
}
