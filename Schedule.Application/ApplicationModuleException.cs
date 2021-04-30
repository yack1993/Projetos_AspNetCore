using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application
{
    public class ApplicationModuleException : Exception
    {
        internal ApplicationModuleException(string businessMessage)
            : base(businessMessage)
        {

        }
    }
}
