using System.ComponentModel.DataAnnotations;

namespace CinemaAppBackend.Models
{
    public class AuthenticateModel
    {
        [Required] public string Email { get; set; }

        [Required]
        public string Secret { get; set; }
    }
}
