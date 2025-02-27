using System;

namespace Paintvale.HLE.Exceptions
{
    class InternalServiceException : Exception
    {
        public InternalServiceException(string message) : base(message) { }
    }
}
