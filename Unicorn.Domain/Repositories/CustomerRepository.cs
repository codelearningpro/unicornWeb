using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Unicorn.Domain.Concrete;
using Unicorn.Domain.Interfaces;
using Unicorn.Domain.Entities;
using Unicorn.Domain.Repositories;

namespace Unicorn.Domain.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(int userID) : base(userID)
        {

        }

        /// <summary>
        /// Create customer and at least one customer sign in.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer CreateCustomer(Customer customer)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
            {
                ctx.Customer.Add(customer);
                ctx.SaveChanges();

                foreach (CustomerSignIn customerSignIn in customer.SignIns)
                {
                    customerSignIn.CustomerID = customer.ID;
                    customerSignIn.StartDate = DateTime.Now;
                    customerSignIn.ConfirmDate = DateTime.Now;
                    customerSignIn.Sequence = 1;
                    ctx.CustomerSignIn.Add(customerSignIn);

                    ctx.SaveChanges();
                }


                return customer;
            }
        }

        public bool DeleteCustomer(int id)
        {
            var customer = ctx.Customer.Where(x => x.ID == id).First();
            ctx.Customer.Remove(customer);
            if (ctx.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Customer GetCustomer(int id)
        {
            return ctx.Customer.Where(x => x.ID == id).First();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return ctx.Customer.AsEnumerable();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var c = ctx.Customer.Where(x => x.ID == customer.ID).First();

            if (c != null)
            {
                c.FirstName = customer.FirstName;
                c.LastName = customer.LastName;
                c.Status = customer.Status;
                ctx.SaveChanges();
            }
            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Customer CreateCustomer(string firstname, string lastname, string email, string phone, string password)
        {
            Customer customer = new Customer();
            customer.FirstName = firstname;
            customer.LastName = lastname;

            customer.SignIns = new List<CustomerSignIn>();

            CustomerSignIn emailSignIn = new CustomerSignIn();
            emailSignIn.SignInName_hash = email;
            emailSignIn.SignInPassword_hash = password;
            emailSignIn.SignInTypeID = (int)ConfigSignInType.Email;


            CustomerSignIn phoneSignIn = new CustomerSignIn();
            phoneSignIn.SignInName_hash = phone;
            phoneSignIn.SignInPassword_hash = password;
            phoneSignIn.SignInTypeID =  (int) ConfigSignInType.Phone;


            customer.SignIns.Add(emailSignIn);
            customer.SignIns.Add(phoneSignIn);

            return CreateCustomer(customer);
        }


    }
}

