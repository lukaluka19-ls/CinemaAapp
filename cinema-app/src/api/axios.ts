import axios from "axios";
// import { error } from "console";
// import { config } from "process";

const api = axios.create({
    baseURL: 'https://localhost:4000/api',
});

//dodavanje jwt tokena u svaki request

api.interceptors.request.use((config) => { ///axios istanca presetne api zahtev pre nego sto ode prema serveru
    const token = localStorage.getItem('token'); ///iz local storage se dohvata spremljeni kljuc - 'token'
    if (token){ //ako token u opste postoji
        config.headers.Authorization = `Bearer ${token};` //stavi u header token
    }
    return config; //vrati konfiguraciju zahteva u zaglavlje u formatu 'Bearer ${token}'
});
//logika ako token istekne redirectovace se na login

api.interceptors.response.use( //pravi presretaca koji obradjuje odgovore sa servera pre nego sto stignu do try-catch blokova.
    (Response) => Response, //Ako je Http upsesan prosledjuje nepromenjen odgovor!
    (error) =>{ // Ako server vrati gresku 
        if (error.response?.status === 401){ //ispisuje ovo
            localStorage.removeItem('token'); //Ako i jer je token istekao brise ga iz local storage 
            window.location.href = '/login'; //osvezavanje stranice
        }
        return Promise.reject(error); //vraca gresku u apk
    }
);

export default api