﻿using System;
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

        Reservation PostReservation(string email, int screeningId, int seatId);

        Reservation PutReservation(int id);
    }
}
