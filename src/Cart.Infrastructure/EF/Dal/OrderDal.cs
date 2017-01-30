namespace Cart.Infrastructure.EF.Dal
{
    using Core.Entities;
    using Core.Dal;
    using System.Collections.Generic;
    using Entities;
    using Contexts;
    using System.Linq;
    using AutoMapper;

    public class OrderDal<T> : IOrderDal<T> where T : IOrder
    {
        #region Fields

        private readonly IDBContextFactory _dbContextFactory;

        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public OrderDal(IDBContextFactory dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public IEnumerable<T> GetByQuery(long customerId)
        {
            using (var ctx = _dbContextFactory.Create())
            {
                var query = ctx.Set<Order>().AsQueryable();
                if (customerId != 0)
                {
                    query = query.Where(x => x.CustomerId == customerId);
                }
                return _mapper.Map<IEnumerable<T>>(query.ToList());
            }
        }

        public T GetById(long id)
        {
            using (var ctx = _dbContextFactory.Create())
            {
                return _mapper.Map<T>(ctx.Set<Order>().Find(id));
            }
        }

        #endregion
    }
}
