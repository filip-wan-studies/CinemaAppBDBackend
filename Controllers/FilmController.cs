using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using CinemaAppBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository _repository;

        public FilmController(IFilmRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return _repository.GetFilms();
        }
    }
}