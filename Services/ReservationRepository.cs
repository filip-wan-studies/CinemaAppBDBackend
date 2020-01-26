
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
            var reservation = _context.Reservations.Include("Client").Include("Ticket.Screening.Film").Include("Ticket.ScreenSeat.Seat").SingleOrDefault(r => r.Id == id);
            if (reservation == null) return null;

            if(reservation.Client != null)
            {
                reservation.Client.Reservations = null;
                reservation.Client.Secret = null;
            }

            reservation.Ticket.Reservations = null;
            reservation.Ticket.Screening.Tickets = null;
            reservation.Ticket.Screening.Screenseats = null;
            reservation.Ticket.Screening.Film.Screenings = null;
            reservation.Ticket.ScreenSeat.Tickets = null;
            reservation.Ticket.ScreenSeat.Screening = null;
            reservation.Ticket.ScreenSeat.Seat.Screenseats = null;
            return reservation;
        }

        public List<Reservation> GetReservationsByEmail(string email)
        {
            var reservations = _context.Reservations.Where(r => r.Email == email || r.Client.Email == email).Include("Client").Include("Ticket.Screening.Film").Include("Ticket.ScreenSeat.Seat").ToList();
            if (reservations.Count == 0) return null;


            //var reservations = _context.Reservations.Where(r => r.Email == email || r.Client.Email == email).Include("Client").Include("Ticket").ToList();
            reservations.ForEach(r =>
            {
                if (r.Client.Id == 0) r.Client = null;
                else
                {
                    r.Client.Reservations = null;
                    r.Client.Secret = null;
                }
                r.Ticket.Reservations = null;
                r.Ticket.Screening.Tickets = null;
                r.Ticket.Screening.Screenseats = null;
                r.Ticket.Screening.Film.Screenings = null;
                r.Ticket.ScreenSeat.Tickets = null;
                r.Ticket.ScreenSeat.Screening = null;
                r.Ticket.ScreenSeat.Seat.Screenseats = null;
            });
            return reservations;
        }

        public Reservation PostReservation(string email, uint screeningId, uint screenSeatId)
        {
            var screenSeat = _context.Screenseats.Single(s => s.Id == screenSeatId);
            if (screenSeat.IsReserved) return null;
            screenSeat.IsReserved = true;
            var ticket = new Ticket{ScreeningId = screeningId, ScreenSeatId = screenSeatId };
            var reservation = new Reservation {Email = email, SubmissionDate = DateTime.Now, Ticket = ticket, Client = null};
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            reservation.Ticket.Reservations = null;
            reservation.Ticket.ScreenSeat.Tickets = null;
            return reservation;
        }

        public Reservation PutReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);
            return reservation;
        }
    }
}
