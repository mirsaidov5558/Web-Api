namespace WebApi.Models
{
    

    public class Orders
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public string Status { get; set; }

    }
}
