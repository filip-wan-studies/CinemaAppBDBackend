using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningController : ControllerBase
    {
        private readonly IScreeningRepository _repository;

        public ScreeningController(IScreeningRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Screening> Get()
        {
            return _repository.GetScreenings();
        }
        
        [HttpGet("{id}")]
        public Screening GetById([FromRoute] int id)
        {
            return _repository.GetScreening(id);
        }
    }
}