namespace WebApi.Dtos
{
    public class CategoryUpdateDto
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
