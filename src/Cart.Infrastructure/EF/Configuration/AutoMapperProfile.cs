namespace Cart.Infrastructure.EF.Configuration
{
    using AutoMapper;
    using Entities;

    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Customer, Domain.Customer.Entities.Customer>();
            CreateMap<Order, Domain.Order.Entities.Order>();
        }
    }
}
