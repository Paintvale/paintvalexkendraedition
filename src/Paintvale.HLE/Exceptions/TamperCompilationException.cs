using System;

namespace Paintvale.HLE.Exceptions
{
    public class TamperCompilationException : Exception
    {
        public TamperCompilationException(string message) : base(message) { }
    }
}
