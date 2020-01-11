using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Services
{
    public class PricesRepository : IPricesRepository
    {
        private readonly bazdanContext _context;

        public PricesRepository(bazdanContext context)
        {
            _context = context;
        }

        public IEnumerable<Prices> GetPrices()
        {
            return _context.Prices.ToList();
        }
    }
}
