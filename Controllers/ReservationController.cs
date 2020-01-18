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
        public IEnumerable<Reservation> GetByEmail([FromRoute] string email)
        {
            return _repository.GetReservationsByEmail(email);
        }

        [HttpGet("{id:int}")]
        public Reservation GetById([FromRoute] int id)
        {
            return _repository.GetReservationById(id);
        }

        [HttpPost]
        public Reservation Post([FromBody] Reservation reservation)
        {
            if (reservation.Email == null || reservation.Ticket == null || reservation.Ticket.ScreeningId == 0 ||
                reservation.Ticket.SeatId == 0) return null;
            return _repository.PostReservation(reservation.Email, reservation.Ticket.ScreeningId, reservation.Ticket.SeatId);
        }
    }
}