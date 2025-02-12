namespace WebApi.Models
{
    public class Reviews
    {
        public int ReviewsId {  get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
    }
}
