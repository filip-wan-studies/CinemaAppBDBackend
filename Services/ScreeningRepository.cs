using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Services
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly bazdanContext _context;

        public ScreeningRepository(bazdanContext context)
        {
            _context = context;
        }

        public IEnumerable<Screening> GetScreenings()
        {
            return _context.Screenings.ToList();
        }

        public Screening GetScreening(int id)
        {
            return _context.Screenings.First(s => s.IdScreening == id);
        }
    }
}
