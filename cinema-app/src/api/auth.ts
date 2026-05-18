import { api } from "./axios";
import { AuthResponse, LoginDTO, RegisterDTO } from "../types";

export const login = async (dto: LoginDTO): Promise<AuthResponse> => {
  //izvozi dto objekat koji je u obliku LoginDTO //ovo promise znaci da obecava da sce vratiti podatke u obliku auth response
  const response = await api.post("/auth/login", dto);
  return response.data; // vraca podatke u apiju na putanji /auth/login dto
};

export const register = async (dto: RegisterDTO): Promise<void> => {
  //izvozi dto objekat koji je u obliku RegisterDTO // Promise kaze da const ne vraca nikakav podataak nakon uspesne registracije!
  await api.post("/auth/register", dto); // vraca u apiju zahtev na endpoint /auth/register sa podacima za registraciju // ceka se da server odradi zahtev i vrati potvrdu!
};

export const changePassword = async (dto: {
  // definise change password
  currentPassword: string; //dodeljuje current
  newPassword: string; // dodeljuje new
}): Promise<void> => {
  // obecava da nece vratiti nista!
  await api.post("/auth/change-password", dto); //dodeljuje putanju za changepassword
};

/*
useState - core react developera - const[age,setAge] = useState(42)
useReducer - Koristi reducer funciton da azurira stanje - prihvata obe funkcije (reducer, initial state) i vraca stanje i otpremu 
const[age,setAge] = useState(reducer,42)
useSyncExternalStore() - dodavanje non react stanja u react
useEffect() -  1. Dodaje funkciju 2. Dodaje uslov stringu 3. Desava se update kada se brojac promeni


*/

// LoginPage.tsx
// login-page.tsx (search: -page)
