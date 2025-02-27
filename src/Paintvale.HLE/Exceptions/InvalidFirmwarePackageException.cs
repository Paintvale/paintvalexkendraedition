using System;

namespace Paintvale.HLE.Exceptions
{
    class InvalidFirmwarePackageException : Exception
    {
        public InvalidFirmwarePackageException(string message) : base(message) { }
    }
}
