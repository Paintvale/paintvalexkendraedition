using System;

namespace Paintvale.HLE.Exceptions
{
    public class InvalidSystemResourceException : Exception
    {
        public InvalidSystemResourceException(string message) : base(message) { }
    }
}
