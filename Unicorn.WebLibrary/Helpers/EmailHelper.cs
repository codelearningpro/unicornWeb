using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicorn.Domain.Entities;
using Unicorn.WebLibrary.Config;

namespace Unicorn.WebLibrary.Helpers
{
    public static class EmailHelper
    {

        public static void SendCustomerActivationEmail(Customer customer)
        {
            CustomerSignIn customerSign = customer.SignIns.First<CustomerSignIn>(x => x.SignInTypeID == 1);
            string to = customerSign.SignInName_hash;
            string subject = "Save with Sprout - Account activation.";
            string body = string.Format("Hi " + customer.FirstName + " " + customer.LastName +"!, you are one step away from saving money. " + Environment.NewLine + Environment.NewLine 
                + "Please click the following link to activate your account. " + Environment.NewLine + Environment.NewLine + "{0}/{1}/{2}", WebConfig.ACTIVATE_ACCOUNT_URL, customerSign.SignInTypeID, customerSign.Token);

            SendEmail(to, subject, body);
        }

        public static void SendEmail(string to, string subject, string body)
        {
            String FROM = WebConfig.ADMIN_EMAIL_ACCOUNT;  // Replace with your "From" address. This address must be verified.
            String TO = to;  // Replace with a "To" address. If your account is still in the // sandbox, this address must be verified.

            String SUBJECT = subject;
            String BODY = body;

            // Supply your SMTP credentials below. Note that your SMTP credentials are different from your AWS credentials.
            String SMTP_USERNAME = WebConfig.SMTP_USERNAME;  // Replace with your SMTP username. 
            String SMTP_PASSWORD = WebConfig.SMTP_PASSWORD;  // Replace with your SMTP password.

            // Amazon SES SMTP host name. This example uses the US West (Oregon) region.
            String HOST = WebConfig.SMTP_HOST;

            // Port we will connect to on the Amazon SES SMTP endpoint. We are choosing port 587 because we will use
            // STARTTLS to encrypt the connection.
            int PORT = WebConfig.SMTP_PORT;

            // Create an SMTP client with the specified host name and port.
            using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                // Create a network credential with your SMTP user name and password.
                client.Credentials = new System.Net.NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Use SSL when accessing Amazon SES. The SMTP session will begin on an unencrypted connection, and then 
                // the client will issue a STARTTLS command to upgrade to an encrypted connection using SSL.
                client.EnableSsl = true;

                // Send the email. 
                try
                {
                   client.Send(FROM, TO, SUBJECT, BODY);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }
    }
}
