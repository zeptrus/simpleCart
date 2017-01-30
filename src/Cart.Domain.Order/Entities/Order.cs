namespace Cart.Domain.Order.Entities
{
    using System;
    using Core.Entities;

    public class Order : IOrder
    {
        public long Id { get; set; }

        public decimal TotalPaid { get; set; }

        public DateTime DatePlaced { get; set; }

        public long CustomerId { get; set; }
    }
}
