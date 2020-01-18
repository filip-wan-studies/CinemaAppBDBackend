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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _repository;

        public ReservationController(IReservationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{email}")]
        public IActionResult GetByEmail([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_repository.GetReservationsByEmail(email));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_repository.GetReservationById(id));
        }

        [HttpPost]
        public IActionResult Post([FromHeader] string email, [FromHeader] uint screeningId, [FromHeader] ushort seatId )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _repository.PostReservation(email, screeningId, seatId);
            if (response == null) return BadRequest();
            return Ok(response);
        }
    }
}