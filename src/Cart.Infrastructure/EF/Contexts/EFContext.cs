namespace Cart.Infrastructure.EF.Contexts
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class EFContext : DbContext
    {
        public EFContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var onModelCreateHelper = new OnModelCreateHelper();
            onModelCreateHelper.AddEntityConfigurations(modelBuilder);
        }
    }
}
