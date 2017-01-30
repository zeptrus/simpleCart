namespace Cart.Domain.Order.Repositories
{
    using System;
    using System.Collections.Generic;
    using Core.Dal;
    using Entities;

    public interface IOrderRepository
    {
        IEnumerable<Order> GetByQuery(long customerId = 0);
        Order GetById(long id);
    }

    public class OrderRepository : IOrderRepository
    {
        #region Fields

        private readonly IOrderDal<Order> _orderDal;

        #endregion

        #region Constructors

        public OrderRepository(IOrderDal<Order> orderDal)
        {
            _orderDal = orderDal;
        }

        #endregion

        #region Public Methods

        public IEnumerable<Order> GetByQuery(long customerId = 0)
        {
            return this._orderDal.GetByQuery(customerId);
        }

        public Order GetById(long id)
        {
            return this._orderDal.GetById(id);
        }

        #endregion
    }
}
