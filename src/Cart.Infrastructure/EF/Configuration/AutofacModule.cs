namespace Cart.Infrastructure.EF.Configuration
{
    using Autofac;
    using AutoMapper;
    using Contexts;
    using Core.Dal;
    using Dal;

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutoMapperProfile>().As<Profile>().SingleInstance();
            builder.RegisterType<DBContextFactory>().As<IDBContextFactory>().SingleInstance();

            builder.RegisterGeneric(typeof(CustomerDal<>)).As(typeof(ICustomerDal<>)).SingleInstance();
            builder.RegisterGeneric(typeof(OrderDal<>)).As(typeof(IOrderDal<>)).SingleInstance();
        }
    }
}
