using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unicorn.Domain.Entities;
using Unicorn.Domain.Repositories;
using Unicorn.Domain.Helpers;
using Unicorn.WebLibrary.Config;
using Unicorn.WebLibrary.Helpers;

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
                return ErrorMessageHelper.INVALID_SIGIN;

            if (!customerSignIn.ConfirmDate.HasValue)
                return ErrorMessageHelper.ACCOUNT_NOT_ACTIVE;

            return MessageHelper.SUCCESS + customerSignIn.CustomerID.ToString().Trim() + "|" + customerSignIn.SignInName_hash + "|" + customerSignIn.SignInPassword_hash;

            //sample: return id.ToString().Trim() + siginname + "|" + signinpassword;
        }

        [HttpPost, ActionName("CreateCustomer")]
        public string CreateCustomer(string firstname, string lastname, string email, string phone, string password)
        {
            using (CustomerRepository customerRespository = new CustomerRepository(WebConfig.SystemUserID))
            { 

                Customer customer = customerRespository.CreateCustomer(firstname, lastname, email, phone, password);

                if (customer == null)
                    return ErrorMessageHelper.INVALID_SIGIN;

                EmailHelper.SendCustomerActivationEmail(customer);

                return MessageHelper.SUCCESS + customer.ID.ToString().Trim() + "|" + customer.FirstName + "|" + lastname;
            }
            //sample: return firstname + "|" + lastname + "|" + email +  "|" + phone + "|" + password;
        }

        [HttpGet, ActionName("Activate")]
        public string Activate(int id, string token)
        {
            CustomerSignInRepository customerSignInRespository = new CustomerSignInRepository(WebConfig.SystemUserID);

            CustomerSignIn customerSignIn = customerSignInRespository.GetCustomerSignIn(ConfigSignInType.Email, new Guid(token));

            if (customerSignIn == null)
                return ErrorMessageHelper.INVALID_TOKEN;
            else if (customerSignIn.ConfirmDate.HasValue)
                return ErrorMessageHelper.ACCOUNT_ALREADY_ACTIVE;


            customerSignIn = customerSignInRespository.ActivateSignIn(customerSignIn);

            if(customerSignIn==null)
            {
                return ErrorMessageHelper.GENERAL_SIGNIN_FAILURE;
            }

            return MessageHelper.ACCOUNT_ACTIVATED;

         
        
            //sample: return id.ToString().Trim() + siginname + "|" + signinpassword;
        }
    }

}
