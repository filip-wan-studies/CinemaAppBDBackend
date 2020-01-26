using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppBackend.Services
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly dbContext _context;

        public ScreeningRepository(dbContext context)
        {
            _context = context;
        }

        public IEnumerable<Screening> GetScreenings()
        {
            var screenings = _context.Screenings.AsNoTracking().Include("Film").ToList();
            screenings.ForEach(s => s.Film.Screenings = null);
            return screenings;
        }

        public Screening GetScreening(int id)
        {
            var screening = _context.Screenings.AsNoTracking().Include("Film").Include("Room.Seats").Include("Price").First(s => s.Id == id);
            screening.Film.Screenings = null;
            screening.Screenseats.Screenings = null;
            var seats = screening.Screenseats.Seats.ToList();
            seats.ForEach(s =>
            {
                s.Tickets = null;
                s.Room = null;
            });
            screening.Screenseats.Seats = seats;
            screening.Price.Screenings = null;
            return screening;
        }
    }
}
