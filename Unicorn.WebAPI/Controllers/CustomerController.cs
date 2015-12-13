using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unicorn.Domain.Entities;
using Unicorn.Domain.Repositories;
using Unicorn.WebLibrary.Config;
using Unicorn.WebLibrary.Helper;

namespace Unicorn.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/customer
        public IEnumerable<string> Get()
        {
            //CustomerRepository customerRespository = new CustomerRepository(1);
            // Customer customer =  customerRespository.GetCustomer(1);

            return new string[] { "Coming", "Soon", "To", "Save", "Money", "And", "Grow" };
        }


        [HttpPost, ActionName("SignIn")]
        public string SignIn(int id, string signinname, string password)
        {
            CustomerSignInRepository customerSignInRespository = new CustomerSignInRepository(WebConfig.SystemUserID);
            CustomerSignIn customerSignIn = customerSignInRespository.GetCustomerSignIn(ConfigSignInType.Email, signinname, password);

            if (customerSignIn == null)
                return ErrorMessage.INVALID_SIGIN;

            return "SUCCESS:" + customerSignIn.CustomerID.ToString().Trim() + "|" + customerSignIn.SignInName_hash + "|" + customerSignIn.SignInPassword_hash;

            //sample: return id.ToString().Trim() + siginname + "|" + signinpassword;
        }

        [HttpPost, ActionName("CreateCustomer")]
        public string CreateCustomer(string firstname, string lastname, string email, string phone, string password)
        {

            CustomerRepository customerRespository = new CustomerRepository(WebConfig.SystemUserID);

            Customer customer = customerRespository.CreateCustomer(firstname, lastname, email, phone, password);

            if (customer == null)
                return ErrorMessage.INVALID_SIGIN;

            return "SUCCESS:" + customer.ID.ToString().Trim() + "|" + customer.FirstName + "|" + lastname;

            //sample: return firstname + "|" + lastname + "|" + email +  "|" + phone + "|" + password;
        }
    }

}
