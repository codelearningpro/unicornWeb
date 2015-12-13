using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Domain.Entities;

namespace Unicorn.Domain.Interfaces
{
    /// <summary>
    /// Interface for defining the methods for performing CRUD operations 
    /// on the CustomerSignIn table
    /// </summary>
    interface ICustomerSignInRepository
    {
        #region Core
        IEnumerable<CustomerSignIn> GetCustomerSignIns();
        CustomerSignIn GetCustomerSignIn(int id);
        CustomerSignIn CreateCustomerSignIn(CustomerSignIn customer);
        CustomerSignIn UpdateCustomerSignIn(CustomerSignIn customer);
        bool DeleteCustomerSignIn(int id);
        #endregion

        CustomerSignIn GetCustomerSignIn(ConfigSignInType signInTypeID, string signInName_hash, string signInPassword_hash);
    }
}
