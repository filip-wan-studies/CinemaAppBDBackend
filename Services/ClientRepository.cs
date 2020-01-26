using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CinemaAppBackend.Services
{
    public class ClientRepository : IClientRepository
    {
        private readonly dbContext _context;

        private readonly AppSettings _appSettings;
        
        public ClientRepository(dbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public Client Authenticate(string email, string password)
        {
            var client = _context.Clients.SingleOrDefault(x => x.Email == email && x.Secret == password);

            if (client == null)
                return null;

            client.Secret = createToken(client.Id);

            return client;
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

            newClient.Secret = createToken(newClient.Id);
            return newClient;

        }

        public Client PutClient(Client client)
        {
            throw new NotImplementedException();
        }

        private string createToken(uint id)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
