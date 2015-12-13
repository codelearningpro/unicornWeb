using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
