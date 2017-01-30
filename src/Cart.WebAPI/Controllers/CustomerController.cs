namespace Cart.UI.Controllers
{
    using System.Collections.Generic;
    using Domain.Customer.Entities;
    using Domain.Customer.Repositories;
    using Microsoft.AspNet.Mvc;

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        #region Fields

        private readonly ICustomerRepository _customerRepository;

        #endregion

        #region Constructors

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #endregion

        #region Public Methods
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Customer GetById(long id)
        {
            return _customerRepository.GetById(id);
        }

        #endregion
    }
}
