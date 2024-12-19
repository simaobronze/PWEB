namespace RESTfulAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } // Ligado ao sistema de autenticação
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public ICollection<OrderItem> Items { get; set; }
        public decimal Total { get; set; }
    }
}
