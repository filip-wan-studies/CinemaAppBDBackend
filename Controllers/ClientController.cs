using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using CinemaAppBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAppBackend.Controllers
{
    [Authorize]
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
        public IActionResult Get()
        {
            return Ok(_repository.GetClients());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_repository.GetClient(id));
        }

        [HttpGet("{email}")]
        public IActionResult GetById([FromRoute] string email)
        {
            return Ok(_repository.GetClient(email));
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var client = _repository.Authenticate(model.Email, model.Secret);

            if (client == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(client);
        }

        [AllowAnonymous]
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