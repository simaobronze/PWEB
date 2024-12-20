using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RESTfulAPI.Entities
{
    public class Order
    {
        [Required]
        public required int OrderId { get; set; }

        [Required]
        public required string CustomerId { get; set; } // Ligado ao sistema de autenticação
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public required ICollection<OrderItem> Items { get; set; }
        public decimal Total { get; set; }
        public required string Status { get; set; } // Pendente, Pago, Enviado, Entregue, Cancelado
        public required string UserId { get; set; } 
        public required User User { get; set; }
    }
}
