using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RESTfulAPI.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        public required int OrderId { get; set; }
        public required Order Order { get; set; }
        public required int ProductId { get; set; }
        public required Product Product { get; set; }
        public required int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
