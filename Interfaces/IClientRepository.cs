using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int id);
        Client GetClient(string email);
        Client PostClient(Client client);
        Client PutClient(Client client);
    }
}
