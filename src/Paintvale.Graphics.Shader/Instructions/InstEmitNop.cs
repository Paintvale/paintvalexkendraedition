using Paintvale.Graphics.Shader.Decoders;
using Paintvale.Graphics.Shader.Translation;

namespace Paintvale.Graphics.Shader.Instructions
{
    static partial class InstEmit
    {
        public static void Nop(EmitterContext context)
        {
            context.GetOp<InstNop>();

            // No operation.
        }
    }
}
