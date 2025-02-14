namespace WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }

        public List <Review> Reviews { get; set; }
        public List <Category> OrderItems { get; set; }
    }
}
