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
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _repository.GetClients();
        }

        [HttpGet("{id:int}")]
        public Client GetById([FromRoute] int id)
        {
            return _repository.GetClient(id);
        }

        [HttpGet("{email}")]
        public Client GetById([FromRoute] string email)
        {
            return _repository.GetClient(email);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _repository.PostClient(client);
            if (response == null) return BadRequest();
            return Ok(response);
        }
    }
}