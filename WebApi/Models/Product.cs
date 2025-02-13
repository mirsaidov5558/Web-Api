namespace WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Category CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        public List <Review> Reviews { get; set; }
    }
}
