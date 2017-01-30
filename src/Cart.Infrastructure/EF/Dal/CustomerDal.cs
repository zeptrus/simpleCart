namespace Cart.Infrastructure.EF.Dal
{
    using Core.Entities;
    using Core.Dal;
    using Contexts;
    using AutoMapper;
    using Entities;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerDal<T> : ICustomerDal<T> where T : ICustomer
    {
        #region Fields

        private readonly IDBContextFactory _dbContextFactory;

        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public CustomerDal(IDBContextFactory dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public IEnumerable<T> GetAll()
        {
            using (var ctx = _dbContextFactory.Create())
            {
                return _mapper.Map<IEnumerable<T>>(ctx.Set<Customer>().ToList());
            }
        }

        public T GetById(long id)
        {
            using (var ctx = _dbContextFactory.Create())
            {
                return _mapper.Map<T>(ctx.Set<Customer>().Find(id));
            }
        }

        #endregion
    }
}
