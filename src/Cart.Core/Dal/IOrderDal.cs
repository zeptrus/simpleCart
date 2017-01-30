namespace Cart.Core.Dal
{
    using System.Collections.Generic;
    using Entities;

    public interface IOrderDal<T> where T : IOrder
    {
        IEnumerable<T> GetByQuery(long customerId);

        T GetById(long id);
    }
}
