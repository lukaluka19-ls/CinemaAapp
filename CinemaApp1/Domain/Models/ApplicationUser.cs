//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Domain.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public bool isBlocked { get; set; }


        public ICollection<Reservation> Reservations { get; set; } = [];
    }
}
 