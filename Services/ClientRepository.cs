using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppBackend.Services
{
    public class ClientRepository : IClientRepository
    {
        private readonly dbContext _context;

        public ClientRepository(dbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetClients()
        {
            var clients = _context.Clients.ToList();
            foreach (var client in clients)
            {
                client.Secret = null;
            }

            return clients;
        }

        public Client GetClient(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null) return null;
            client.Secret = null;
            return client;
        }

        public Client GetClient(string email)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Email == email);
            if (client == null) return null;
            client.Secret = null;
            return client;
        }

        public Client PostClient(Client client)
        {
            var existingClient = GetClient(client.Email);
            if (existingClient != null) return null;
            Client newClient = new Client
            {
                Email = client.Email, Name = client.Name, PhoneNumber = client.PhoneNumber, Surname = client.Surname,
                Secret = client.Secret
            };
            _context.Clients.Add(newClient);
            _context.SaveChanges();
            newClient.Secret = null;
            return newClient;
        }

        public Client PutClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
