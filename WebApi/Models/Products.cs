﻿namespace WebApi.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public int CategotyId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
