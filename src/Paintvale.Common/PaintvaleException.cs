using System;

namespace Paintvale.Common
{
    public class PaintvaleException : Exception
    {
        public PaintvaleException(string message) : base(message)
        { }
    }
}
