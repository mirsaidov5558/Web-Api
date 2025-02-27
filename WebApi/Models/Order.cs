using WebApi.Enums;

namespace WebApi.Models
{
    

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Status Status { get; set; } = Status.Pending;


        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
