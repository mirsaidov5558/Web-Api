﻿namespace WebApi.Dto.CategoryDtos;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentCategoryId {  get; set; } 
}

