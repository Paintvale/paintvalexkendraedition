using System;

namespace Paintvale.Graphics.Shader.StructuredIr
{
    [Flags]
    enum HelperFunctionsMask
    {
        MultiplyHighS32 = 1 << 2,
        MultiplyHighU32 = 1 << 3,
        SwizzleAdd = 1 << 10,
        FSI = 1 << 11,
    }
}
