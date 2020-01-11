using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Services
{
    public class ScreeningsRepository : IScreeningsRepository
    {
        private readonly bazdanContext _context;

        public ScreeningsRepository(bazdanContext context)
        {
            _context = context;
        }

        public IEnumerable<Screenings> GetScreenings()
        {
            return _context.Screenings.ToList();
        }

        public Screenings GetScreening(int id)
        {
            return _context.Screenings.First(s => s.IdScreening == id);
        }
    }
}
