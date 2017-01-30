namespace Cart.Core.Dal
{
    using System.Collections.Generic;
    using Entities;

    public interface ICustomerDal<T> where T : ICustomer
    {
        IEnumerable<T> GetAll();

        T GetById(long id);
    }
}
