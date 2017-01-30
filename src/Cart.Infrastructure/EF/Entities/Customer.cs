using System.Collections;
using System.Collections.Generic;

namespace Cart.Infrastructure.EF.Entities
{
    public class Customer
    {
        #region Properties

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        #endregion
    }
}
