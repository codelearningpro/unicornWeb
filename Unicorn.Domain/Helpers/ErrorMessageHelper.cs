using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unicorn.Domain.Helpers
{
    public static class ErrorMessageHelper
    {
        public static string GENERAL_SIGNIN_FAILURE = "GENERAL_SIGNIN_FAILURE";

        public static string INVALID_SIGIN = "INVALID_SIGNIN";

        public static string INVALID_TOKEN = "INVALID_TOKEN";

        public static string ACCOUNT_ALREADY_ACTIVE = "ACCOUNT_ALREADY_ACTIVE";

        public static string ACCOUNT_NOT_ACTIVE = "ACCOUNT_NOT_ACTIVE";
    }
}
