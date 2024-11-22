﻿namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime? ShippedDate { get; set; }
        public string? Status { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
