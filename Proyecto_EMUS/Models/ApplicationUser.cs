using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        public string? address { get; set; }

    }
}
