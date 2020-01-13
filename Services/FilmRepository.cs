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
        private readonly bazdanContext _context;

        public FilmRepository(bazdanContext context)
        {
            _context = context;
        }

        public IEnumerable<Film> GetFilms()
        {
            return (
                    from f in _context.Films join g in _context.Genres on f.IdGenre equals g.IdGenre 
                    select new Film { GenreNavigation = g, IdFilm = f.IdFilm, IdGenre = f.IdGenre, IdImbd = f.IdImbd, Screenings = f.Screenings, Title = f.Title }
                ).ToList();
        }

        public Film GetFilm(int id)
        {
            return (
                    from f in _context.Films join g in _context.Genres on f.IdGenre equals g.IdGenre 
                    where f.IdFilm == id 
                    select new Film{GenreNavigation = g, IdFilm = f.IdFilm, IdGenre = f.IdGenre, IdImbd = f.IdImbd, Screenings = f.Screenings, Title = f.Title}
                ).FirstOrDefault();
        }
    }
}
