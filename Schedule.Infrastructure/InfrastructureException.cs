using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Infrastructure
{
    public class InfrastructureException : Exception
    {
        internal InfrastructureException(string businessMessage)
            : base(businessMessage)
        {

        }
    }
}
