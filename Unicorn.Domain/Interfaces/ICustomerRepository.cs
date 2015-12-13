using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Domain.Entities;

namespace Unicorn.Domain.Interfaces
{
    /// <summary>
    /// Interface for defining the methods for performing CRUD operations 
    /// on the Customer table
    /// </summary>
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);

        Customer CreateCustomer(string firstname, string lastname, string email, string phone, string password);
    }
}
