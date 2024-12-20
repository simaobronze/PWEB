using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RESTfulAPI.Entities
{


    public class User : IdentityUser
    {
        // Propriedades adicionais
        [Required]
        [StringLength(100)]
        public required string FullName { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [Required]
        [StringLength(50)]
        public required string Role { get; set; } // Exemplo: Cliente, Anónimo, Administrador
        public ICollection<Order>? Orders { get; set; }
    }

}
