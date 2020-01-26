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
        public IActionResult Post([FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Reservation response = null;
            if( reservation.Email != null)
                response = _repository.PostReservation(reservation.Email, reservation.Ticket.ScreeningId, reservation.Ticket.ScreenSeatId);
            else if(reservation.ClientId != null)
                response = _repository.PostReservation((uint)reservation.ClientId, reservation.Ticket.ScreeningId, reservation.Ticket.ScreenSeatId);

            if (response == null) return BadRequest();
            return Ok(response);
        }
    }
}