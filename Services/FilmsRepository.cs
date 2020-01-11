using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Services
{
    public class FilmsRepository : IFilmsRepository
    {
        private readonly bazdanContext _context;

        public FilmsRepository(bazdanContext context)
        {
            _context = context;
        }

        public IEnumerable<Object> GetFilms()
        {
            return (from p in _context.Films join g in _context.Genres on p.IdGenre equals g.IdGenre select new { Title = p.Title, Genre = g.Name, Screenings = p.Screenings }).ToList();

            //var query = _context.Films.Join(_context.Genres, films => films.IdGenre, genres => genres.IdGenre,
            //    (films, genres) => new
            //    {

            //    }).ToList();
        }
    }
}
