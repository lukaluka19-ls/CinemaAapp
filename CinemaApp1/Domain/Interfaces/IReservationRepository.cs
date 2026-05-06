using CinemaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Interfaces
{
    public interface IReservationRepository: IGenericRepository<Reservation>
    {
        Task<IEnumerable<Reservation>>GetByUserASync(int userId);
        Task<IEnumerable<Reservation>>GetByScreenign(int screeningId);
        Task<Reservation> GetByConfirmationCodeAsync(string confirmationCode);

    }
}
