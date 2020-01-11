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
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;

        public FilmsController(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return _filmRepository.GetFilms();
        }
    }
}