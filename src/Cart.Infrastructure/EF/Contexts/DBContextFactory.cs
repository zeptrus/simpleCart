namespace Cart.Infrastructure.EF.Contexts
{
    using Microsoft.Extensions.Configuration;

    public interface IDBContextFactory
    {
        EFContext Create();
    }

    public class DBContextFactory : IDBContextFactory
    {
        #region Fields

        private readonly string _connectionString;

        #endregion

        #region Constructors

        public DBContextFactory(IConfiguration configuration)
        {
            _connectionString = configuration["Data:DefaultConnection:ConnectionString"].ToString();
        }

        #endregion

        #region Public Methods

        public EFContext Create()
        {
            return new EFContext(_connectionString);
        }

        #endregion
    }
}
