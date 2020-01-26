using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    public interface IReservationRepository
    {
        Reservation GetReservationById(int id);

        List<Reservation> GetReservationsByEmail(string email);

        Reservation PostReservation(string email, uint screeningId, uint screenSeatId);

        Reservation PutReservation(int id);
    }
}
