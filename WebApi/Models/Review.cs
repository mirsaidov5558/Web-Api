namespace WebApi.Models
{
    public class Review
    {
        public int Id {  get; set; }
        public User UserId { get; set; }
        public Product ProductId { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
    }
}
