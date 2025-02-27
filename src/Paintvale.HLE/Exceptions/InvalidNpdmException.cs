using System;

namespace Paintvale.HLE.Exceptions
{
    public class InvalidNpdmException : Exception
    {
        public InvalidNpdmException(string message) : base(message) { }
    }
}
