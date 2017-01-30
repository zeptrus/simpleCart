namespace Cart.Infrastructure.EF.Entities
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        #region Properties

        public long Id { get; set; }

        public decimal TotalPaid { get; set; }

        public DateTime DatePlaced { get; set; }

        public long CustomerId { get; set; }

        #endregion
    }
}
