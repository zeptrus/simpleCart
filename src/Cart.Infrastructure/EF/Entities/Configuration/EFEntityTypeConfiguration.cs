namespace Cart.Infrastructure.EF.Entities.Configuration
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;

    internal interface IEFEntityTypeConfiguration
    {
        void AddToModelBuilder(DbModelBuilder modelBuilder);
    }

    public abstract class EFEntityTypeConfiguration<T> :
        EntityTypeConfiguration<T>,
        IEFEntityTypeConfiguration
        where T : class
    {
        public void AddToModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(this);
        }
    }
}
