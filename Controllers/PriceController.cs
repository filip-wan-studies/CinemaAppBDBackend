using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceRepository _repository;

        public PriceController(IPriceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return _repository.GetPrices();
        }
    }
}