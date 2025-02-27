using System;

namespace Paintvale.HLE.HOS.Kernel.SupervisorCall
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    class SvcImplAttribute : Attribute
    {
    }
}
