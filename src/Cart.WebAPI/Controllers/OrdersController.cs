namespace Cart.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using Domain.Order.Entities;
    using Domain.Order.Repositories;
    using Microsoft.AspNet.Mvc;

    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        #region Fields

        private readonly IOrderRepository _orderRepository;

        #endregion

        #region Constructors

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        #endregion

        #region Public Methods
        [HttpGet]
        public IEnumerable<Order> GetByQuery()
        {
            var test = Request.Query;
            long customerId = 0;
            if (Request.Query.Keys.Contains("customerId"))
            {
                long.TryParse(Request.Query["customerId"], out customerId);
            }
            return _orderRepository.GetByQuery(customerId: customerId);
        }

        [HttpGet]
        [Route("{id}")]
        public Order GetById(long id)
        {
            return _orderRepository.GetById(id);
        }

        #endregion
    }
}
