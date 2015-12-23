using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace Unicorn.WebLibrary.Config
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class WebConfig
    {
        //TODO: The value must refactored from configuration raj/12/6/2015
        public static int SystemUserID
        {
            get { 
             return 1;
            }
        }

        public static string SMTP_HOST
        {
            get
            {
                return ConfigurationManager.AppSettings["SES.SMTP_HOST"];
            }
        }

        public static string SMTP_USERNAME
        {
            get
            {
                return ConfigurationManager.AppSettings["SES.SMTP_USERNAME"];
            }
        }


        public static string SMTP_PASSWORD
        {
            get
            {
                return ConfigurationManager.AppSettings["SES.SMTP_PASSWORD"];
            }
        }


        public static int SMTP_PORT
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["SES.SMTP_PORT"]);
            }
        }

        public static string ADMIN_EMAIL_ACCOUNT
        {
            get
            {
                return ConfigurationManager.AppSettings["ADMIN_EMAIL_ACCOUNT"];
            }
        }

        public static string ACTIVATE_ACCOUNT_URL
        {
            get
            {
                return ConfigurationManager.AppSettings["ACTIVATE_ACCOUNT_URL"];
            }
        }

    }
}
