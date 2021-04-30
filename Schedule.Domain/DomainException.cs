using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Domain
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage)
            : base(businessMessage)
        {

        }
    }
}
