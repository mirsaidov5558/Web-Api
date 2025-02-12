namespace WebApi.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryId { get; set; }
    }
}
