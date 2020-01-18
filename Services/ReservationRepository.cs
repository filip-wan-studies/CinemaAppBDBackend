
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
            var client = _context.Reservations.Include("Client").SingleOrDefault(r => r.Id == id);
            client.Client.Reservations = null;
            return client;
        }

        public List<Reservation> GetReservationsByEmail(string email)
        {
            var clients = _context.Reservations.Where(r => r.Email == email || r.Client.Email == email).Include("Client").ToList();
            clients.ForEach(c => c.Client.Reservations = null);
            return clients;
        }

        public Reservation PostReservation(string email, int screeningId, int seatId)
        {
            var ticket = new Ticket{ScreeningId = screeningId, SeatId = seatId};
            var reservation = new Reservation {Email = email, SubmissionDate = DateTime.Now, Ticket = ticket};
            _context.Reservations.Add(reservation);
            return _context.Reservations.FirstOrDefault(r => reservation.Email == r.Email);
        }

        public Reservation PutReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);
            return reservation;
        }
    }
}
