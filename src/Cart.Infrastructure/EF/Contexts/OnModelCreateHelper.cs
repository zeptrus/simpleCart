namespace Cart.Infrastructure.EF.Contexts
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Entities.Configuration;

    internal class OnModelCreateHelper
    {
        internal void AddEntityConfigurations(DbModelBuilder modelBuilder)
        {
            var configurationInterfaceType = typeof(IEFEntityTypeConfiguration);

            var configurationInstances = configurationInterfaceType.Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(configurationInterfaceType))
                .Where(t => !t.IsAbstract)
                .Select(t => Activator.CreateInstance(t))
                .Cast<IEFEntityTypeConfiguration>();

            foreach (var configuration in configurationInstances)
            {
                configuration.AddToModelBuilder(modelBuilder);
            }
        }
    }
}
