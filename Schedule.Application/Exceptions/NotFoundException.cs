using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Exceptions
{
    internal sealed class NotFoundException : ApplicationException
    {
        internal NotFoundException(string message)
            : base(message)
        { }
    }
}
