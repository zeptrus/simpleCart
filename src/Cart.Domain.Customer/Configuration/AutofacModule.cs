namespace Cart.Domain.Customer.Configuration
{
    using Autofac;
    using Repositories;

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
        }
    }
}