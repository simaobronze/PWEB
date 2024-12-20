namespace RESTfulAPI.Entities
{
        public class Category
        {
            public int Id { get; set; }
            public required string Name { get; set; }
            public int? ParentCategoryId { get; set; }
            public Category? ParentCategory { get; set; }
            public ICollection<Category>? SubCategories { get; set; }
            public int? ProductId { get; set; }
            public Product? Product { get; set; }
        }

    }

