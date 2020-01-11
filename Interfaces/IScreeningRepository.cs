using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    interface IScreeningRepository
    {
        IEnumerable<Screening> GetScreenings();
        Screening GetScreening(int id);
    }
}
