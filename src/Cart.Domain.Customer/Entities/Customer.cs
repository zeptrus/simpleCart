namespace Cart.Domain.Customer.Entities
{
    using Cart.Core.Entities;

    public class Customer : ICustomer
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
