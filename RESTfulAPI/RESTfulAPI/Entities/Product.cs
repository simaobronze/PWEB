namespace RESTfulAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public ICollection <Availability> Availabilities{ get; set; }
        public ICollection <Category> Categories { get; set; }
    }
}
