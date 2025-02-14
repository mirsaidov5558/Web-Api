namespace WebApi.Models
{
    public class Review
    {
        public int Id {  get; set; }
        public int UserUid { get; set; }
        public int ProductId { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }


        public User User { get; set; }
        public Product Product { get; set; }
    }
}
