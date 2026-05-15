import api from "./axios";
import { AuthResponse, LoginDTO, RegisterDTO } from "../types"; //importuje interfejse iz types

export const login = async(dto:LoginDTO): Promise<AuthResponse> => { //izvozi dto objekat koji je u obliku LoginDTO //ovo promise znaci da obecava da sce vratiti podatke u obliku auth response
    const response = await api.post('/auth/login',dto);
    return response.data; // vraca podatke u apiju na putanji /auth/login dto
};

export const register = async(dto:RegisterDTO): Promise<void> => { //izvozi dto objekat koji je u obliku RegisterDTO // Promise kaze da const ne vraca nikakav podataak nakon uspesne registracije!
    await api.post('/auth/register',dto);// vraca u apiju zahtev na endpoint /auth/register sa podacima za registraciju // ceka se da server odradi zahtev i vrati potvrdu!
};

export const changePassword = async(dto:{ // definise change password
    currentPassword :string; //dodeljuje current 
    newPassword: string; // dodeljuje new
}): Promise<void> =>{ // obecava da nece vratiti nista!
    await api.post('/auth/change-password',dto) //dodeljuje putanju za changepassword
}