using System;

namespace Paintvale.HLE.HOS.Kernel.SupervisorCall
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    class PointerSizedAttribute : Attribute
    {
    }
}
