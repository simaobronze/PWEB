namespace RESTfulAPI.Entities
{
    public class Availability
    {
        public int Id { get; set; }
        public string Mode { get; set; } //Peso, Unidade, Litro, etc...
        public string Size { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
