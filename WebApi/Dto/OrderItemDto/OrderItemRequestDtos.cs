﻿namespace WebApi.Dto.OrderItemDto
{
    public class OrderItemRequestDtos
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
