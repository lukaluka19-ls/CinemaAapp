import React from "react";
import { LoginPage, RegisterPage, HomePage } from "./pages";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { ScreeningsPage } from "./pages/screenings/ScreeningsPage";
import { ReservationPage } from "./pages/screenings/ReservationPage";

function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          {/* <Route path="/s" element={<ScreeningsPage />} />
          <Route path="/screenings/:id" element={<ReservationPage />} /> */}
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}
export default App;
