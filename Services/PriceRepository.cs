using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Services
{
    public class PriceRepository : IPriceRepository
    {
        private readonly bazdanContext _context;

        public PriceRepository(bazdanContext context)
        {
            _context = context;
        }

        public IEnumerable<Price> GetPrices()
        {
            return _context.Prices.ToList();
        }
    }
}
