namespace Cart.Domain.Order.Configuration
{
    using Autofac;
    using Repositories;

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
        }
    }
}
