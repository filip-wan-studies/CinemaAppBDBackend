
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
            var reservations = _context.Reservations.Where(r => r.Email == email || r.Client.Email == email).Include("Client").Include("Ticket").ToList();
            reservations.ForEach(r =>
            {
                if (r.Client.Id == 0) r.Client = null;
                else
                    r.Client.Reservations = null;
                r.Ticket.Reservations = null;
            });
            return reservations;
        }

        public Reservation PostReservation(string email, uint screeningId, ushort seatId)
        {
            var seat = _context.Seats.Single(s => s.Id == seatId);
            if (seat.IsReserved == true) return null;
            seat.IsReserved = true;
            var ticket = new Ticket{ScreeningId = screeningId, SeatId = seatId};
            var reservation = new Reservation {Email = email, SubmissionDate = DateTime.Now, Ticket = ticket, Client = null};
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            reservation.Ticket.Reservations = null;
            reservation.Ticket.Seat.Tickets = null;
            return reservation;
        }

        public Reservation PutReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);
            return reservation;
        }
    }
}
