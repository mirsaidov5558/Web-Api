namespace WebApi.Dtos
{
    public class OrderUpdateDto
    {
        public int UserId { get; set; }  
        public string Status { get; set; }  
        public decimal TotalPrice { get; set; }
    }
}
