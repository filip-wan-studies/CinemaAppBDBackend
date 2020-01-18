
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppBackend.Services
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly dbContext _context;

        public ReservationRepository(dbContext context)
        {
            _context = context;
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.SingleOrDefault(r => r.Id == id);
        }

        public List<Reservation> GetReservationsByEmail(string email)
        {
            return _context.Reservations.Where(r => r.Email == email).ToList();
        }

        public Reservation PostReservation(string email)
        {
            var t = new Ticket {};
            var reservation = new Reservation {Email = email, SubmissionDate = DateTime.Now};
            return _context.Reservations.Add(reservation).Entity;
        }

        public Reservation PutReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);
            return reservation;
        }
    }
}
