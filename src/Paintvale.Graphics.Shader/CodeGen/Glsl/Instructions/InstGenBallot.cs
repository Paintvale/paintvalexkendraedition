using Paintvale.Graphics.Shader.StructuredIr;
using Paintvale.Graphics.Shader.Translation;

using static Paintvale.Graphics.Shader.CodeGen.Glsl.Instructions.InstGenHelper;
using static Paintvale.Graphics.Shader.StructuredIr.InstructionInfo;

namespace Paintvale.Graphics.Shader.CodeGen.Glsl.Instructions
{
    static class InstGenBallot
    {
        public static string Ballot(CodeGenContext context, AstOperation operation)
        {
            AggregateType dstType = GetSrcVarType(operation.Inst, 0);

            string arg = GetSourceExpr(context, operation.GetSource(0), dstType);
            char component = "xyzw"[operation.Index];

            if (context.HostCapabilities.SupportsShaderBallot)
            {
                return $"unpackUint2x32(ballotARB({arg})).{component}";
            }
            else
            {
                return $"subgroupBallot({arg}).{component}";
            }
        }
    }
}
