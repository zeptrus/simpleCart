namespace Cart.Domain.Customer.Repositories
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Dal;

    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(long id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        #region Fields

        private readonly ICustomerDal<Customer> _customerDal;

        #endregion

        #region Constructors

        public CustomerRepository(ICustomerDal<Customer> customerDal)
        {
            _customerDal = customerDal;
        }

        #endregion

        #region Public Methods

        #endregion
        public IEnumerable<Customer> GetAll()
        {
            return this._customerDal.GetAll();
        }

        public Customer GetById(long id)
        {
            return this._customerDal.GetById(id);
        }
    }
}
