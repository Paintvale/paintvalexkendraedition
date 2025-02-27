using System.Diagnostics;

namespace Paintvale.Horizon.Sdk
{
    static class DebugUtil
    {
        public static void Assert(bool condition)
        {
            Debug.Assert(condition);
        }
    }
}
