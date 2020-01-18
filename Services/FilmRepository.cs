using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppBackend.Services
{
    public class FilmRepository : IFilmRepository
    {
        private readonly dbContext _context;

        public FilmRepository(dbContext context)
        {
            _context = context;
        }

        public IEnumerable<Film> GetFilms()
        {
            return (
                    from f in _context.Films join g in _context.Genres on f.Genre.Id equals g.Id 
                    select new Film { Genre = g, Id = f.Id, ImdbId = f.ImdbId, Screenings = f.Screenings, Title = f.Title }
                ).ToList();
        }

        public Film GetFilm(int id)
        {
            return (
                    from f in _context.Films join g in _context.Genres on f.Genre.Id equals g.Id 
                    where f.Id == id 
                    select new Film{Genre = g, Id = f.Id, ImdbId = f.ImdbId, Screenings = f.Screenings, Title = f.Title}
                ).FirstOrDefault();
        }
    }
}
